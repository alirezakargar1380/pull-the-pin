using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Ex", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ex()
    {
        Debug.Log("im run");
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 10f);
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("ball"))
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                rb.AddExplosionForce(10.0f, gameObject.transform.position, 5.0f, 1.0f, ForceMode.Impulse);
                Debug.Log(hit);
            }
        }
    }
}
