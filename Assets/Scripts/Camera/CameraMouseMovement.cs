using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseMovement : MonoBehaviour {

	private Camera myCamera;
	private float lookSensitivity = 5;
	public float GetLookSensivity{ get { return lookSensitivity; } }
	private float xRotation;
	private float yRotation;
	private void Start()
	{
		myCamera = GetComponent<Camera> ();
	}

	private void Update()
	{
		xRotation -= Input.GetAxis ("Mouse Y") * lookSensitivity;
		yRotation += Input.GetAxis ("Mouse X") * lookSensitivity;
		transform.rotation = Quaternion.Euler (xRotation, yRotation, 0);
	}

}
