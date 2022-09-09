using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorsGridButtons : MonoBehaviour
{
    public Sprite DeActiveSoltMachine;
    public Sprite DeActiveBalls;
    public Sprite DeActiveTheme;
    public Sprite DeActiveSticks;
    public Sprite DeActiveTrails;
    public Sprite DeActiveWalls;    
    
    public Sprite ActiveSoltMachine;
    public Sprite ActiveBalls;
    public Sprite ActiveTheme;
    public Sprite ActiveSticks;
    public Sprite ActiveTrails;
    public Sprite ActiveWalls;

    public GameObject[] GridButtons;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnButton(string name)
    {
        Debug.Log(GridButtons.Length);
        SetAllButtonsDeActive();
        SetColorActiveByName(name);
    }

    void SetAllButtonsDeActive()
    {
        foreach (var gO in GridButtons)
        {
            switch (gO.name)
            {
                case "SoltMachine":
                    gO.GetComponent<Image>().sprite = DeActiveSoltMachine;
                    break;
                case "Balls":
                    gO.GetComponent<Image>().sprite = DeActiveBalls;
                    break;
                case "Theme":
                    gO.GetComponent<Image>().sprite = DeActiveTheme;
                    break;
                case "Trails":
                    gO.GetComponent<Image>().sprite = DeActiveTrails;
                    break;                
                case "Sticks":
                    gO.GetComponent<Image>().sprite = DeActiveSticks;
                    break;              
                case "Walls":
                    gO.GetComponent<Image>().sprite = DeActiveWalls;
                    break;
            }

        }

    }

    void SetColorActiveByName(string name)
    {
        Debug.Log(name);
        foreach (var gO in GridButtons)
        {
            if (gO.name == name)
            {
                switch (gO.name)
                {
                    case "SoltMachine":
                        gO.GetComponent<Image>().sprite = ActiveSoltMachine;
                        break;
                    case "Balls":
                        gO.GetComponent<Image>().sprite = ActiveBalls;
                        break;
                    case "Theme":
                        gO.GetComponent<Image>().sprite = ActiveTheme;
                        break;
                    case "Trails":
                        gO.GetComponent<Image>().sprite = ActiveTrails;
                        break;
                    case "Sticks":
                        gO.GetComponent<Image>().sprite = ActiveSticks;
                        break;                    
                    case "Walls":
                        gO.GetComponent<Image>().sprite = ActiveWalls;
                        break;
                }
            }
        }
    }
}
