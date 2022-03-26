using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPhysicallyFollow : MonoBehaviour
{
    public bool rotateFollow = true;
    public bool moveFollow = true;

    public GameObject followObject;
    public float followSpeed = 1;
    public float rotateSpeed = 1;
    Transform _followTarget;
    Transform _trans;
    public Rigidbody _body;


    private void Awake()
    {
        _trans = transform;
        followObject = new GameObject("Target");
        _followTarget = followObject.transform;
        _followTarget.transform.position = _trans.position;
        _followTarget.transform.rotation = _trans.rotation;
    }
    void Start()
    {
        
        
        _body = GetComponent<Rigidbody>();
        //_body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        //_body.mass = 20f;

        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        PhysicsMove();
    }

    private void PhysicsMove()
    {
        if (moveFollow)
        {
            var distance = Vector3.Distance(_followTarget.position, _trans.position);
            _body.velocity = (_followTarget.position - _trans.position).normalized * (followSpeed * distance);
        }

        if (rotateFollow)
        {
            var rot = _followTarget.rotation * Quaternion.Inverse(_body.rotation);
            rot.ToAngleAxis(out float angle, out Vector3 axis);
            _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
        }
    }
}
