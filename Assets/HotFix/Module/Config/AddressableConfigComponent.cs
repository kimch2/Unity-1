using ETModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ETHotfix
{
    /// <summary>
    /// AddressableConfigComponent会扫描所有的有ConfigAttribute标签的配置,加载进来
    /// </summary>
    public class AddressableConfigComponent : Component
    {
        private Dictionary<Type, IAddressableCategory> allConfigCategory = new Dictionary<Type, IAddressableCategory>();

        public async ETTask LoadAsync()
        {
            this.allConfigCategory.Clear();
            List<Type> types = Game.EventSystem.GetTypes();

            foreach (Type type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof(ConfigAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }

                ConfigAttribute configAttribute = attrs[0] as ConfigAttribute;
                // 只加载指定的配置
                if (!configAttribute.Type.Is(AppType.ClientH))
                {
                    continue;
                }

                object obj = Activator.CreateInstance(type);

                IAddressableCategory iCategory = obj as IAddressableCategory;
                if (iCategory == null)
                {
                    throw new Exception($"class: {type.Name} not inherit from IAddressableCategory");
                }
                await iCategory.LoadAsync();

                this.allConfigCategory[iCategory.ConfigType] = iCategory;
            }
        }

        public virtual T[] GetAll<T>() where T : IConfig
        {
            if (!this.allConfigCategory.TryGetValue(typeof(T), out IAddressableCategory category))
            {
                throw new Exception($"AddressableConfigComponent not found key: {typeof(T).FullName}");
            }
            return category?.GetAll().OfType<T>().ToArray();
        }

        public virtual T TryGet<T>(Predicate<T> predicate) where T : IConfig
        {
            if (!this.allConfigCategory.TryGetValue(typeof(T), out IAddressableCategory category))
            {
                throw new Exception($"AddressableConfigComponent not found key: {typeof(T).FullName}");
            }
            return (T)category?.TryGet(predicate);
        }

        public T TryGet<T>(int id) where T : IConfig
        {
            if (!this.allConfigCategory.TryGetValue(typeof(T), out IAddressableCategory category))
            {
                throw new Exception($"AddressableConfigComponent not found key: {typeof(T).FullName}");
            }
            return (T)category?.TryGet(id);
        }

        public IAddressableCategory GetCategory<T>() where T : IConfig
        {
            if (!this.allConfigCategory.TryGetValue(typeof(T), out IAddressableCategory category))
            {
                throw new Exception($"AddressableConfigComponent not found key: {typeof(T).FullName}");
            }
            return category;
        }
    }
}