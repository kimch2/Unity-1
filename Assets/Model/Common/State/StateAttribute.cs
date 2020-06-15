using System;

namespace ETModel
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class StateAttribute : BaseAttribute
    {
        public readonly Type Type;
        public readonly string State;

        public StateAttribute(Type type, string state)
        {
            this.Type = type;
            this.State = state;
        }
    }
}