using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AddMeshColldier 
{
    [MenuItem("Tools/AddMeshCollider %#5")]
    public static void AddMeshColldierToModel()
    {
        foreach (var item in Selection.gameObjects)
        {
            foreach (Transform itemTransform in item.GetComponentsInChildren<Transform>())
            {
                if (!itemTransform.name.StartsWith("Collider_"))
                {
                    continue;
                }
                if (itemTransform.GetComponent<MeshRenderer>() == null)
                {
                    continue;
                }
                if (itemTransform.GetComponent<MeshCollider>() != null)
                {
                 var collider= itemTransform.gameObject.AddComponent<MeshCollider>();
                collider.convex = true;
               }
               GameObject.DestroyImmediate(itemTransform.GetComponent<MeshRenderer>());
               GameObject.DestroyImmediate(itemTransform.GetComponent<MeshFilter>());

            }
        }
     }
}
