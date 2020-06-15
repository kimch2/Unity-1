using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ETModel
{
    public class UILine : MaskableGraphic
    {
        public AnimationCurve AnimationCurve = AnimationCurve.Linear(0, -0.5f, 1, 0.5f);
        public float CycleCount = 1;
        public float ShakeValue = 0;
        public float LineWidth = 1;
        public int PointCount = 100;

        private AnimationCurve curve;
        private List<Keyframe> srcKeyFrames = new List<Keyframe>();

        [Range(-1, 1)]
        public float OffsetX = 0;

        [Range(-1, 1)]
        public float OffsetY = 0;

        private List<Vector2> points = new List<Vector2>();
        private List<int> indexs = new List<int>();
        private List<UIVertex> uiVertices = new List<UIVertex>();

        protected override void Awake()
        {
            curve = new AnimationCurve(AnimationCurve.keys);
            srcKeyFrames = new List<Keyframe>(curve.keys);
            base.Awake();
        }

        private void Update()
        {
            SimulateByCurve();
            UpdateGeometry();
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            if (isActiveAndEnabled && AnimationCurve != null)
            {
                vh.AddUIVertexStream(uiVertices, indexs);
            }
        }

        private void SimulateByCurve()
        {
            points.Clear();
            indexs.Clear();
            uiVertices.Clear();

            GeneratePoint();
            GenerateUIVertices();
            GenerateIndexs();
        }

        private void GeneratePoint()
        {
            //抖动
            Keyframe[] keys = new Keyframe[srcKeyFrames.Count];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = new Keyframe(
                    srcKeyFrames[i].time + ShakeValue * Mathf.Sign(Random.Range(-0.5f, 0.5f)) * 0.1f,
                    srcKeyFrames[i].value + ShakeValue * Mathf.Sign(Random.Range(-0.5f, 0.5f)),
                    srcKeyFrames[i].inTangent,
                    srcKeyFrames[i].outTangent,
                    srcKeyFrames[i].inWeight,
                    srcKeyFrames[i].outWeight);
            }
            curve.keys = keys;

            float cycleLength = 1f / CycleCount;
            for (int i = 0; i < PointCount + 1; i++)
            {
                float x = i * 1f / PointCount;
                points.Add(new Vector2(
                    Mathf.LerpUnclamped(rectTransform.rect.xMin, rectTransform.rect.xMax, x + OffsetX),
                    Mathf.LerpUnclamped(rectTransform.rect.yMin, rectTransform.rect.yMax, curve.Evaluate(x % cycleLength / cycleLength) + 0.5f + OffsetY)
               ));
            }
        }

        private void GenerateUIVertices()
        {
            GenerateWidthVertex(points[0] + Vector2.down, points[0]);
            for (int i = 0; i < points.Count - 1; i++)
            {
                GenerateWidthVertex(points[i], points[i + 1]);
            }
        }

        private void GenerateIndexs()
        {
            for (int i = 0; i < uiVertices.Count - 4; i += 3)
            {
                indexs.Add(i);
                indexs.Add(i + 1);
                indexs.Add(i + 3);

                indexs.Add(i + 1);
                indexs.Add(i + 4);
                indexs.Add(i + 3);

                indexs.Add(i + 1);
                indexs.Add(i + 2);
                indexs.Add(i + 4);

                indexs.Add(i + 2);
                indexs.Add(i + 5);
                indexs.Add(i + 4);
            }
        }

        private void GenerateWidthVertex(Vector2 start, Vector2 end)
        {
            Vector2 offset = Quaternion.Euler(0, 0, 90) * (end - start).normalized * LineWidth * 0.5f;

            uiVertices.Add(GenerateSimpleVertex(start - offset, 0));
            uiVertices.Add(GenerateSimpleVertex(start, 1));
            uiVertices.Add(GenerateSimpleVertex(start + offset, 0));

            uiVertices.Add(GenerateSimpleVertex(end - offset, 0));
            uiVertices.Add(GenerateSimpleVertex(end, 1));
            uiVertices.Add(GenerateSimpleVertex(end + offset, 0));
        }

        private UIVertex GenerateSimpleVertex(Vector2 position, float alpha)
        {
            UIVertex vertex = UIVertex.simpleVert;
            vertex.position = position;
            vertex.color = new Color(color.r, color.g, color.b, alpha);
            return vertex;
        }

        public void UpdateCurve(AnimationCurve animationCurve, float cycleCount = 1)
        {
            this.CycleCount = cycleCount;
            AnimationCurve = animationCurve;
            curve = new AnimationCurve(AnimationCurve.keys);
            srcKeyFrames = new List<Keyframe>(curve.keys);
        }

        public void UpdateCurve(Keyframe[] keyframes, float cycleCount = 1)
        {
            this.CycleCount = cycleCount;
            AnimationCurve = new AnimationCurve(keyframes);
            curve = new AnimationCurve(AnimationCurve.keys);
            srcKeyFrames = new List<Keyframe>(curve.keys);
        }

#if UNITY_EDITOR

        protected override void OnValidate()
        {
            curve = new AnimationCurve(AnimationCurve == null ? new Keyframe[0] : AnimationCurve.keys);
            srcKeyFrames = new List<Keyframe>(curve == null ? new Keyframe[0] : curve.keys);

            SimulateByCurve();
            base.OnValidate();
        }

#endif
    }
}