using System;
using System.Collections.Generic;

namespace ETModel
{
    [ObjectSystem]
    public class StateComponentAwakeSystem : AwakeSystem<StateComponent>
    {
        public override void Awake(StateComponent self)
        {
            self.Awake();
        }
    }

    public class StateComponent : Component
    {
        private readonly Dictionary<Type, Dictionary<string, IState>> allStates = new Dictionary<Type, Dictionary<string, IState>>();

        public void Awake()
        {
            List<Type> types = Game.EventSystem.GetTypes(typeof(StateAttribute));
            foreach (Type type in types)
            {
                StateAttribute[] attributes = type.GetCustomAttributes(typeof(StateAttribute), false) as StateAttribute[];
                foreach (var attribute in attributes)
                {
                    if (!this.allStates.ContainsKey(attribute.Type))
                    {
                        this.allStates[attribute.Type] = new Dictionary<string, IState>();
                    }
                    this.allStates[attribute.Type][attribute.State] = (Activator.CreateInstance(type) as IState) ?? throw new Exception($"Type {attribute.Type} not inherited from IState.");
                }
            }
        }

        public void SetState(object element, string state)
        {
            if (this.allStates.TryGetValue(element.GetType(), out Dictionary<string, IState> states) && states.TryGetValue(state, out IState iState))
            {
                iState.SetState(element);
            }
        }
    }
}