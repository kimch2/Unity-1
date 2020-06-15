namespace ETModel
{
    public static class StateUtils
    {
        public static void SetState(this object element, string state)
        {
            Game.Scene.GetComponent<StateComponent>()?.SetState(element, state);
        }
    }
}