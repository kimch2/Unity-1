using UnityEngine.UI;

namespace ETModel
{
    public class UICollider : RawImage
    {
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
        }
    }
}