using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipDirectionTest : MonoBehaviour {
    public GameObject gameManager;

    public float shipSpeed = 5f;
    public float hullHealth = 100;

    public GameObject[] idleWaypoints;
    public GameObject[] dockingWaypoints1;
    public GameObject[] dockingWaypoints2;
    public GameObject[] undockingWaypoints1;
    public GameObject[] undockingWaypoints2;
    public GameObject[] exitWaypoints;

    void TranslateWaypoints()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        idleWaypoints = gameManager.GetComponent<Architect>().idleWaypoints;
        dockingWaypoints1 = gameManager.GetComponent<Architect>().dockingWaypoints1;
        dockingWaypoints2 = gameManager.GetComponent<Architect>().dockingWaypoints2;
        undockingWaypoints1 = gameManager.GetComponent<Architect>().undockingWaypoints1;
        undockingWaypoints2 = gameManager.GetComponent<Architect>().undockingWaypoints2;
        exitWaypoints = gameManager.GetComponent<Architect>().exitWaypoints;        
    }

    void Awake()
    {
        TranslateWaypoints();
    }

    void Start()
    {

    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime);	
	}
}
