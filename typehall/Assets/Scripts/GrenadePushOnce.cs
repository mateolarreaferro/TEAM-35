using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePushOnce : MonoBehaviour
{
    public float force =1;
    public float radius =1;
    public Vector3 grenadePos;

  
    Rigidbody[] _rigBods;


    void Start()
    {
        _rigBods = GetComponentsInChildren<Rigidbody>();
    }

    public void Fire()
    {

        foreach (var r in _rigBods)
        {
            r.AddExplosionForce(force, grenadePos, radius);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand"))
        {
            Fire();

        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(grenadePos, radius);
    }

}
