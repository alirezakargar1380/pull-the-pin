using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    public MakeBalls MakeBallsScript;
    public PinObject pinObjectSource;
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

        // string pinName = pinObjectSource.GetComponent<PinObject>().pinName;
        pinObjectSource.GetComponent<PinObject>().moveAnPin();
        // Instantiate(gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), gameObject.transform.rotation);
        // gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z).normalized * Time.deltaTime * 0.1f;

        // Destroy(Pin);
        Debug.Log("clicked");
        Clicked = true;
        // MakeBallsScript.ExploadeBomb("bomb_0");
    }
}
