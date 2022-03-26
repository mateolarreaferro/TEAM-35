using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaypointDesigner))]
public class IWaypoint : MonoBehaviour
{
    IPhysicallyFollow follower;
    public enum Waypoint { Start, End }
    public Waypoint setWaypoint;
    Waypoint _currentWaypoint;

    public Vector3 startPos;
    public Vector3 startRot;

    public Vector3 endPos;
    public Vector3 endRot;
    // Start is called before the first frame update
    void Start()
    {
        follower = gameObject.GetComponent<IPhysicallyFollow>();
        //follower.followObject = new GameObject("Target");
        follower.followObject.transform.position = startPos;
        follower.followObject.transform.rotation = Quaternion.Euler(startRot);
        StartManager.Instance.wayPointers.Add(this);
    }

  

    private void OnDestroy()
    {
        StartManager.Instance.wayPointers.Remove(this);

    }

    // Update is called once per frame
    void Update()
    {
        if(setWaypoint != _currentWaypoint)
        {
            
            if (setWaypoint == Waypoint.Start)
            {
                follower.followObject.transform.position = startPos;
                follower.followObject.transform.rotation = Quaternion.Euler(startRot);
            }
            else if(setWaypoint == Waypoint.End)
            {
                follower.followObject.transform.position = endPos;
                follower.followObject.transform.rotation = Quaternion.Euler(endRot);

            }
            else
            {
                Debug.Log("WTF IS THIS BRO");
            }

            setWaypoint = _currentWaypoint;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(startPos, .3f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(endPos, .3f);
    }
}
