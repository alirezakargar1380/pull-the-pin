using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPage : MonoBehaviour
{
    public static int selectedLevel = 2;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunLevel()
    {
        selectedLevel = level;
        SceneManager.LoadScene("ali_mousavi_ui");
    }
}
