using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour {

    /// <summary>
    /// Boolean for the mouse Left press state.
    /// </summary>
	private bool mouseLeft;

    /// <summary>
    /// Getter for the mouse Left press state, use this to check if left mouse is pressed.
    /// </summary>
	public bool GetMouseLeft{ get { return mouseLeft; } }

    /// <summary>
    /// Boolean for the mouse right press state.
    /// </summary>
	private bool mouseRight;
    /// <summary>
    /// Fetter for the mouse Right press statem use this to check if right mouse is pressed.
    /// </summary>
	public bool GetMouseRight { get { return mouseRight; } }

    /// <summary>
    /// Boolean for the Xbox X button state.
    /// </summary>
    private bool controller_x;

    /// <summary>
    /// Getter for the Xbox X button state, use this to check if Xbox X is pressed.
    /// </summary>
    public bool GetController_x { get { return controller_x; } }

    /// <summary>
    /// Boolean for the Xbox Y button state.
    /// </summary>
    private bool controller_b;

    /// <summary>
    /// Getter for the Xbox Y button state, use this to check if Xbox y is pressed.
    /// </summary>
    public bool GetController_b { get { return controller_b; } }

    /// <summary>
    /// Boolean for the spacebar state.
    /// </summary>
    private bool keySpace;

    /// <summary>
    /// Getter for the spacebar state, use this to check if spacebar is pressed.
    /// </summary>
    public bool GetKeySpace { get { return keySpace; } }

    /// <summary>
    /// Boolean for the key F state.
    /// </summary>
    private bool keyF;
    
    /// <summary>
    /// Getter for the key F state, use this to check if key F is pressed.
    /// </summary>
    public bool GetKeyF { get { return keyF; } }

    /// <summary>
    /// 
    /// </summary>
    private KeyCode keycodeMouseLeft;

    /// <summary>
    /// 
    /// </summary>
	private KeyCode keycodeMouseRight;

    /// <summary>
    /// 
    /// </summary>
    private KeyCode keycodeController_x;

    /// <summary>
    /// 
    /// </summary>
    private KeyCode keycodeController_b;

    /// <summary>
    /// 
    /// </summary>
    private KeyCode keycodeSpacebar;

    /// <summary>
    /// 
    /// </summary>
    private KeyCode keycodeF;

    /// <summary>
    /// Updates everytime to check for key and button press states.
    /// </summary>
    private void Update()
	{
		keycodeMouseLeft = KeyCode.Mouse0;
		keycodeMouseRight = KeyCode.Mouse1;

        keycodeController_x = KeyCode.Joystick1Button2;
        keycodeController_b = KeyCode.Joystick1Button1;

        keycodeSpacebar = KeyCode.Space;
        keycodeF = KeyCode.F;
		 	
		mouseLeft = Input.GetKeyDown (keycodeMouseLeft);
		mouseRight = Input.GetKeyDown (keycodeMouseRight);

        controller_x = Input.GetKeyDown(keycodeController_x);
        controller_b = Input.GetKeyDown(keycodeController_b);

        keySpace = Input.GetKey(keycodeSpacebar);
        keyF = Input.GetKey(keycodeF);
	}

}
