using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] public int CatchedBallsCount;
    public enum LevelResultEnums { noResult, win, lose }
    public LevelResultEnums finishStatus = LevelResultEnums.noResult;
    public string reason = "nothing set yet!";

    public void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.CompareTag("ball"))
        {
            if (finishStatus == LevelHandler.LevelResultEnums.lose) return;

            finishStatus = LevelHandler.LevelResultEnums.lose;
            reason = " ÊÅ ‘„« »Â “„?‰ «‰œ«Œ Â ‘œ";
            finishLevel();
        }
    }

    public void finishLevel()
    {
        Invoke("showResult", 3);
    }

    public void showResult()
    {
        Debug.Log("i want to show result to player");
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
