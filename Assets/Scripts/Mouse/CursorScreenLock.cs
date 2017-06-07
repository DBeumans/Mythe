using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScreenLock : MonoBehaviour {

    /// <summary>
    /// Reference to the Input Behaviour script.
    /// </summary>
    private InputBehaviour input;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        input = GameObject.FindObjectOfType<InputBehaviour>();

        SetCursorState(CursorLockMode.Locked);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="state"></param>
	public void SetCursorState(CursorLockMode state) 
	{
		Cursor.lockState = state;
		Cursor.visible = (CursorLockMode.Locked != state);
	}

    /// <summary>
    /// Checks if key F or spacebar is pressed and will lock/unlock the cursor.
    /// </summary>
	void Update()
	{
		if(input.GetKeySpace)
			SetCursorState(CursorLockMode.Locked );

		if (input.GetKeyF)
			SetCursorState(CursorLockMode.None) ;
	}
}
