using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public bool Touched = false;
    public CountBalls script;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball") && collision.gameObject.GetComponent<Ball>().Touched && !Touched)
        {
            Touched = true;
            Debug.Log("im ball toched another boll");
            script.TouchedNumber++;
            // Debug.Log(otherGameObject.GetComponent<CountBalls>().TouchedNumber);
            // GetComponent<CountBalls>().TouchedNumber++;
            // Debug.Log(GetComponent<CountBalls>().TouchedNumber);
            // collision.gameObject.GetComponent<CountBalls>().TouchedNumber++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // script.TouchedNumber++;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
