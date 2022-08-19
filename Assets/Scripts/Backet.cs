using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball") && !collision.gameObject.GetComponent<Ball>().Touched)
        {
            collision.gameObject.GetComponent<Ball>().Touched = true;
            LevelGeneratorScript.GetComponent<CountBalls>().TouchedNumber++;
        }
    }

    [SerializeField] public MakeBalls LevelGeneratorScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
