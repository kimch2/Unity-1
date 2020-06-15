namespace ETModel
{
    [ObjectSystem]
    public class AudioListenerComponentAwakeSystem : AwakeSystem<AudioListenerComponent>
    {
        public override void Awake(AudioListenerComponent self)
        {
            self.Awake();
        }
    }

    [HideInHierarchy]
    public class AudioListenerComponent : Component
    {
        public static AudioListenerComponent Default { get; private set; }

        public static bool Pause
        {
            get => UnityEngine.AudioListener.pause;
            set
            {
                if (UnityEngine.AudioListener.pause == value)
                {
                    return;
                }
                UnityEngine.AudioListener.pause = value;
            }
        }

        public static float Volume
        {
            get => UnityEngine.AudioListener.volume;
            set
            {
                if (UnityEngine.AudioListener.volume == value)
                {
                    return;
                }
                UnityEngine.AudioListener.volume = value;
            }
        }

        public void Awake()
        {
            GetParent<MainCameraComponent>().Camera.gameObject.AddComponent<UnityEngine.AudioListener>();
        }
    }
}