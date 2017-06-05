using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLogic : MonoBehaviour {

    /// <summary>
    /// Reference to the LookingStateMachine script.
    /// </summary>
    private LookingStateMachine lookStateMachine;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);
        lookStateMachine = GetComponent<LookingStateMachine>();
        lookStateMachine.doAction2();
    }

}
