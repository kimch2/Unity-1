using System;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    public static partial class GameObjectHelper
    {
        public static GameObject UpdateName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        #region UpdateLocalPosition

        public static GameObject UpdateLocalPosition(this GameObject gameObject, Vector3 localPosition)
        {
            gameObject.transform.localPosition = localPosition;
            return gameObject;
        }

        public static GameObject UpdateLocalPosition(this GameObject gameObject, float localX, float localY, float localZ)
        {
            gameObject.transform.localPosition = new Vector3(localX, localY, localZ);
            return gameObject;
        }

        public static GameObject UpdateLocalPositionX(this GameObject gameObject, float x)
        {
            Vector3 temp = gameObject.transform.localPosition;
            return UpdateLocalPosition(gameObject, x, temp.y, temp.z);
        }

        public static GameObject UpdateLocalPositionY(this GameObject gameObject, float y)
        {
            Vector3 temp = gameObject.transform.localPosition;
            return UpdateLocalPosition(gameObject, temp.x, y, temp.z);
        }

        public static GameObject UpdateLocalPositionZ(this GameObject gameObject, float z)
        {
            Vector3 temp = gameObject.transform.localPosition;
            return UpdateLocalPosition(gameObject, temp.x, temp.y, z);
        }

        #endregion UpdateLocalPosition

        #region UpdatePosition

        public static GameObject UpdatePosition(this GameObject gameObject, Vector3 position)
        {
            gameObject.transform.position = position;
            return gameObject;
        }

        public static GameObject UpdatePosition(this GameObject gameObject, float localX, float localY, float localZ)
        {
            gameObject.transform.position = new Vector3(localX, localY, localZ);
            return gameObject;
        }

        public static GameObject UpdatePositionX(this GameObject gameObject, float x)
        {
            Vector3 temp = gameObject.transform.position;
            return UpdatePosition(gameObject, x, temp.y, temp.z);
        }

        public static GameObject UpdatePositionY(this GameObject gameObject, float y)
        {
            Vector3 temp = gameObject.transform.position;
            return UpdatePosition(gameObject, temp.x, y, temp.z);
        }

        public static GameObject UpdatePositionZ(this GameObject gameObject, float z)
        {
            Vector3 temp = gameObject.transform.position;
            return UpdatePosition(gameObject, temp.x, temp.y, z);
        }

        #endregion UpdatePosition

        #region UpdateLocalEulerAngles

        public static GameObject UpdateLocalEulerAngles(this GameObject gameObject, Vector3 localEulerAngles)
        {
            gameObject.transform.localEulerAngles = localEulerAngles;
            return gameObject;
        }

        public static GameObject UpdateLocalEulerAngles(this GameObject gameObject, float localX, float localY, float localZ)
        {
            gameObject.transform.localEulerAngles = new Vector3(localX, localY, localZ);
            return gameObject;
        }

        public static GameObject UpdateLocalEulerAnglesX(this GameObject gameObject, float x)
        {
            Vector3 temp = gameObject.transform.localEulerAngles;
            return UpdateLocalEulerAngles(gameObject, x, temp.y, temp.z);
        }

        public static GameObject UpdateLocalEulerAnglesY(this GameObject gameObject, float y)
        {
            Vector3 temp = gameObject.transform.localEulerAngles;
            return UpdateLocalEulerAngles(gameObject, temp.x, y, temp.z);
        }

        public static GameObject UpdateLocalEulerAnglesZ(this GameObject gameObject, float z)
        {
            Vector3 temp = gameObject.transform.localEulerAngles;
            return UpdateLocalEulerAngles(gameObject, temp.x, temp.y, z);
        }

        #endregion UpdateLocalEulerAngles

        #region UpdateEulerAngles

        public static GameObject UpdateEulerAngles(this GameObject gameObject, Vector3 eulerAngles)
        {
            gameObject.transform.eulerAngles = eulerAngles;
            return gameObject;
        }

        public static GameObject UpdateEulerAngles(this GameObject gameObject, float localX, float localY, float localZ)
        {
            gameObject.transform.eulerAngles = new Vector3(localX, localY, localZ);
            return gameObject;
        }

        public static GameObject UpdateEulerAnglesX(this GameObject gameObject, float x)
        {
            Vector3 temp = gameObject.transform.eulerAngles;
            return UpdateEulerAngles(gameObject, x, temp.y, temp.z);
        }

        public static GameObject UpdateEulerAnglesY(this GameObject gameObject, float y)
        {
            Vector3 temp = gameObject.transform.eulerAngles;
            return UpdateEulerAngles(gameObject, temp.x, y, temp.z);
        }

        public static GameObject UpdateEulerAnglesZ(this GameObject gameObject, float z)
        {
            Vector3 temp = gameObject.transform.eulerAngles;
            return UpdateEulerAngles(gameObject, temp.x, temp.y, z);
        }

        #endregion UpdateEulerAngles

        #region UpdateLocalScale

        public static GameObject UpdateLocalScale(this GameObject gameObject, Vector3 localScale)
        {
            gameObject.transform.localScale = localScale;
            return gameObject;
        }

        public static GameObject UpdateLocalScale(this GameObject gameObject, float localX, float localY, float localZ)
        {
            gameObject.transform.localScale = new Vector3(localX, localY, localZ);
            return gameObject;
        }

        public static GameObject UpdateLocalScaleX(this GameObject gameObject, float x)
        {
            Vector3 temp = gameObject.transform.localScale;
            return UpdateLocalScale(gameObject, x, temp.y, temp.z);
        }

        public static GameObject UpdateLocalScaleY(this GameObject gameObject, float y)
        {
            Vector3 temp = gameObject.transform.localScale;
            return UpdateLocalScale(gameObject, temp.x, y, temp.z);
        }

        public static GameObject UpdateLocalScaleZ(this GameObject gameObject, float z)
        {
            Vector3 temp = gameObject.transform.localScale;
            return UpdateLocalScale(gameObject, temp.x, temp.y, z);
        }

        #endregion UpdateLocalScale

        public static GameObject UpdateLocalRotation(this GameObject gameObject, Quaternion localRotation)
        {
            gameObject.transform.localRotation = localRotation;
            return gameObject;
        }

        public static GameObject UpdateRotation(this GameObject gameObject, Quaternion rotation)
        {
            gameObject.transform.rotation = rotation;
            return gameObject;
        }

        public static GameObject UpdateState(this GameObject gameObject, bool state)
        {
            if (gameObject.activeInHierarchy != state)
            {
                gameObject.SetActive(state);
            }
            return gameObject;
        }

        public static GameObject UpdateParent(this GameObject gameObject, Transform parent, bool worldPositionStays = true)
        {
            gameObject.transform.SetParent(parent, worldPositionStays);
            return gameObject;
        }

        public static GameObject UpdateDontDestroyOnLoad(this GameObject gameObject)
        {
            GameObject.DontDestroyOnLoad(gameObject);
            return gameObject;
        }

        public static GameObject Child(this GameObject gameObject, string path)
        {
            return gameObject?.transform.Find(path)?.gameObject;
        }

        public static T Child<T>(this GameObject gameObject, string path)
        {
            return Child(gameObject, path).GetComponent<T>();
        }

        public static GameObject Child<T>(this GameObject gameObject, string path, ref T field)
        {
            field = Child<T>(gameObject, path);
            return gameObject;
        }

        public static string GetHierarchyPath(this GameObject gameObject)
        {
            List<string> paths = new List<string>();
            Transform current = gameObject.transform;
            while (current)
            {
                paths.Insert(0, current.name);
                current = current.parent;
            }
            return string.Join("/", paths);
        }

        public static int GetHierarchyDepth(this GameObject gameObject)
        {
            int depth = -1;
            Transform current = gameObject.transform;
            while (current)
            {
                depth++;
                current = current.parent;
            }
            return depth;
        }

        public static void DestroyChildren(this UnityEngine.GameObject gameObject,Action<GameObject> beforeDestroy = null)
        {
            int length = gameObject.transform.childCount;
            for (int i = 0; i < length; i++)
            {
                beforeDestroy?.Invoke(gameObject.transform.GetChild(0).gameObject);
                UnityEngine.GameObject.DestroyImmediate(gameObject.transform.GetChild(0).gameObject);
            }
        }
    }
}