using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipDirectionTest : MonoBehaviour {

    public float shipSpeed = 5f;
    public float hullHealth = 100;

    public List<Transform> idleWaypoints;
    public List<Transform> dockingWaypoints;
    public List<Transform> undockingWaypoints;
    public List<Transform> exitWaypoints;



    void Start()
    {

    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime);	
	}
}
