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
    /// Start fadeout at the start when something loads.
    /// </summary>
    [SerializeField]private bool startFade = false;

    public delegate void FadeInStatusEvent();
    public FadeInStatusEvent FadeInStatus;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        if (startFade)
            ScreenFadeOut();

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
        _image.CrossFadeAlpha(1.0f, _amountTofill/2, true);
        FadeInStatus();
    }
}

