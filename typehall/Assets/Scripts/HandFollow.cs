using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HandFollow : MonoBehaviour
{
      

    public GameObject followObject;
    public float followSpeed = 1;
    public float rotateSpeed = 1;
    Transform _followTarget;
    Transform _trans;
    public Rigidbody _body;
    // Start is called before the first frame update
    void Start()
    {

        _trans = transform;
        _followTarget = followObject.transform;
        //_trans.position = _followTarget.transform.position;
        //_trans.rotation = _followTarget.transform.rotation;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.mass = 20f;

        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    void Update()
    {
        PhysicsMove();
    }

    private void PhysicsMove()
    {
        
            var distance = Vector3.Distance(_followTarget.position, _trans.position);
            _body.velocity = (_followTarget.position - _trans.position).normalized * (followSpeed * distance);

            var rot = _followTarget.rotation * Quaternion.Inverse(_body.rotation);
            rot.ToAngleAxis(out float angle, out Vector3 axis);
            _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
        
    }
}
