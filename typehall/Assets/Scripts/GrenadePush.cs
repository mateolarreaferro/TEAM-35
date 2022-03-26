using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePush : MonoBehaviour
{
    public float force =1;
    public float radius =1;
    public Vector3 grenadePos;

    public bool pushOnBeat = true;
    Rigidbody[] _rigBods;
    Transform _trans;

    public float pulseInterval = 1;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rigBods = GetComponentsInChildren<Rigidbody>();
        _trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (pushOnBeat && timer >= pulseInterval)
        {
            //pushOnBeat = false;
            Fire();
            timer = 0;
        }
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
            //Debug.Log("yo");
            pushOnBeat = !pushOnBeat;

        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(grenadePos, radius);
    }

}
