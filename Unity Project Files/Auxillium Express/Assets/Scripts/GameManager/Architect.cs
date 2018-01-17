using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Architect : MonoBehaviour {

    public GameObject[] idleWaypoints;
    public GameObject[] dockingWaypoints1;
    public GameObject[] dockingWaypoints2;
    public GameObject[] undockingWaypoints1;
    public GameObject[] undockingWaypoints2;
    public GameObject[] exitWaypoints;

    void SetupWaypoints()
    {
        idleWaypoints = GameObject.FindGameObjectsWithTag("idleWaypoint").OrderBy(go => go.name).ToArray();
        dockingWaypoints1 = GameObject.FindGameObjectsWithTag("dockingWaypoint1").OrderBy(go => go.name).ToArray();                           //self explanatory Sets up waypoints
        dockingWaypoints2 = GameObject.FindGameObjectsWithTag("dockingWaypoint2").OrderBy(go => go.name).ToArray();
        undockingWaypoints1 = GameObject.FindGameObjectsWithTag("dockingWaypoint1").OrderBy(go => go.name).ToArray();
        System.Array.Reverse(undockingWaypoints1);                                                                                            //reverses docking waypoints for exit waypoints
        undockingWaypoints2 = GameObject.FindGameObjectsWithTag("dockingWaypoint2").OrderBy(go => go.name).ToArray();
        System.Array.Reverse(undockingWaypoints2);
        exitWaypoints = GameObject.FindGameObjectsWithTag("exitWaypoint").OrderBy(go => go.name).ToArray();
    }

    void Awake()
    {
        SetupWaypoints();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
