using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] public bool Exploaded = false;
    [SerializeField] public bool MakeReadyToExpload = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeBombReadyToExpload()
    {
        MakeReadyToExpload = true;
        Invoke("Ex", 3);
    }

    public void Ex()
    {
        // Debug.Log("im run");
        Exploaded = true;
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 10f);
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("ball"))
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                rb.AddExplosionForce(10.0f, gameObject.transform.position, 5.0f, 1.0f, ForceMode.Impulse);
            }
        }
        Destroy(gameObject);
    }

}
