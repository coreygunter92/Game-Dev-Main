using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class reticleChangee : MonoBehaviour
{
    GameObject reticle;
    public Camera cam;
    Image m_Image;
    public Sprite idleAim;
    public Sprite clickableObject;
    public float externalDist;
    [SerializeField]
    public float m_ImageSize;

    void Awake()
    {
        interactingDistance = 2;
        m_ImageSize = 0.2f;
    }
    
    public float interactingDistance;
    void Start()
    {
        
        reticle = GameObject.FindGameObjectWithTag("Reticle");
        
        cam = GetComponentInChildren<Camera>();
        m_Image = GameObject.FindGameObjectWithTag("Reticle").GetComponent<Image>();
    }

    void Update()
    {
        reticle.transform.localScale = new Vector3(m_ImageSize, m_ImageSize);
        Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
            float dist = Vector3.Distance(transform.position, hit.transform.position);
            externalDist = dist;
            if (hit.collider.tag == "Clickable" && dist < interactingDistance) 
            {
                m_Image.sprite = clickableObject;
            }
            else
            {
                m_Image.sprite = idleAim;
            }

            //Debug.Log(dist);
        }
        else
        {
            
        }

        //Debug.Log(interactingDistance + " from reticleChange");
    }
  
}