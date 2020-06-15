using System;
using System.Collections.Generic;
using System.Linq;

namespace ETModel
{
    public class UnityGameObjectComponent : Component
    {
        public static readonly UnityGameObject[] EmptyUnityGameObjectArray = new UnityGameObject[0];

        private readonly Dictionary<string, UnityGameObject> cachedPaths = new Dictionary<string, UnityGameObject>();

        #region Fetch

        private UnityGameObject Fetch(string path)
        {
            if (this.cachedPaths.TryGetValue(path, out UnityGameObject gameObject) && gameObject.Path == path)
            {
                return gameObject;
            }
            gameObject?.Dispose();
            this.cachedPaths.Remove(path);
            gameObject = ComponentFactory.CreateWithParent<UnityGameObject, UnityEngine.GameObject>(
                    this,
                    UnityEngine.GameObject.Find(path));
            this.cachedPaths[path] = gameObject;
            return gameObject;
        }

        #endregion Fetch

        #region Find

        public UnityGameObject FindById(int id, bool forceReload = false)
        {
            return new UnityGameObject();
        }

        public UnityGameObject FindByPath(string path, bool forceReload = false)
        {
            return Fetch(path);
        }

        public UnityGameObject FindByKey(string key, bool forceReload = false)
        {
            return new UnityGameObject();
        }

        #endregion Find

        #region FindAll

        public UnityGameObject[] FindAllById(int[] ids, bool forceReload = false)
        {
            return ids == null || ids.Length == 0
                ? EmptyUnityGameObjectArray
                : ids.Distinct()

                    .Select(id => FindById(id, forceReload))
                    .Where(component => component != null)
                    .ToArray();
        }

        public UnityGameObject[] FindAllByPath(string[] paths, bool forceReload = false)
        {
            return paths == null || paths.Length == 0
                ? EmptyUnityGameObjectArray
                : paths.Distinct()
                    .Where(path => !string.IsNullOrEmpty(path))

                    .Select(path => FindByPath(path, forceReload))
                    .Where(component => component != null)
                    .ToArray();
        }

        public UnityGameObject[] FindAllByKey(string[] keys, bool forceReload = false)
        {
            return keys == null || keys.Length == 0
                ? EmptyUnityGameObjectArray
                : keys.Distinct()
                    .Where(path => !string.IsNullOrEmpty(path))

                    .Select(key => FindByKey(key, forceReload))
                    .Where(component => component != null)
                    .ToArray();
        }

        #endregion FindAll

        #region SeState

        public void SetState(bool state, params int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return;
            }
            SetState(state, FindAllById(ids));
        }

        public void SetState(bool state, params string[] keys)
        {
            if (keys == null || keys.Length == 0)
            {
                return;
            }
            SetState(state, FindAllByKey(keys));
        }

        private void SetState(bool state, params UnityGameObject[] targets)
        {
            if (targets == null || targets.Length == 0)
            {
                return;
            }
            foreach (UnityGameObject target in targets)
            {
                target?.SetState(state);
            }
        }

        #endregion SeState

        public override void Dispose()
        {
            base.Dispose();

            foreach (UnityGameObject unityGameObject in this.cachedPaths.Values)
            {
                try
                {
                    unityGameObject.Dispose();
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
            this.cachedPaths.Clear();
        }
    }
}