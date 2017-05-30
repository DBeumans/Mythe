using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private LookingStateMachine lookStateMachine;

    private InputBehaviour input;

    private void Start()
    {
        lookStateMachine = GetComponent<LookingStateMachine>();
        input = GetComponent<InputBehaviour>();

        if (input == null)
            Debug.LogError("No Inputbehaviour script attached to the player!");
    }

    private void Update()
    {
        if (input.GetController_x || input.GetMouseLeft)
        {
                lookStateMachine.doAction1();
        }

        if (input.GetController_y || input.GetMouseRight)
        {
            lookStateMachine.doAction2();
        }
    }
}
