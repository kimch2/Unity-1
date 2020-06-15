using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGridLayOut : MonoBehaviour
{

    public int Lenght;
    public int Height;
    public Vector2 CellSize;
    public Vector2 Space;
    public int ChildCount { get { return transform.childCount; } }
    public int Column
    {
        get
        {
            if (ItemList.Count % Lenght == 0)
            {
                return ItemList.Count / Lenght - 1;
            }
            return ItemList.Count / Lenght;
        }
    }
    public int Row
    {
        get
        {
            if (ItemList.Count % Lenght == 0)
                return Lenght - 1;
            return ItemList.Count % Lenght - 1;
        }
    }
    [HideInInspector]
    public List<RectTransform> ItemList = new List<RectTransform>();
    [HideInInspector]
    public List<float> HeightList = new List<float>();

    private void Start()
    {
        Init();
        float scale = Screen.width / 1920f;
        CellSize *= scale;
        Space *= scale;
    }

    public void Init()
    {
        for (int i = 0; i < Lenght; i++)
        {
            HeightList.Add(0);
        }
    }

    public void Add(RectTransform item)
    {
        ItemList.Add(item);
        float height = HeightList[Row] + (item.sizeDelta.y + Space.y);
        float lenght = Row * (CellSize.x + Space.x);
        Vector3 pos = new Vector3(-lenght, HeightList[Row], 0);
        item.transform.SetParent(transform);
        Tween tween = item.transform.DOMove(transform.position - pos, 0.3f);
        HeightList[Row] = height;
    }
    
     public void Remove(RectTransform rect)
    {
        if (ItemList.Contains(rect))
        {
            HeightList.Clear();
            ItemList.Remove(rect);
            List<RectTransform> draglist = new List<RectTransform>(ItemList);
            ItemList.Clear();
            Init();
            for (int i = 0; i < draglist.Count; i++)
            {
                Add(draglist[i]);
            }
        }
    }

    public void Reflash()
    {
        HeightList.Clear();
        Init();
        ItemList.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
                Add(transform.GetChild(i).GetComponent<RectTransform>());
        }
    }

    private void OnTransformChildrenChanged()
    {
        Reflash();
    }
}
