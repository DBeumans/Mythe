//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeingObject : MonoBehaviour
{
    [SerializeField]
    private Material lineMaterial;

    [SerializeField]
    private int viewDistance = 50;

    private RaycastHit seeing;
    private Ray raydirection;

    public GameObject getCurrentSeeingObject()
    {
        raydirection = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward) * 10) , Color.green);

        //if you hit something
        if (Physics.Raycast(raydirection, out seeing, viewDistance))
        {
            //write anyting what you want to do with the things tou hit here
            if (seeing.collider.tag != "Untagged" && seeing.collider.tag != "maincamera")
            {
                return seeing.transform.gameObject;
            }
        }

        return null;
    }

    void OnPostRender()
    {
        if(lineMaterial == null)
        {
            Debug.LogError("no material given");
        }
        else
        {
            // Set your materials
            GL.PushMatrix();
            lineMaterial.SetPass(1);
            // Draw your stuff
            GL.PopMatrix();
        }      
    }
}
