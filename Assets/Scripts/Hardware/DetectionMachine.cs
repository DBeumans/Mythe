using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public enum CameraID
{
	Oculus,
	Mouse

}

public class DetectionMachine : MonoBehaviour {


	private readonly Dictionary<CameraID, HardwareState> cameraStates = new Dictionary<CameraID, HardwareState>();

	private HardwareState currentState;

	void Start()
	{
		AddState (CameraID.Mouse, GetComponent<CameraMouseMovement> ());
		AddState (CameraID.Oculus, GetComponent<CameraOculusMovement> ());

		checkHardware ();
	}

	void Update () {
		if(currentState != null){
			currentState.Reason();
			currentState.Act();
		}

	}
		
	public void SetState(CameraID stateID) {

		if(!cameraStates.ContainsKey(stateID))
			return;

		if(currentState != null)
			currentState.Leave();

		currentState = cameraStates[stateID];

		currentState.Enter();
	}

	public void AddState(CameraID stateID, HardwareState state) {
		cameraStates.Add( stateID, state );
	}

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
