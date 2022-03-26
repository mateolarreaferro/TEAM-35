using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public static StartManager Instance;
    public float secondsToWait = 3f;

    public List<IWaypoint> wayPointers;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAtZero());
    }

    IEnumerator StartAtZero()
    {
        yield return new WaitForSeconds(secondsToWait);

        foreach(var w in wayPointers)
        {
            w.setWaypoint = IWaypoint.Waypoint.End;
        }
        
    }


}
