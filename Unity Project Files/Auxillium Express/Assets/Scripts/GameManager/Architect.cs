using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Architect : MonoBehaviour {

    public GameObject[] entranceWaypoints;
    public GameObject[] idleWaypoints;
    public GameObject[] dockingWaypoints1;
    public GameObject[] dockingWaypoints2;
    public GameObject[] undockingWaypoints1;
    public GameObject[] undockingWaypoints2;
    public GameObject[] exitWaypoints;
    public GameObject pauseMenu;
    public Transform shipSpawn;

    [SerializeField]
    float spawnFrequency = 7f;
    [SerializeField]
    float spawnVarianceX;
    [SerializeField]
    float spawnVarianceY;
    [SerializeField]
    float spawnVarianceZ;
    Vector3 spawnVariance;
    public int maxActiveShips = 3;
    public int activeShips;
    public GameObject shipPrefab;
    public float timeSinceLastSpawned;

    void SetupWaypoints()
    {
        //entranceWaypoints = GameObject.FindGameObjectsWithTag("entranceWaypoints").OrderBy(go => go.name).ToArray();
        //idleWaypoints = GameObject.FindGameObjectsWithTag("idleWaypoint").OrderBy(go => go.name).ToArray();
        dockingWaypoints1 = GameObject.FindGameObjectsWithTag("dockingWaypoint1").OrderBy(go => go.name).ToArray();                           //self explanatory Sets up waypoints
        dockingWaypoints2 = GameObject.FindGameObjectsWithTag("dockingWaypoint2").OrderBy(go => go.name).ToArray();
        undockingWaypoints1 = GameObject.FindGameObjectsWithTag("dockingWaypoint1").OrderBy(go => go.name).ToArray();
        System.Array.Reverse(undockingWaypoints1);                                                                                            //reverses docking waypoints for exit waypoints
        undockingWaypoints2 = GameObject.FindGameObjectsWithTag("dockingWaypoint2").OrderBy(go => go.name).ToArray();
        System.Array.Reverse(undockingWaypoints2);
        //exitWaypoints = GameObject.FindGameObjectsWithTag("exitWaypoint").OrderBy(go => go.name).ToArray();
        shipSpawn = GameObject.FindGameObjectWithTag("shipSpawn").transform;
        pauseMenu = GameObject.FindGameObjectWithTag("MainMenu");
    }

    void Awake()
    {
        SetupWaypoints();
    }

    void Start()
    {
        pauseMenu.SetActive(false);
        activeShips = GameObject.FindGameObjectsWithTag("NPCShip").Length;
        timeSinceLastSpawned = Time.time;
    }


    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        //if there are not maximum number of ships on the field
        if(activeShips < maxActiveShips && timeSinceLastSpawned >= spawnFrequency)
        {
            
            GameObject damagedShip = Instantiate(shipPrefab, shipSpawn.position + spawnVariance, shipSpawn.rotation);
            timeSinceLastSpawned = 0;
            activeShips++;
            spawnVarianceX = Random.Range(5f, 20f);
            spawnVarianceY = Random.Range(5f, 20f);
            spawnVarianceZ = Random.Range(5f, 20f);
            spawnVariance = new Vector3(spawnVarianceX, spawnVarianceY, spawnVarianceZ);
            
        }
        else
        {

        }


        
        //and i haven't spawned a ship recently
        //spawn a ship with random stats
        //at the spawn marker

       // Debug.Log(activeShips);
        //Debug.Log(timeSinceLastSpawned);
    }
}
