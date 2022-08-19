using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBalls : MonoBehaviour
{
    [SerializeField] public int TouchedNumber = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball") && !collision.gameObject.GetComponent<Ball>().Touched)
        {
            collision.gameObject.GetComponent<Ball>().Touched = true;
            TouchedNumber++;
        }
    }

    private void Start()
    {
    }
}
