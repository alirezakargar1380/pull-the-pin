using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public bool Touched = false;
    [SerializeField] public bool HadColor = false;
    [SerializeField] public string Name;
    public AudioSource burnBall;
    public AudioClip first;
    public AudioClip second;
    public LevelMaker LevelGeneratorScript;
    [SerializeField] public LevelHandler LevelHandlerScript;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (!collision.gameObject.CompareTag("ball"))
            return;

        if (collision.gameObject.CompareTag("ball") && collision.gameObject.GetComponent<Ball>().Touched && !Touched)
        {
            Touched = true;
            
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            // gameObject.GetComponent<SphereCollider>().material.bounciness = 0;
            // collision.gameObject.GetComponent<SphereCollider>().material.bounciness = 0;

            if (HadColor)
            {
                LevelHandlerScript.CatchedBallsCount++;
                // script.TouchedNumber++;
            }
        }

        if (collision.gameObject.CompareTag("ball") && !collision.gameObject.GetComponent<Ball>().HadColor && HadColor)
        {
            return;
            Color customColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);
            collision.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", customColor);
            collision.gameObject.GetComponent<Ball>().HadColor = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("ball") || HadColor || !gameObject.CompareTag("ball"))
        {
            return;
        }

        if (collision.gameObject.GetComponent<Ball>().HadColor && !HadColor && !collision.gameObject.GetComponent<Ball>().Touched)
        {
            HadColor = true;
            // Color customColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);
            LevelGeneratorScript.MakeColorForBall(gameObject);
            // gameObject.GetComponent<AudioSource>().Play();
            // --> SOUND // gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<AudioSource>().PlayOneShot(first);
        }
    }

    public void PlaySecond()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(second);
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
