using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log(gameObject.transform.position.x);
        Instantiate(gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 20, gameObject.transform.position.z), gameObject.transform.rotation);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
