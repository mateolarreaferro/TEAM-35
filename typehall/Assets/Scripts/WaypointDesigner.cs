using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WaypointDesigner : MonoBehaviour
{
    public bool jumpToStart;
    public bool bakeStart;

    public bool jumpToEnd;
    public bool bakeEnd;


    IWaypoint _waypointer;
    Transform _trans;
    void Start()
    {
        _waypointer = GetComponent<IWaypoint>();
        _trans = transform;
        enabled = false;
    }

// Update is called once per frame
void Update()
    {
        if (jumpToStart)
        {
            _trans.position = _waypointer.startPos;
            _trans.rotation = Quaternion.Euler(_waypointer.startRot);
            jumpToStart = false;
        }
        if (jumpToEnd)
        {
            _trans.position = _waypointer.endPos;
            _trans.rotation = Quaternion.Euler(_waypointer.endRot);
            jumpToEnd = false;
        }

        if (bakeStart)
        {
            _waypointer.startPos = _trans.position;
            _waypointer.startRot = _trans.eulerAngles;
            bakeStart = false;
        }

        if (bakeEnd)
        {
            _waypointer.endPos = _trans.position;
            _waypointer.endRot = _trans.eulerAngles;
            bakeEnd = false;
        }
    }
}
