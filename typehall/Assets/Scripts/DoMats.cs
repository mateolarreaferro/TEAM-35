using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DoMats : MonoBehaviour
{
    public Material mat;
    public bool addMats;

    void Start()
    {
        enabled = false;
    }

    void Update()
    {
        if (addMats) {
            foreach (var mr in GetComponentsInChildren<MeshRenderer>())
            {
                mr.material = mat;
            }
            addMats = false;
        }
    }
}
