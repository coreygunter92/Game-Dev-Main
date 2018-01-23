using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipDirectionTest : MonoBehaviour {
    public GameObject gameManager;
    public enum SHIPSTATES { ENTRANCE, IDLE, DOCKING, UNDOCKING, EXIT };

    public SHIPSTATES executeState(SHIPSTATES state)
    {
        if (state == SHIPSTATES.ENTRANCE)
        {
           
            if (currentWaypoint != entranceWaypoints.Length)
            {
                Vector3 startPosition = entranceWaypoints[currentWaypoint].transform.position;
                Vector3 endPosition = entranceWaypoints[currentWaypoint + 1].transform.position;

                float pathLength = Vector3.Distance(startPosition, endPosition);
                float totalTimeForPath = pathLength / shipSpeed;
                float currentTimeOnPath = Time.time - lastWaypointSwitchTime;

                gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

                if (gameObject.transform.position.Equals(endPosition))
                {

                    if (currentWaypoint < entranceWaypoints.Length - 2)
                    {

                        currentWaypoint++;
                        lastWaypointSwitchTime = Time.time;


                    }
                    
                }

                transform.LookAt(endPosition);
            }
            else
            {
                previousState = SHIPSTATES.ENTRANCE;
                currentState = SHIPSTATES.IDLE;
            }
            
        }
        else if (state == SHIPSTATES.IDLE)
        {

        }
        else if (state == SHIPSTATES.DOCKING)
        {

        }
        else if (state == SHIPSTATES.UNDOCKING)
        {

        }
        else if (state == SHIPSTATES.EXIT)
        {

        }

        return state;
    }

    public GameObject[] entranceWaypoints;
    public GameObject[] idleWaypoints;
    public GameObject[] dockingWaypoints1;
    public GameObject[] dockingWaypoints2;
    public GameObject[] undockingWaypoints1;
    public GameObject[] undockingWaypoints2;
    public GameObject[] exitWaypoints;
    public int previousWaypoint;
    public int currentWaypoint;
    public int nextWaypoint;
    public SHIPSTATES previousState;
    public SHIPSTATES currentState;

    public Vector3 Velocity;
    public Vector3 MoveDirection;
    public Vector3 Target;
    public Vector3 endPointDirection;
    private float lastWaypointSwitchTime;
    public float shipSpeed = 5f;
    public float hullHealth = 100;

    void TranslateWaypoints()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        entranceWaypoints = gameManager.GetComponent<Architect>().entranceWaypoints;
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
        
        currentState = SHIPSTATES.ENTRANCE;
        currentWaypoint = 0;
        lastWaypointSwitchTime = Time.time;
       

        //roll random values for ship
    }

	// Update is called once per frame
	void Update () {
        executeState(currentState);

        Debug.Log(currentState);
        Debug.Log(currentWaypoint);
	}
}
