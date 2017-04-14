using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScreenLock : MonoBehaviour {

	public void SetCursorState(CursorLockMode state) 
	{
		Cursor.lockState = state;
		Cursor.visible = (CursorLockMode.Locked != state);
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.Space))
			SetCursorState(CursorLockMode.Locked );

		if (Input.GetKey (KeyCode.F))
			SetCursorState(CursorLockMode.None) ;
	}

}
