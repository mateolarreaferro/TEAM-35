using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWaitFollow : MonoBehaviour
{
    public float floatOffTime = 0f;
    public bool useGravWhenFloat = false;

    float timer;
    //bool entered = false;
    bool exited = false;
    public bool singleFire = false;

    Rigidbody _rigBod;
    IPhysicallyFollow _follower;
    bool usedGravity;
    bool usedRotate;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        _rigBod = GetComponent<Rigidbody>();
        _follower = GetComponent<IPhysicallyFollow>();
        usedGravity = _rigBod.useGravity;
        usedRotate = _follower.rotateFollow;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand"))
        {
            exited = false;
            FloatStart();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("hand"))
        {
            if (!exited)
            {
                exited = true;
                timer = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!exited) return; 

        timer += Time.deltaTime;
        if(timer >= floatOffTime)
        {
            FloatStop();
            exited = false;
        }
    }

    void FloatStart()
    {
        //usedGravity = _rigBod.useGravity;
        _rigBod.useGravity = useGravWhenFloat;
        _follower.moveFollow = false;
        //usedRotate = _follower.rotateFollow;
        _follower.rotateFollow = false;

        if (singleFire) exited = true;
    }

    void FloatStop()
    {
        _rigBod.useGravity = usedGravity;
        _follower.moveFollow = true;
        _follower.rotateFollow = usedRotate;
    }
}
