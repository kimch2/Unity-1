using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
namespace ETModel
{
    /// <summary>
    /// AddressableConfigComponent会扫描所有的有ConfigAttribute标签的配置,加载进来
    /// </summary>
    public class AddressableConfigComponent : Component
    {
        private Dictionary<Type, ScriptObjectConfig> allConfigCategory = new Dictionary<Type, ScriptObjectConfig>();

        public async ETTask LoadAsync()
        {
            this.allConfigCategory.Clear();

            var go=await Addressables.LoadAssetAsync<UnityEngine.GameObject>(Address.Config_Config).Task;
  
            foreach (var item in go.GetComponent<ReferenceCollector>().data)
            {
                Type type = (item.gameObject as ScriptObjectConfig).ItemList.FirstOrDefault().GetType();
                allConfigCategory.Add(type, (item.gameObject as ScriptObjectConfig));
            }
         }

        public virtual T[] GetAll<T>() where T : IConfig
        {
            if (!this.allConfigCategory.TryGetValue(typeof(T), out ScriptObjectConfig category))
            {
                throw new Exception($"AddressableConfigComponent not found key: {typeof(T).FullName}");
            }
            return category?.ItemList.OfType<T>().ToArray();
        }
  
        public virtual T[] TryGetAll<T>(Predicate<T> predicate) where T : IConfig
        {
            if (!this.allConfigCategory.TryGetValue(typeof(T), out ScriptObjectConfig category))
            {
                throw new Exception($"AddressableConfigComponent not found key: {typeof(T).FullName}");
            }
             return category?.ItemList.OfType<T>().Where(x => predicate(x)).ToArray();

        }

        public T TryGet<T>(int id) where T : IConfig
        {
            if (!this.allConfigCategory.TryGetValue(typeof(T), out ScriptObjectConfig category))
            {
                throw new Exception($"AddressableConfigComponent not found key: {typeof(T).FullName}");
            }
            return (T)category.ItemList.OfType<T>().Select(x => x).Where(y => y.Id == id);
        }

        public ScriptObjectConfig GetCategory<T>() where T : IConfig
        {
            if (!this.allConfigCategory.TryGetValue(typeof(T), out ScriptObjectConfig category))
            {
                throw new Exception($"AddressableConfigComponent not found key: {typeof(T).FullName}");
            }
            return category;
        }
    }
}