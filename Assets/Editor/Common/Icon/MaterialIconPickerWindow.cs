using UnityEditor;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;
using System.Globalization;
using ETModel;

namespace ETEditor
{
    public class MaterialIconPickerWindow : EditorWindow
    {
        public static void Show(UIMaterialIconEditor icon)
        {
            var window = EditorWindow.GetWindow<MaterialIconPickerWindow>("图标");
            window.maxSize = window.minSize = new Vector2(706, 740);
            window.iconEditor = icon;
        }

        private GUIStyle iconStyle;
        private Vector2 scrollPosition;

        private int iconsPerPage = 100;
        private int currentPage;

        private static int previewSize = 64;
        private static Texture2D backdropTexture;
        public const string IconJsonFilePath = "./Assets/AddressableAssets/Icons/~Material Icons.json";

        private UIMaterialIconEditor iconEditor;

        private Dictionary<string, string> iconDatas;

        private void OnEnable()
        {
            this.iconStyle = new GUIStyle
            {
                font = UnityEditor.AssetDatabase.LoadAssetAtPath<Font>("Assets/AddressableAssets/Icons/~Material Icons.ttf")
            };
            this.iconStyle.normal.textColor = Color.white;
            this.currentPage = 0;

            this.iconDatas = JsonHelper.FromJson<Dictionary<string, string>>(System.IO.File.ReadAllText(IconJsonFilePath));
        }

        private void OnGUI()
        {
            using (GUILayout.ScrollViewScope scrollViewScope = new GUILayout.ScrollViewScope(scrollPosition, GUILayout.Height(1000)))
            {
                scrollPosition = scrollViewScope.scrollPosition;

                DrawPageSlider();
                DrawPicker();
            }
        }

        private void DrawPageSlider()
        {
            using (new GUILayout.HorizontalScope())
            {
                this.currentPage = (int)GUI.HorizontalSlider(new Rect(10, 10, position.width - 20, 24), this.currentPage, 0, this.iconDatas.Count / this.iconsPerPage);
            }
        }

        private void DrawPicker()
        {
            if (this.iconDatas == null || this.iconDatas.Count < 1)
            {
                GUILayout.Label("No Icons");
                return;
            }

            DrawIconListByPage(0);
        }

        private void DrawIconListByPage(int page)
        {
            Rect rect = new Rect(10, 50, previewSize, previewSize);

            var length = Mathf.Min(this.iconsPerPage * (this.currentPage + 1), this.iconDatas.Count);
            for (int i = this.currentPage * this.iconsPerPage; i < length; i++)
            {
                if (GUI.Button(rect, new GUIContent(string.Empty, this.iconDatas.ElementAt(i).Key)))
                {
                    if (Event.current.button == 0)
                    {
                        foreach (UIMaterialIcon icon in this.iconEditor.targets)
                        {
                            icon.Icon = this.iconDatas.ElementAt(i).Value;
                        }
                        this.Close();
                    }
                }

                DrawTiledTexture(rect);

                this.iconStyle.fontSize = previewSize;
                string iconText = ((char)int.Parse(this.iconDatas.ElementAt(i).Value, NumberStyles.HexNumber)).ToString();
                Vector2 size = this.iconStyle.CalcSize(new GUIContent(iconText));

                float maxSide = size.x > size.y ? size.x : size.y;
                float scaleFactor = (previewSize / maxSide) * 0.9f;

                this.iconStyle.fontSize = Mathf.RoundToInt(previewSize * scaleFactor);
                size *= scaleFactor;

                Vector2 padding = new Vector2(rect.width - size.x, rect.height - size.y);
                Rect iconRect = new Rect(rect.x + (padding.x / 2f), rect.y + (padding.y / 2f), rect.width - padding.x, rect.height - padding.y);

                GUI.Label(iconRect, new GUIContent(iconText), this.iconStyle);

                rect.x += previewSize + 5;

                if (rect.x >= position.width - 10 - previewSize)
                {
                    rect.x = 10;
                    rect.y += previewSize + 5;
                }
            }
        }

        private void DrawTiledTexture(Rect rect)
        {
            CreateCheckerTexture();

            GUI.BeginGroup(rect);
            {
                int width = Mathf.RoundToInt(rect.width);
                int height = Mathf.RoundToInt(rect.height);

                for (int y = 0; y < height; y += backdropTexture.height)
                {
                    for (int x = 0; x < width; x += backdropTexture.width)
                    {
                        GUI.DrawTexture(new Rect(x, y, backdropTexture.width, backdropTexture.height), backdropTexture);
                    }
                }
            }
            GUI.EndGroup();
        }

        private void CreateCheckerTexture()
        {
            if (backdropTexture != null)
            {
                return;
            }

            Color c0 = new Color(0.1f, 0.1f, 0.1f, 0.5f);
            Color c1 = new Color(0.2f, 0.2f, 0.2f, 0.5f);

            backdropTexture = new Texture2D(16, 16);
            backdropTexture.name = "[Generated] Checker Texture";
            backdropTexture.hideFlags = HideFlags.DontSave;

            for (int y = 0; y < 8; ++y) for (int x = 0; x < 8; ++x) backdropTexture.SetPixel(x, y, c1);
            for (int y = 8; y < 16; ++y) for (int x = 0; x < 8; ++x) backdropTexture.SetPixel(x, y, c0);
            for (int y = 0; y < 8; ++y) for (int x = 8; x < 16; ++x) backdropTexture.SetPixel(x, y, c0);
            for (int y = 8; y < 16; ++y) for (int x = 8; x < 16; ++x) backdropTexture.SetPixel(x, y, c1);

            backdropTexture.Apply();
            backdropTexture.filterMode = FilterMode.Point;
        }
    }
}