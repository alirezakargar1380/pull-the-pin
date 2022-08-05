using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBalls : MonoBehaviour
{
    public GameObject Ball;
    public Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Ball);
        Instantiate(Ball);
        Instantiate(Ball);
        Instantiate(Ball);
        Instantiate(Ball);
        Instantiate(Ball);
        Instantiate(Ball);
        Destroy(Ball);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
