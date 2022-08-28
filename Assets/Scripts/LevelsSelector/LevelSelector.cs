using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public static int selectedLevel;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectLevel()
    {
        selectedLevel = level;
        SceneManager.LoadScene("Test");
        // SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
    }    
    
    public void OpenLevelScene()
    {
        selectedLevel = level;
        SceneManager.LoadScene("Levels");
        // SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
    }
}
