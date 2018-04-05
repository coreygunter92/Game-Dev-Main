using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupObject : MonoBehaviour {


    public float interactingDistance;
    reticleChangee playerReticle;
    Rigidbody rigid;
	// Use this for initialization
	void Start () {
        playerReticle = GameObject.Find("Player").GetComponent<reticleChangee>();
        interactingDistance = playerReticle.interactingDistance;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, -Vector3.up, out hit, interactingDistance))
            {
                Debug.Log("I shot a raycast");
                Debug.Log(hit.distance);
                if(hit.collider.tag == "pickupable")
                {
                    if (hit.distance < 3)
                    {
                        rigid = hit.transform.gameObject.GetComponent<Rigidbody>();
                        rigid.MovePosition(transform.position + transform.forward * interactingDistance);
                        Debug.Log("You hit something!");
                    }
                    
                }
            }

        }

	}
}
