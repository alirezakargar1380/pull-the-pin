using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    public MakeBalls MakeBallsScript;
    public PinObject pinObjectSource;
    private void OnMouseDown()
    {
        string pinName = pinObjectSource.GetComponent<PinObject>().pinName;
        pinObjectSource.GetComponent<PinObject>().moveAnPin(pinName);
        // Instantiate(gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), gameObject.transform.rotation);
        // gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z).normalized * Time.deltaTime * 0.1f;

        // Destroy(Pin);
        Debug.Log("clicked");
        // MakeBallsScript.ExploadeBomb("bomb_0");
    }
}
