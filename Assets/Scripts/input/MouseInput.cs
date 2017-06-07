using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseInput : MonoBehaviour
{
    private LookingStateMachine lookStateMachine;

    private InputBehaviour input;

    private int sceneIndex;

    private void Start()
    {
        lookStateMachine = GetComponent<LookingStateMachine>();
        input = GetComponent<InputBehaviour>();

        if (input == null)
            Debug.LogError("No Inputbehaviour script attached to the player!");

        Scene currentScene = SceneManager.GetActiveScene();
        sceneIndex = currentScene.buildIndex;

    }

    private void Update()
    {
        if (input.GetController_x || input.GetMouseLeft)
        {
                lookStateMachine.doAction1();
        }

        if (input.GetController_b || input.GetMouseRight)
        {
            if(sceneIndex != 0) 
                lookStateMachine.doAction2();
        }
    }
}
