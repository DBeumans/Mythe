﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

    public void SwitchLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
