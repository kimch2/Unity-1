using UnityEngine;

namespace ETModel
{
    [ObjectSystem]
    public class UnityResourceLoadAsyncUpdateSystem : UpdateSystem<UnityResourceLoadAsync>
    {
        public override void Update(UnityResourceLoadAsync self)
        {
            self.Update();
        }
    }

    public class UnityResourceLoadAsync : Component
    {
        private ResourceRequest request;

        private ETTaskCompletionSource<UnityEngine.Object> tcs;

        public void Update()
        {
            if (!this.request.isDone)
            {
                return;
            }

            this.tcs.SetResult(this.request.asset);
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            base.Dispose();
        }

        public ETTask<UnityEngine.Object> LoadAsync(string path)
        {
            this.tcs = new ETTaskCompletionSource<UnityEngine.Object>();
            this.request = UnityEngine.Resources.LoadAsync(path);
            return this.tcs.Task;
        }
    }
}