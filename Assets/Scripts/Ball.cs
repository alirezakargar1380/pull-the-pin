using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public bool Touched = false;
    [SerializeField] public bool HadColor = false;
    [SerializeField] public string Name;
    public CountBalls script;
    public MakeBalls LevelGeneratorScript;

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball") && collision.gameObject.GetComponent<Ball>().Touched && !Touched)
        {
            Touched = true;
            script.TouchedNumber++;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            // Debug.Log(otherGameObject.GetComponent<CountBalls>().TouchedNumber);
            // GetComponent<CountBalls>().TouchedNumber++;
            // Debug.Log(GetComponent<CountBalls>().TouchedNumber);
            // collision.gameObject.GetComponent<CountBalls>().TouchedNumber++;
        }

        if (collision.gameObject.CompareTag("ball") && !collision.gameObject.GetComponent<Ball>().HadColor && HadColor)
        {
            return;
            Color customColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);
            collision.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", customColor);
            collision.gameObject.GetComponent<Ball>().HadColor = true;
        }
        
        if (collision.gameObject.CompareTag("ball") && collision.gameObject.GetComponent<Ball>().HadColor && !HadColor)
        {
            // setColor();
        }

        
    }

    private void OnCollisionStay(Collision collision)
    {
        return;
        if (!collision.gameObject.CompareTag("ball") && HadColor) return;

        if (collision.gameObject.GetComponent<Ball>().HadColor && !HadColor)
        {
            HadColor = true;
            Color customColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", customColor);
        }
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
