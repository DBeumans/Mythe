using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour {

	private bool mouseLeft;
	public bool GetMouseLeft{ get { return mouseLeft; } }

	private bool mouseRight;
	public bool GetMouseRight { get { return mouseRight; } }

    private bool controller_x;
    public bool GetController_x { get { return controller_x; } }

    private bool controller_y;
    public bool GetController_y { get { return controller_y; } }

    private KeyCode keycodeMouseLeft;
	private KeyCode keycodeMouseRight;

    private KeyCode keycodeController_x;
    private KeyCode keycodeController_y;

    private void Update()
	{
		keycodeMouseLeft = KeyCode.Mouse0;
		keycodeMouseRight = KeyCode.Mouse1;

        keycodeController_x = KeyCode.Joystick1Button2;
        keycodeController_y = KeyCode.Joystick1Button3;
		 	
		mouseLeft = Input.GetKeyDown (keycodeMouseLeft);
		mouseRight = Input.GetKeyDown (keycodeMouseRight);

        controller_x = Input.GetKeyDown(keycodeController_x);
        controller_y = Input.GetKeyDown(keycodeController_y);
	}

}
