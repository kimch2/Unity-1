using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

namespace ETModel
{
    public class UIPolygon : BaseMeshEffect
    {
        [Tooltip("分段")]
        [Range(3, 90)]
        public int Segements = 3;

        [Tooltip("半径")]
        [Min(1)]
        public float Radius = 0.1f;

        [Tooltip("角度偏移")]
        [Range(-180, 180)]
        public float AngleOffset = 0f;

        [Tooltip("模糊距离")]
        [Range(0.1f, 5)]
        public float BlurDistance = 0.1f;

        private List<UIVertex> vertices = new List<UIVertex>();
        private List<int> indices = new List<int>();

        protected DrivenRectTransformTracker tracker = new DrivenRectTransformTracker();

        private UnityEngine.UI.Image image;

        protected override void Awake()
        {
            base.Awake();
            this.image = GetComponent<UnityEngine.UI.Image>();
        }

        public override void ModifyMesh(VertexHelper vh)
        {
            vh.Clear();
            vertices.Clear();
            indices.Clear();

            float degreeDelta = (float)(2 * Mathf.PI / Segements);

            Vector2 center = graphic.rectTransform.rect.center;
            float tw = this.graphic.rectTransform.rect.width;
            float th = this.graphic.rectTransform.rect.height;
            float radius = Radius;

            Vector4 uv = this.image.overrideSprite != null ? DataUtility.GetOuterUV(this.image.overrideSprite) : Vector4.zero;

            float uvCenterX = (uv.x + uv.z) * 0.5f + this.graphic.rectTransform.pivot.x - 0.5f;
            float uvCenterY = (uv.y + uv.w) * 0.5f + this.graphic.rectTransform.pivot.y - 0.5f;
            float uvScaleX = (uv.z - uv.x) / tw;
            float uvScaleY = (uv.w - uv.y) / th;

            float currentDegree = this.AngleOffset * Mathf.Deg2Rad;
            Vector2 currentVertice = center;
            int verticeCount = Segements + 1;
            int triangleCount;

            UIVertex uiVertex = new UIVertex();
            uiVertex.color = this.graphic.color;
            uiVertex.position = currentVertice;
            uiVertex.uv0 = new Vector2(currentVertice.x * uvScaleX + uvCenterX, currentVertice.y * uvScaleY + uvCenterY);
            vertices.Add(uiVertex);

            for (int i = 1; i < verticeCount; i++)
            {
                float cosA = Mathf.Cos(currentDegree);
                float sinA = Mathf.Sin(currentDegree);
                currentVertice = new Vector2(cosA * radius + center.x, sinA * radius + center.y);
                currentDegree += degreeDelta;

                uiVertex = new UIVertex();
                uiVertex.color = this.graphic.color;
                uiVertex.position = currentVertice;
                uiVertex.uv0 = new Vector2(currentVertice.x * uvScaleX + uvCenterX, currentVertice.y * uvScaleY + uvCenterY);
                vertices.Add(uiVertex);
            }

            currentDegree = this.AngleOffset * Mathf.Deg2Rad;
            var edgeColor = new Color(this.graphic.color.r, this.graphic.color.g, this.graphic.color.b, 0);
            for (int i = 1; i < verticeCount; i++)
            {
                float cosA = Mathf.Cos(currentDegree);
                float sinA = Mathf.Sin(currentDegree);
                currentVertice = new Vector2(cosA * (radius + this.BlurDistance) + center.x, sinA * (radius + this.BlurDistance) + center.y);
                currentDegree += degreeDelta;

                uiVertex = new UIVertex();
                uiVertex.color = edgeColor;
                uiVertex.position = currentVertice;
                uiVertex.uv0 = new Vector2(currentVertice.x * uvScaleX + uvCenterX, currentVertice.y * uvScaleY + uvCenterY);
                vertices.Add(uiVertex);
            }

            triangleCount = Segements * 3;
            for (int i = 0, vIdx = 1; i < triangleCount - 3; i += 3, vIdx++)
            {
                indices.AddRange(new int[] { vIdx, 0, vIdx + 1 });

                indices.AddRange(new int[] { vIdx + this.Segements, vIdx, vIdx + this.Segements + 1 });

                indices.AddRange(new int[] { vIdx, vIdx + 1, vIdx + this.Segements + 1 });
            }
            //首尾顶点相连
            indices.AddRange(new int[] { this.Segements, 0, 1 });
            indices.AddRange(new int[] { this.Segements, 1, this.Segements * 2 });
            indices.AddRange(new int[] { this.Segements * 2, 1, this.Segements + 1 });

            vh.AddUIVertexStream(vertices, indices);
        }
    }
}