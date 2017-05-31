using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]private float _amountTofill = 1f;

    /// <summary>
    /// Reference to the image that will be displayed.
    /// </summary>
    [SerializeField]private Image _image;

    /// <summary>
    /// To test the game faster so you wont have to wait for the screen fade out.
    /// </summary>
    [SerializeField]private bool debugMode = false;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        if(debugMode)
        {
            ScreenFadeOut();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void ScreenFadeOut()
    {
        _image.CrossFadeAlpha(0.0f, _amountTofill, true);
    }

    /// <summary>
    /// 
    /// </summary>
    public void ScreenFadeIn()
    {
        _image.CrossFadeAlpha(1.0f, _amountTofill, true);
    }
}

