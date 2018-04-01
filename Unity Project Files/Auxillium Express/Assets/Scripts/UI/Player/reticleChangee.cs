using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class reticleChangee : MonoBehaviour
{

    public Camera cam;
    Image m_Image;
    public Sprite idleAim;
    public Sprite clickableObject;

    [SerializeField]
    float interactingDistance = 1f;
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        m_Image = GameObject.FindGameObjectWithTag("Reticle").GetComponent<Image>();
    }

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
            float dist = Vector3.Distance(transform.position, hit.transform.position);

            if (hit.collider.tag == "Clickable" && dist < 2) 
            {
                m_Image.sprite = clickableObject;
            }
            else
            {
                m_Image.sprite = idleAim;
            }

            Debug.Log(dist);
        }
        else
        {
            
        }

        
    }
  
}