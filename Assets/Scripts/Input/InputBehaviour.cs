using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour {

	private bool mouseLeft;
	public bool GetMouseLeft{ get { return mouseLeft; } }

	private bool mouseRight;
	public bool GetMouseRight { get { return mouseRight; } }

	private KeyCode keycodeMouseLeft;
	private KeyCode keycodeMouseRight;

	private void Update()
	{
		keycodeMouseLeft = KeyCode.Mouse0;
		keycodeMouseRight = KeyCode.Mouse1;
		 	
		mouseLeft = Input.GetKeyDown (keycodeMouseLeft);
		mouseRight = Input.GetKeyDown (keycodeMouseRight);
	}

}
