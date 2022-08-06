using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBalls : MonoBehaviour
{
    public GameObject Ball;
    public float space;

    // Start is called before the first frame update
    void Start()
    {
        float nx = Ball.transform.position.x + space;
        for (int i = 0; i < 10; i++)
        {
            Color customColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);
            GameObject newGameObject =  Instantiate(Ball, new Vector3(nx * i, Ball.transform.position.y, Ball.transform.position.z), Ball.transform.rotation);
            newGameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", customColor);
            newGameObject.GetComponent<Ball>().HadColor = true;
        }        
        
        for (int i = 0; i < 10; i++)
        {
            GameObject newGameObject =  Instantiate(Ball, new Vector3(nx * i, Ball.transform.position.y - 1, Ball.transform.position.z), Ball.transform.rotation);
            newGameObject.GetComponent<Ball>().HadColor = false;
        }

        Destroy(Ball);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
