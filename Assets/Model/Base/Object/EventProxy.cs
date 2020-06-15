using System;
using System.Collections.Generic;

namespace ETModel
{
    public class EventProxy : IEvent
    {
        public Action<List<object>> action;
        public List<object> param = new List<object>();

        public EventProxy(Action<List<object>> action)
        {
            this.action = action;
        }

        public void Handle()
        {
            this.param.Clear();
            this.action.Invoke(this.param);
        }

        public void Handle(object a)
        {
            this.param.Clear();
            this.param.Add(a);
            this.action.Invoke(this.param);
        }

        public void Handle(object a, object b)
        {
            this.param.Clear();
            this.param.Add(a);
            this.param.Add(b);
            this.action.Invoke(this.param);
        }

        public void Handle(object a, object b, object c)
        {
            this.param.Clear();
            this.param.Add(a);
            this.param.Add(b);
            this.param.Add(c);
            this.action.Invoke(this.param);
        }

        private ETTaskCompletionSource tcs;
        private void AsyncCallback(IAsyncResult asyncResult)
        {
            this.tcs.SetResult();
            this.tcs = null;
        }

        public ETTask HandleAsync()
        {
            this.tcs = new ETTaskCompletionSource();

            this.param.Clear();
            this.action.BeginInvoke(this.param, AsyncCallback, this.action);

            return this.tcs.Task;
        }

        public ETTask HandleAsync(object a)
        {
            this.tcs = new ETTaskCompletionSource();

            this.param.Clear();
            this.param.Add(a);
            this.action.BeginInvoke(this.param, AsyncCallback, this.action);

            return this.tcs.Task;
        }

        public ETTask HandleAsync(object a, object b)
        {
            this.tcs = new ETTaskCompletionSource();

            this.param.Clear();
            this.param.Add(a);
            this.param.Add(b);
            this.action.BeginInvoke(this.param, AsyncCallback, this.action);

            return this.tcs.Task;
        }

        public ETTask HandleAsync(object a, object b, object c)
        {
            this.tcs = new ETTaskCompletionSource();

            this.param.Clear();
            this.param.Add(a);
            this.param.Add(b);
            this.param.Add(c);
            this.action.BeginInvoke(this.param, AsyncCallback, this.action);

            return this.tcs.Task;
        }
    }
}
