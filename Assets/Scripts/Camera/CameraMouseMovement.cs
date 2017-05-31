using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseMovement : HardwareState {

    /// <summary>
    /// Reference to the Camera component.
    /// </summary>
	private Camera myCamera;

    /// <summary>
    /// Mouse sensitivity speed.
    /// </summary>
	private float lookSensitivity = 5;

    /// <summary>
    /// Getter for the mouse sensitivity so other script can read this variable.
    /// </summary>
	public float GetLookSensivity{ get { return lookSensitivity; } }

    /// <summary>
    /// 
    /// </summary>
	private float xRotation;

    /// <summary>
    /// 
    /// </summary>
	private float yRotation;

    /// <summary>
    /// This will run first when this script activates
    /// </summary>
	public override void Enter()
	{
		myCamera = GetComponent<Camera> ();
	}

    /// <summary>
    /// 
    /// </summary>
	public override void Act()
	{
		xRotation -= Input.GetAxis ("Mouse Y") * lookSensitivity;
		yRotation += Input.GetAxis ("Mouse X") * lookSensitivity;
		transform.rotation = Quaternion.Euler (xRotation, yRotation, 0);

	}

    /// <summary>
    /// 
    /// </summary>
	public override void Reason(){
	}

}
