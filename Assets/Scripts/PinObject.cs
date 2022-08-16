using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinObject : MonoBehaviour
{
    [SerializeField] public string[] BombIds;
    public string pinName;
    public GameObject[] Pins;
    public GameObject PinObfject;
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

    public void moveAnPin(string pinNam)
    {
        if (Pins == null) return;

        for (int i = 0; i < Pins.Length; i++)
        {
            Debug.Log(Pins[i].GetComponent<PinObject>().pinName);
            Debug.Log("-------------------------------------------");
            if (Pins[i].GetComponent<PinObject>().pinName == pinNam)
            {
                Destroy(Pins[i]);
                PinObfject = Pins[i];
            }
        }
    }

}
