using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClass
{
    public int level;
    public float timeElapsed;
    public string playerName;
}

public class MakeBalls : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Pin;
    public GameObject Bomb;
    public float space;
    public List<GameObject> levelObjects;
    public TextAsset levelsTxt;
    public GameObject[] Bombs;

    [System.Serializable]
    public class Coordinate
    {
        public float x;
        public float y;
        public float z;
    }

    [System.Serializable]
    public class BallO
    {
        public Coordinate startPoint;
        public int num;
        public bool doesItHaveColor;
    }
    
    [System.Serializable]
    public class LevelsDetail
    {
        public int level;
        public BallO[] balls;
    }

    [System.Serializable]
    public class Lev
    {
        public LevelsDetail[] levels;
    }

    // Start is called before the first frame update
    void Start()
    {
        return;

        // PIN
        GameObject nPin = Instantiate(Pin, new Vector3(0.8f, 10.82f, 16.424f), Quaternion.Euler(new Vector3(-132.89f, 90, -90)));
        nPin.GetComponent<PinObject>().BombIds = new string[] { "bomb_0" };
        nPin.GetComponent<PinObject>().pinName = "bla";
        nPin.GetComponent<PinObject>().Pins = new GameObject[] { nPin };

        GameObject nnPin = Instantiate(Pin, new Vector3(0.8f, 9.82f, 16.424f), Quaternion.Euler(new Vector3(-132.89f, 90, -90)));
        nnPin.GetComponent<PinObject>().BombIds = new string[] { "bomb_1" };
        nnPin.GetComponent<PinObject>().pinName = "yu";
        nnPin.GetComponent<PinObject>().Pins = new GameObject[] { nnPin };

        LevelsDetail level = GetLevel();
        
        // make Balls
        foreach (BallO ball in level.balls)
        {
            Debug.Log(ball.startPoint.x);
            if (!ball.doesItHaveColor)
            {
                for (int i = 0; i < ball.num; i++)
                {
                    GameObject newGameObject = Instantiate(Ball, new Vector3(ball.startPoint.x + (space * i), ball.startPoint.y, ball.startPoint.z), Ball.transform.rotation);
                    newGameObject.GetComponent<Ball>().HadColor = false;
                } 
            }
        }

        MyClass myObject = new MyClass();
        myObject.level = 1;
        myObject.timeElapsed = 47.5f;
        myObject.playerName = "Dr Charles Francis";
        string json = JsonUtility.ToJson(myObject);
        Debug.Log(json);



        return;

        for (int i = 0; i < 1; i++)
        {
            GameObject NewBomb = Instantiate(Bomb, new Vector3(Bomb.transform.position.x, Bomb.transform.position.y, Bomb.transform.position.z), Bomb.transform.rotation);
            // NewBomb.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
            NewBomb.name = "bomb_" + i;
            levelObjects.Add(NewBomb);
        }


        // get bomb by Id
        //for (int i = 0; i < levelObjects.Count; i++)
        //{
        //    if (levelObjects[i].name == "bomb_1")
        //    {
        //        Debug.Log(levelObjects[i].name);
        //        Destroy(levelObjects[i]);
        //    }
        //}

        // ExploadeBomb("bomb_0");

        Destroy(Bomb);
        Destroy(Ball);
        return;
        float nx = Ball.transform.position.x + space;
        for (int i = 0; i < 10; i++)
        {
            Color customColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);
            GameObject newGameObject =  Instantiate(Ball, new Vector3(nx * i, Ball.transform.position.y, Ball.transform.position.z), Ball.transform.rotation);
            newGameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", customColor);
            newGameObject.GetComponent<Ball>().HadColor = true;
        }        
        
        for (int i = 0; i < 10; i++)
        {
            GameObject newGameObject =  Instantiate(Ball, new Vector3(nx * i, Ball.transform.position.y - 1, Ball.transform.position.z), Ball.transform.rotation);
            newGameObject.GetComponent<Ball>().HadColor = false;
        }
    }

    public LevelsDetail GetLevel()
    {
        Lev MyLevels = new Lev();
        MyLevels = JsonUtility.FromJson<Lev>(levelsTxt.text);
        string vv = JsonUtility.ToJson(MyLevels.levels[0]);
        Debug.Log(vv);
        Debug.Log(MyLevels.levels[0]);
        return MyLevels.levels[0];
    }

    public void ExploadeBomb(string BombId)
    {
        for (int i = 0; i < levelObjects.Count; i++)
        {
            if (levelObjects[i].name == BombId)
            {
                Debug.Log(levelObjects[i].name);
                Destroy(levelObjects[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
