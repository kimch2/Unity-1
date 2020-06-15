using System;

namespace ETModel
{
    public interface IEvent
    {
        void Handle();
        void Handle(object a);
        void Handle(object a, object b);
        void Handle(object a, object b, object c);

        ETTask HandleAsync();
        ETTask HandleAsync(object a);
        ETTask HandleAsync(object a, object b);
        ETTask HandleAsync(object a, object b, object c);
    }

    public abstract class AEvent : IEvent
    {
        public void Handle()
        {
            this.Run();
        }

        public void Handle(object a)
        {
            throw new NotImplementedException();
        }

        public void Handle(object a, object b)
        {
            throw new NotImplementedException();
        }

        public void Handle(object a, object b, object c)
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync()
        {
            await this.RunAsync();
        }

        public async ETTask HandleAsync(object a)
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync(object a, object b)
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync(object a, object b, object c)
        {
            throw new NotImplementedException();
        }

        public virtual void Run() { }
        public virtual async ETTask RunAsync() { }
    }

    public abstract class AEvent<A> : IEvent
    {
        public void Handle()
        {
            throw new NotImplementedException();
        }

        public void Handle(object a)
        {
            this.Run((A)a);
        }

        public void Handle(object a, object b)
        {
            throw new NotImplementedException();
        }

        public void Handle(object a, object b, object c)
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync()
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync(object a)
        {
            await this.RunAsync((A)a);
        }

        public async ETTask HandleAsync(object a, object b)
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync(object a, object b, object c)
        {
            throw new NotImplementedException();
        }

        public virtual void Run(A a) { }
        public virtual async ETTask RunAsync(A a) { }
    }

    public abstract class AEvent<A, B> : IEvent
    {
        public void Handle()
        {
            throw new NotImplementedException();
        }

        public void Handle(object a)
        {
            throw new NotImplementedException();
        }

        public void Handle(object a, object b)
        {
            this.Run((A)a, (B)b);
        }

        public void Handle(object a, object b, object c)
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync()
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync(object a)
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync(object a, object b)
        {
            await this.RunAsync((A)a, (B)b);
        }

        public async ETTask HandleAsync(object a, object b, object c)
        {
            throw new NotImplementedException();
        }

        public virtual void Run(A a, B b) { }
        public virtual async ETTask RunAsync(A a, B b) { }
    }

    public abstract class AEvent<A, B, C> : IEvent
    {
        public void Handle()
        {
            //throw new NotImplementedException();
        }

        public void Handle(object a)
        {
            //throw new NotImplementedException();
        }

        public void Handle(object a, object b)
        {
            //throw new NotImplementedException();
        }

        public void Handle(object a, object b, object c)
        {
            this.Run((A)a, (B)b, (C)c);
        }

        public async ETTask HandleAsync()
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync(object a)
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync(object a, object b)
        {
            throw new NotImplementedException();
        }

        public async ETTask HandleAsync(object a, object b, object c)
        {
            await this.RunAsync((A)a, (B)b, (C)c);
        }

        public virtual void Run(A a, B b, C c) { }
        public virtual async ETTask RunAsync(A a, B b, C c) { }
    }
}