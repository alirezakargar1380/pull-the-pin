using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public bool Touched = false;
    [SerializeField] public bool HadColor = false;
    public CountBalls script;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball") && collision.gameObject.GetComponent<Ball>().Touched && !Touched)
        {
            Touched = true;
            script.TouchedNumber++;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            // Debug.Log(otherGameObject.GetComponent<CountBalls>().TouchedNumber);
            // GetComponent<CountBalls>().TouchedNumber++;
            // Debug.Log(GetComponent<CountBalls>().TouchedNumber);
            // collision.gameObject.GetComponent<CountBalls>().TouchedNumber++;
        }

        if (collision.gameObject.CompareTag("ball") && !collision.gameObject.GetComponent<Ball>().HadColor && HadColor)
        {
            Debug.Log("it hasnt color");
            Color customColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);
            collision.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", customColor);
            collision.gameObject.GetComponent<Ball>().HadColor = true;
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
