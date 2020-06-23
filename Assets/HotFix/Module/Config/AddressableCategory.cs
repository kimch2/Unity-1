using ETModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ETHotfix
{
    public interface IAddressableCategory
    {
        Type ConfigType { get; }

        ETTask LoadAsync();

        IConfig TryGet<T>(Predicate<T> predicate) where T : IConfig;

        IConfig[] GetAll();

        IConfig TryGet(int id);
    }

    /// <summary>
    /// 管理配置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AddressableCategory<T> : IAddressableCategory where T : IConfig
    {
        public virtual Type ConfigType => typeof(T);

        protected Dictionary<long, IConfig> dictionary;

        public virtual async ETTask LoadAsync()
        {
            this.dictionary = new Dictionary<long, IConfig>();

            UnityEngine.Debug.Log($"解析配置{ConfigType.Name}...");
            string configStr = (await UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<UnityEngine.TextAsset>(ConfigType.Name).Task).text;

            foreach (string str in configStr.Split(new[] { "\n" }, StringSplitOptions.None))
            {
                try
                {
                    string str2 = str.Trim();
                    if (str2 == "")
                    {
                        continue;
                    }
                    T t = JsonHelper.FromJson<T>(str2);
                    this.dictionary.Add(t.Id, t);
                }
                catch (Exception e)
                {
                    throw new Exception($"parser json fail: {str}", e);
                }
            }
        }

        public virtual IConfig TryGet(int id)
        {
            this.dictionary.TryGetValue(id, out IConfig t);
            return t;
        }

        public virtual IConfig[] GetAll()
        {
            return this.dictionary.Values.ToArray();
        }

        public virtual IConfig TryGet<TInput>(Predicate<TInput> predicate) where TInput : IConfig
        {
            return this.dictionary.Values.OfType<TInput>().FirstOrDefault(config => predicate(config));
        }
    }
}