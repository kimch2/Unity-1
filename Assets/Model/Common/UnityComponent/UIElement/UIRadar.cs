using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

namespace ETModel
{
    public class UIRadar : BaseMeshEffect
    {
        [Tooltip("半径")]
        [Min(1)]
        public float Radius = 1f;

        [Tooltip("维度值")]
        public List<float> Values = new List<float>();

        [Tooltip("边缘宽度")]
        [Range(1,5)]
        public float EdgeWidth = 0.1f;

        [Tooltip("边缘颜色")]
        public Color EdgeColor = Color.white;

        [Tooltip("角度偏移")]
        [Range(-180, 180)]
        public float AngleOffset = 0f;

        [Tooltip("模糊距离")]
        [Range(0.1f, 5)]
        public float BlurDistance = 0.1f;

        private List<UIVertex> vertices = new List<UIVertex>();
        private List<int> indices = new List<int>();

        private List<float> cosValues = new List<float>();
        private List<float> sinValues = new List<float>();

        private UnityEngine.UI.Image image;

        protected override void Awake()
        {
            base.Awake();
            this.image = GetComponent<UnityEngine.UI.Image>();
        }

        public override void ModifyMesh(VertexHelper vh)
        {
            if (!this.isActiveAndEnabled || this.Values.Count < 3)
            {
                return;
            }

            vh.Clear();
            vertices.Clear();
            indices.Clear();
            cosValues.Clear();
            sinValues.Clear();

            var segements = this.Values.Count;
            float degreeDelta = (float)(2 * Mathf.PI / segements);

            Vector2 center = graphic.rectTransform.rect.center;
            float tw = this.graphic.rectTransform.rect.width;
            float th = this.graphic.rectTransform.rect.height;

            Vector4 uv = this.image.overrideSprite != null ? DataUtility.GetOuterUV(this.image.overrideSprite) : Vector4.zero;

            float uvCenterX = (uv.x + uv.z) * 0.5f + this.graphic.rectTransform.pivot.x - 0.5f;
            float uvCenterY = (uv.y + uv.w) * 0.5f + this.graphic.rectTransform.pivot.y - 0.5f;
            float uvScaleX = (uv.z - uv.x) / tw;
            float uvScaleY = (uv.w - uv.y) / th;

            float currentDegree = this.AngleOffset * Mathf.Deg2Rad;
            cosValues.Capacity = segements;
            sinValues.Capacity = segements;
            for (int i = 0; i < segements; i++)
            {
                cosValues.Add(Mathf.Cos(currentDegree));
                sinValues.Add(Mathf.Sin(currentDegree));
                currentDegree += degreeDelta;
            }

            Vector2 currentVertice = center;

            UIVertex uiVertex = new UIVertex();
            uiVertex.color = this.graphic.color;
            uiVertex.position = currentVertice;
            uiVertex.uv0 = new Vector2(currentVertice.x * uvScaleX + uvCenterX, currentVertice.y * uvScaleY + uvCenterY);
            vertices.Add(uiVertex);

            for (int i = 0; i < segements; i++)
            {
                currentVertice = new Vector2(cosValues[i] * this.Radius * this.Values[i] + center.x, sinValues[i] * this.Radius * this.Values[i] + center.y);

                uiVertex = new UIVertex();
                uiVertex.color = this.graphic.color;
                uiVertex.position = currentVertice;
                uiVertex.uv0 = new Vector2(currentVertice.x * uvScaleX + uvCenterX, currentVertice.y * uvScaleY + uvCenterY);
                vertices.Add(uiVertex);
            }

            for (int i = 0; i < segements; i++)
            {
                currentVertice = new Vector2(cosValues[i] * this.Radius * this.Values[i] + center.x, sinValues[i] * this.Radius * this.Values[i] + center.y);

                uiVertex = new UIVertex();
                uiVertex.color = this.EdgeColor;
                uiVertex.position = currentVertice;
                uiVertex.uv0 = new Vector2(currentVertice.x * uvScaleX + uvCenterX, currentVertice.y * uvScaleY + uvCenterY);
                vertices.Add(uiVertex);
            }

            for (int i = 0; i < segements; i++)
            {
                currentVertice = new Vector2(cosValues[i] * (this.Radius * this.Values[i] + this.EdgeWidth) + center.x, sinValues[i] * (this.Radius * this.Values[i] + this.EdgeWidth) + center.y);

                uiVertex = new UIVertex();
                uiVertex.color = this.EdgeColor;
                uiVertex.position = currentVertice;
                uiVertex.uv0 = new Vector2(currentVertice.x * uvScaleX + uvCenterX, currentVertice.y * uvScaleY + uvCenterY);
                vertices.Add(uiVertex);
            }

            var blurColor = new Color(this.EdgeColor.r, this.EdgeColor.g, this.EdgeColor.b, 0);
            for (int i = 0; i < segements; i++)
            {
                currentVertice = new Vector2(cosValues[i] * (this.Radius * this.Values[i] + this.EdgeWidth + this.BlurDistance) + center.x, sinValues[i] * (this.Radius * this.Values[i] + this.EdgeWidth + this.BlurDistance) + center.y);

                uiVertex = new UIVertex();
                uiVertex.color = blurColor;
                uiVertex.position = currentVertice;
                uiVertex.uv0 = new Vector2(currentVertice.x * uvScaleX + uvCenterX, currentVertice.y * uvScaleY + uvCenterY);
                vertices.Add(uiVertex);
            }

            for (int i = 0; i < segements - 1; i++)
            {
                indices.AddRange(new int[] { i + 1, 0, i + 2 });

                indices.AddRange(new int[] { i + segements + 1, i + segements + 2, i + segements * 2 + 2 });
                indices.AddRange(new int[] { i + segements + 1, i + segements * 2 + 2, i + segements * 2 + 1 });

                indices.AddRange(new int[] { i + segements * 2 + 1, i + segements * 2 + 2, i + segements * 3 + 2 });
                indices.AddRange(new int[] { i + segements * 2 + 1, i + segements * 3 + 2, i + segements * 3 + 1 });
            }
            //首尾顶点相连
            indices.AddRange(new int[] { segements, 0, 1 });

            indices.AddRange(new int[] { segements * 2, segements + 1, segements * 2 + 1 });
            indices.AddRange(new int[] { segements * 2, segements * 2 + 1, segements * 3 });

            indices.AddRange(new int[] { segements * 3, segements * 2 + 1, segements * 3 + 1 });
            indices.AddRange(new int[] { segements * 3, segements * 3 + 1, segements * 4 });

            vh.AddUIVertexStream(vertices, indices);
        }
    }
}