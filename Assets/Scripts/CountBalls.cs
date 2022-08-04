using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBalls : MonoBehaviour
{
    [SerializeField] public int TouchedNumber = 0;
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("im here");
        if (collision.gameObject.CompareTag("ball") && !collision.gameObject.GetComponent<Ball>().Touched)
        {
            collision.gameObject.GetComponent<Ball>().Touched = true;
            Debug.Log("im touched");
            TouchedNumber++;
        }


        // Debug.Log(collision.gameObject);
        // Debug.Log(collision.gameObject.GetComponent<Ball>().Touched);
    }

    private void Start()
    {
        Debug.Log("Started");
    }
}
