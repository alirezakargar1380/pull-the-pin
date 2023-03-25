using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    public LevelMaker MakeBallsScript;
    public PinObject pinObjectSource;
    public GameObject Pin;
    public GameObject CircleOfPin;
    public GameObject NurbsOfPin;
    public bool Clicked = false;

    public void OnCollisionStay(Collision target)
    {
        if (target.gameObject.CompareTag("bomb"))
        {
            if (!target.gameObject.GetComponent<Bomb>().MakeReadyToExpload && Clicked)
            {
                target.gameObject.GetComponent<Bomb>().MakeBombReadyToExpload();
                Debug.Log("bomb on pin");
            }
        }
    }

    private void OnMouseDown()
    {
        if (Clicked) return;

        // pinObjectSource.GetComponent<PinObject>().moveAnPin();
        // Animator anim = CircleOfPin.GetComponent<Animator>();
        // anim.SetBool("open", true);

        pinObjectSource.GetComponent<PinObject>().moveAnPin();
        Clicked = true;
    }

    public void move()
    {
        
        pinObjectSource.GetComponent<PinObject>().moveAnPin();
    }
}
