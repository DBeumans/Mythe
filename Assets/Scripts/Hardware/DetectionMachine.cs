using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

/// <summary>
/// enum with type of vr hardware.
/// </summary>
public enum CameraID
{
	Oculus,
	Mouse

}

public class DetectionMachine : MonoBehaviour {

    /// <summary>
    ///
    /// </summary>
	private readonly Dictionary<CameraID, HardwareState> cameraStates = new Dictionary<CameraID, HardwareState>();

    /// <summary>
    /// Reference to the Hardware State script.
    /// </summary>
	private HardwareState currentState;

    /// <summary>
    /// 
    /// </summary>
	void Start()
	{
		AddState (CameraID.Mouse, GetComponent<CameraMouseMovement> ());
		AddState (CameraID.Oculus, GetComponent<CameraOculusMovement> ());

		checkHardware ();
	}

    /// <summary>
    /// 
    /// </summary>
	void Update () {
		if(currentState != null){
			currentState.Reason();
			currentState.Act();
		}

	}
		
    /// <summary>
    /// 
    /// </summary>
    /// <param name="stateID"></param>
	public void SetState(CameraID stateID) {

		if(!cameraStates.ContainsKey(stateID))
			return;

		if(currentState != null)
			currentState.Leave();

		currentState = cameraStates[stateID];

		currentState.Enter();
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stateID"></param>
    /// <param name="state"></param>
	public void AddState(CameraID stateID, HardwareState state) {
		cameraStates.Add( stateID, state );
	}

    /// <summary>
    /// Checks which hardware is present and will use its own camera script.
    /// </summary>
	private void checkHardware() 
	{
		if (!VRDevice.isPresent) 
		{
			// mouse
			SetState(CameraID.Mouse);
			return;
		}
		SetState (CameraID.Oculus);		
	}
}
