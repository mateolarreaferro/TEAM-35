using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotateSpeed;
    Transform _trans;
    // Start is called before the first frame update
    void Start()
    {
        _trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _trans.Rotate(Vector3.forward * rotateSpeed);
    }
}
