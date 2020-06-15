using System;
 using DG.Tweening;
using System.Runtime.CompilerServices;
 
namespace ETModel
{
    public class DotweenTask
    {
         public Tween Handle;

        public DotweenTask(Tween tween)
        {
            Handle = tween;
         }
        public DotweenAwaiter GetAwaiter()
        {
            return new DotweenAwaiter(this);
        }
 
    }

    public class DotweenAwaiter : INotifyCompletion
    {
        public DotweenTask Task;
        public DotweenAwaiter(DotweenTask tween)
        {
            Task = tween;
        }

        public bool IsCompleted => Task.Handle.IsComplete();

        public void GetResult()
        {
            
        }
        public  void OnCompleted(Action continuation)
        {
            if (IsCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                Task.Handle.onComplete +=()=> {continuation?.Invoke(); };
            }
        }
     }
}