using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverUIDescription : MonoBehaviour {

    public Texture2D textureToDisplay;
    reticleChangee playerReticle;
    float dist;
    float interactingDistance;
    bool mouseOver;
    

	// Use this for initialization
	void Start () {
        playerReticle = GameObject.Find("Player").GetComponent<reticleChangee>();
        interactingDistance = playerReticle.interactingDistance;
        
	}
	
	// Update is called once per frame
	void Update () {
        dist = playerReticle.externalDist;
        
        //Debug.Log(interactingDistance);
	}

    void OnMouseOver()
    {
        mouseOver = true;
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }

    void OnGUI()
    {
        if (mouseOver == true && dist < interactingDistance)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 25, 100, 100), textureToDisplay);
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 25, 100, 50), "Laptop Terminal");
        }
    }
}
