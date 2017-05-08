using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLogic : MonoBehaviour {

    private LookingStateMachine lookStateMachine;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);
        lookStateMachine = GetComponent<LookingStateMachine>();
        lookStateMachine.doAction2();
    }

}
