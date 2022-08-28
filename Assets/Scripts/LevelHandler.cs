using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] public int CatchedBallsCount;
    [SerializeField] public int AllBalls;
    public bool checkForWin = false;
    public enum LevelResultEnums { noResult, win, lose }
    public LevelResultEnums finishStatus = LevelResultEnums.noResult;
    public string reason = "nothing set yet!";
    public GameObject text;

    public void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.CompareTag("ball"))
        {
            if (finishStatus == LevelResultEnums.lose) return;

            finishStatus = LevelResultEnums.lose;
            reason = "Êæ ÔãÇ Èå Òã?ä ÇäÏÇÎÊå ÔÏ";
            finishLevel();
        }
    }

    public void finishLevel()
    {
        if (AllBalls > CatchedBallsCount)
        {
            finishStatus = LevelResultEnums.lose;
        }
        showResult();
    }

    public void showResult()
    {
        Debug.Log("i want to show result to player");
        Debug.Log(finishStatus);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (AllBalls == CatchedBallsCount)
        {
            if (checkForWin) return;

            checkForWin = true;
            finishStatus = LevelResultEnums.win;
            Invoke("finishLevel", 3);
        }

        text.GetComponent<TMPro.TextMeshProUGUI>().text = CatchedBallsCount.ToString() + " / " + AllBalls.ToString();
    }

}
