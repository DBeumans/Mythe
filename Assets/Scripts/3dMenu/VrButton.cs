//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VrButton : MonoBehaviour
{ 
    [SerializeField]
    private UnityEvent doAction;

    private SpriteRenderer spriteRend;
    private Color normalColor;

    [SerializeField]
    private Color hoverColor;

    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        normalColor = spriteRend.color;
    }

    public void setHover(bool hoverState)
    {           
        if(hoverState)
        {
            spriteRend.color = hoverColor;
        }
        else
        {
            spriteRend.color = normalColor;
        }
    }
	
	public void clicked ()
    {
        doAction.Invoke();
	}
}
