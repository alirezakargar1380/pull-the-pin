using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    public MakeBalls MakeBallsScript;
    public PinObject pinObjectSource;
    Vector3 currentPosition;
    private void OnMouseDown()
    {
        string pinName = pinObjectSource.GetComponent<PinObject>().pinName;
        pinObjectSource.GetComponent<PinObject>().moveAnPin(pinName);
        // Instantiate(gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), gameObject.transform.rotation);
        // gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z).normalized * Time.deltaTime * 0.1f;

        // Destroy(gameObject);
        // MakeBallsScript.ExploadeBomb("bomb_0");
    }
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.2f, gameObject.transform.position.z);
        if (Vector3.Distance(currentPosition, distance) < 5)
        {
            // Debug.Log("true");
        } else
        {
            // Destroy(gameObject);
            // Debug.Log("false");
            // return;
        }
        // gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.2f * 2f, gameObject.transform.position.z);
        
        // transform.position = Vector3.MoveTowards(gameObject.transform.position, distance, Time.deltaTime * 2f);
    }
}
