using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Xml;
using ETModel;
using System;
using UnityEngine.AddressableAssets;

namespace ETModel {
    [ObjectSystem]
    public class AudioAwakeSystem : AwakeSystem<AudioComponent>
    {
        public override void Awake(AudioComponent self)
        {
            self.Awake();
        }
    }

    public class AudioComponent : ETModel.Component {

        public void Awake()
        {
             InitData();
        }

        private float _volume;
        public float Volume {
            get { return _volume; }
            set
            {
                foreach (var item in Pool)
                {
                    item.volume = value;
                }
                _volume = value;
            }

        }
 
        private async void InitData()
        {
        }

        private List<AudioSource> Pool = new List<AudioSource>();

        public Dictionary<string, AudioClip> AudioDic = new Dictionary<string, AudioClip>();

        public void PlayAudio(string ID, bool loop = false)
        {
            if (!AudioDic.ContainsKey(ID))
                return;
            for (int i = 0; i < Pool.Count; i++)
            {
                if (Pool[i].clip == AudioDic[ID])
                {
                    if (!Pool[i].isPlaying)
                    {
                         Pool[i].loop = loop;
                        Pool[i].volume = Volume;
                        Pool[i].Play();
                        return;
                    }
                    else
                    {
                         Pool[i].Stop();
                        Pool[i].Play();
                        return;
                    }
                }
            
            }
            for (int i = 0; i < Pool.Count; i++)
            {
                if (!Pool[i].isPlaying)
                {
                    Pool[i].clip = AudioDic[ID];
                    Pool[i].loop = loop;
                    Pool[i].Play();
                    return;
                }
            }
            GameObject temp = new GameObject("AudioClip");
            temp.transform.SetParent(GameObject.transform);
            AudioSource audio = temp.AddComponent<AudioSource>();
            Pool.Add(audio);
            audio.clip = AudioDic[ID];
            audio.loop = loop;
            audio.Play();
        }

        public float GetAudioLength(string audio)
        {
            AudioDic.TryGetValue(audio, out AudioClip value);
            if (value != null)
            {
                return value.length;
            }
            return 0;
        }

        public void CloseAudio(string ID)
        {
            for (int i = 0; i < Pool.Count; i++)
            {
                if (Pool[i].clip == AudioDic[ID] && Pool[i].isPlaying)
                {
                    Pool[i].Stop();
                }
            }
        }

        public void PauseAudio(string ID)
        {
            for (int i = 0; i < Pool.Count; i++)
            {
                if (Pool[i].clip == AudioDic[ID] && Pool[i].isPlaying)
                {
                    Pool[i].Pause();
                }
            }
        }
    }
}