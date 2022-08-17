using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFitile : MonoBehaviour
{
    public GameObject BombBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(BombBody.transform.position.x - 0.1f, BombBody.transform.position.y, BombBody.transform.position.z);
        // transform.rotation = BombBody.transform.rotation;
        
        //transform.rotation = Quaternion.Euler(BombBody.transform.rotation.x, BombBody.transform.rotation.y - 90, BombBody.transform.rotation.z);
        transform.rotation = BombBody.transform.rotation;
        transform.Rotate(BombBody.transform.rotation.x, BombBody.transform.rotation.y - 90, BombBody.transform.rotation.z);
        // Quaternion.Euler(BombBody.transform.rotation.x, BombBody.transform.rotation.y, BombBody.transform.rotation.z);

        //transform.eulerAngles = new Vector3(
        //    BombBody.transform.eulerAngles.x,
        //    BombBody.transform.eulerAngles.y + 90,
        //    BombBody.transform.eulerAngles.z
        //);

    }
}
