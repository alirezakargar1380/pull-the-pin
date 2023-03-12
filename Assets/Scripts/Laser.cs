using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject Smoke;

    // Start is called before the first frame update
    void Start()
    {
        // Smoke.gameObject.transform.position = new Vector3(0, 0, 0);
        // Debug.Log(gameObject.name);
        Smoke.SetActive(false);
        // Invoke("DeactiveSmoke", 2);
    }

    public void DeactiveSmoke() {
        Smoke.SetActive(false);
    }
 
    private void OnTriggerEnter(Collider other)
    {
        Smoke.SetActive(true);
        Destroy(other.gameObject);
        Invoke("DeactiveSmoke", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
