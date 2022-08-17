using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinObject : MonoBehaviour
{
    [SerializeField] public string[] BombIds;
    public GameObject Pins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (PinObfject == null) return;
        // Destroy(PinObfject);
    }

    public void moveAnPin()
    {
        if (Pins == null) return;

        Animator anim = Pins.GetComponent<Animator>();
        anim.SetBool("open", true);
    }

}
