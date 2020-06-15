namespace hot
{
    using System.Reflection;
    using System.Collections;
    using wxb;

    class hotApp
    {
        static void TestLog()
        {
            UnityEngine.Debug.LogFormat("TestLog");
        }

        public static hotApp my { get; private set; }

        public const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

 
        public hotApp()
        {
            my = this;
        }

        void Init()
        {
            HotPlayer.Init();
        }
    }
}