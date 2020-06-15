using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static class UITextHelper
{
    public static void SetTextSizeFitter(Transform target, string text, float min)
    {
        Image image = target.GetComponentInChildren<Image>();
        TMPro.TMP_Text tmp_text = target.GetComponentInChildren<TMPro.TMP_Text>();
        tmp_text.text = text;
        float delta = image.rectTransform.sizeDelta.y;
        float height = tmp_text.preferredHeight + delta / 2;
        if (height < min)
        {
            height = min;
        }
        image.rectTransform.sizeDelta = new Vector2(image.rectTransform.sizeDelta.x, height);
    }

    public static void SetTextSizeFitterHorizontal(Transform target, string text, float min)
    {
        Image image = target.GetComponentInChildren<Image>();
        TMPro.TMP_Text tmp_text = target.GetComponentInChildren<TMPro.TMP_Text>();
        tmp_text.text = text;
        float weight = tmp_text.preferredWidth + 50;
        if (weight < min)
        {
            weight = min;
        }
        image.rectTransform.sizeDelta = new Vector2(weight, image.rectTransform.sizeDelta.y);
    }
}
