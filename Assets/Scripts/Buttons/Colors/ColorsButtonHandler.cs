using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsButtonHandler : MonoBehaviour
{
    public ColorsGridButtons handleGridButtonsScript;

    public void Click()
    {
        handleGridButtonsScript.ClickOnButton(gameObject.name);
    }
}
