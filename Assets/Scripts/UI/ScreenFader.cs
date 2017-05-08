using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour {

    [SerializeField]private float _amountTofill = 1f;
    private float _fillStep;
    [SerializeField]private Image _image;

    public void Start()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        _fillStep = _amountTofill;
        while (_image.color.a > 0.09f)
        {
            _image.color = Color.Lerp(_image.color, Color.clear, _fillStep * Time.deltaTime);

            yield return null;
        }
    }
}

