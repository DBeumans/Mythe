using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseMovement : HardwareState {

	private Camera myCamera;
	private float lookSensitivity = 5;
	public float GetLookSensivity{ get { return lookSensitivity; } }
	private float xRotation;
	private float yRotation;

	public override void Enter()
	{
		myCamera = GetComponent<Camera> ();
		Debug.Log ("MOUSE");
	}

	public override void Act()
	{
		xRotation -= Input.GetAxis ("Mouse Y") * lookSensitivity;
		yRotation += Input.GetAxis ("Mouse X") * lookSensitivity;
		transform.rotation = Quaternion.Euler (xRotation, yRotation, 0);
	}

	public override void Reason(){
	}

}
