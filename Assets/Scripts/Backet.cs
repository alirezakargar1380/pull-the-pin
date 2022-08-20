using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backet : MonoBehaviour
{
    [SerializeField] public MakeBalls LevelGeneratorScript;
    [SerializeField] public LevelHandler LevelHandlerScript;
    public enum levelResultEnums { noResult, win, lose };

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball") && !collision.gameObject.GetComponent<Ball>().Touched)
        {
            collision.gameObject.GetComponent<Ball>().Touched = true;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            LevelGeneratorScript.GetComponent<CountBalls>().TouchedNumber++;
            LevelHandlerScript.CatchedBallsCount++;
        }

        if (collision.gameObject.CompareTag("bomb"))
        {
            if (LevelHandlerScript.finishStatus == LevelHandler.LevelResultEnums.lose) return;

            LevelHandlerScript.finishStatus = LevelHandler.LevelResultEnums.lose;
            LevelHandlerScript.reason = "»„» œ— ”»œ «‰œ«Œ ?œ";
            LevelHandlerScript.finishLevel();
        }
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
