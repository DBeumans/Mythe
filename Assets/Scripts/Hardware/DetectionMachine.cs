using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public enum StateID
{
	Oculus,
	Mouse

}

public class DetectionMachine : MonoBehaviour {


	private readonly Dictionary<StateID, HardwareState> cameraStates = new Dictionary<StateID, HardwareState>();

	private HardwareState currentState;

	void Start()
	{
		AddState (StateID.Mouse, GetComponent<CameraMouseMovement> ());
		AddState (StateID.Oculus, GetComponent<CameraOculusMovement> ());

		checkHardware ();
	}

	void Update () {
		if(currentState != null){
			currentState.Reason();
			currentState.Act();
		}

	}
		
	public void SetState(StateID stateID) {

		if(!cameraStates.ContainsKey(stateID))
			return;

		if(currentState != null)
			currentState.Leave();

		currentState = cameraStates[stateID];

		currentState.Enter();
	}

	public void AddState(StateID stateID, HardwareState state) {
		cameraStates.Add( stateID, state );
	}

	private void checkHardware() 
	{
		if (!VRDevice.isPresent) 
		{
			// mouse
			SetState(StateID.Mouse);
			return;
		}
		SetState (StateID.Oculus);		
	}
}
