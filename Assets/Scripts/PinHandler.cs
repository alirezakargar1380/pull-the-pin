using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    public MakeBalls MakeBallsScript;
    public PinObject pinObjectSource;
    Vector3 currentPosition;
    public Vector3 distance;
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
        distance = new Vector3(gameObject.transform.position.x + 6f, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        return;
        if (Vector3.Distance(currentPosition, distance) < 4)
        {
            // Debug.Log("true");
        } else
        {
            // Destroy(gameObject);
            // Debug.Log("false");
            // return;
        }

        // transform.position = Vector3.MoveTowards(gameObject.transform.position, distance, Time.deltaTime * 1f);
        // transform.position = Vector3.MoveTowards(gameObject.transform.position, Vector3.Lerp(gameObject.transform.position, distance, 3f), Time.deltaTime * 3f);
        transform.Translate(distance, Space.World);
    }
}
