using System;

namespace ETModel
{
    public interface IState
    {
        void SetState(object element);
    }

    public abstract class State<T> : IState
    {
        public void SetState(object element)
        {
            ChangeState((T)element);
        }

        public abstract void ChangeState(T element);
    }
}