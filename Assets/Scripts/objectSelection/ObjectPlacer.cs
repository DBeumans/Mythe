using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    private GameObject cam;

    private Vector3 vec = new Vector3(0, 0, 0);

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag(Tags.mainCamera);
    }

    public void placeInfrontOfCamera(GameObject gameObj, float distance, bool heightLock = false, bool rotate = false)
    {
        Vector3 position = cam.transform.position + (cam.transform.forward * distance);

        if (heightLock == true)
        {
            float oldY = gameObj.transform.position.y;
            position = new Vector3(position.x, oldY, position.z);
        }   

        gameObj.transform.position = position;

        if (rotate)
        {
            Vector3 _direction = (cam.transform.position - gameObj.transform.position).normalized;

            Quaternion _lookRotation = Quaternion.LookRotation(_direction);

            gameObj.transform.rotation = _lookRotation;
        }
             
    }

    public void placeBack(GameObject gameObj,Vector3 position)
    {
        gameObj.transform.position = position;
    }
}
