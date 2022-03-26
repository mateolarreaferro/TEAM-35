using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CopyScriptsAcrossSiblings : MonoBehaviour
{
    void Start()
    {
        
        var children = GetComponentsInChildren<BoxCollider>();

        foreach (var c in children)
        {
            //Debug.Log("oo");
            //return;
            var b = c.gameObject.AddComponent<BoxCollider>();
            //c.size *= .9f;
            b.isTrigger = true;
            b.size = c.size * 1.5f;

        }

        DestroyImmediate(this);
    }

}
