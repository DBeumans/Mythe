using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private LookingStateMachine lookStateMachine;

    private bool mouse0Clicked = false;

    private void Start()
    {
        lookStateMachine = GetComponent<LookingStateMachine>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(mouse0Clicked == false)
            {
                lookStateMachine.doAction();
                mouse0Clicked = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            mouse0Clicked = false;
        }
    }
}
