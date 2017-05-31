using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour {

    [SerializeField]private float _amountTofill = 1f;
    [SerializeField]private Image _image;

    [SerializeField]private bool debugMode = false;

    private void Start()
    {
        if(debugMode)
        {
            ScreenFadeOut();
        }
    }

    public void ScreenFadeOut()
    {
        _image.CrossFadeAlpha(0.0f, _amountTofill, true);
    }

    public void ScreenFadeIn()
    {
        _image.CrossFadeAlpha(1.0f, _amountTofill, true);
    }
}

