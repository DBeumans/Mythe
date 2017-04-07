using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private LookingStateMachine lookStateMachine;

    private void Start()
    {
        lookStateMachine = GetComponent<LookingStateMachine>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                lookStateMachine.doAction();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            lookStateMachine.stopAction();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

        }
    }
}
