using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClass
{
    public int level;
    public float timeElapsed;
    public string playerName;
}

public class RGBColor
{
    public float[] color;
}

public class RGBColors
{
    public Color[] colors;
}

public class MakeBalls : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Pin;
    public GameObject Bomb;
    public GameObject Buttle;
    public GameObject Bucket;
    public float space;
    public List<GameObject> levelObjects;
    public TextAsset levelsTxt;
    public GameObject[] Bombs;
    [SerializeField] Mesh[] ButtleMeshs;
    public Dictionary<string, GameObject[]> BallsThatConcatTogether = new Dictionary<string, GameObject[]>();

    [System.Serializable]
    public class Coordinate
    {
        public float x;
        public float y;
        public float z;
    }

    [System.Serializable]
    public class CoordinateAndRotation
    {
        public float x;
        public float y;
        public float z;        
        public float rx;
        public float ry;
        public float rz;
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
        public int buttleIndex;
        public BallO[] balls;
        public CoordinateAndRotation[] pins;
        public Coordinate bucket;
    }

    [System.Serializable]
    public class Lev
    {
        public LevelsDetail[] levels;
    }

    // Start is called before the first frame update
    void Start()
    {
        // GET LEVEL
        LevelsDetail level = GetLevel(1);

        // Buttle
        Buttle.GetComponent<MeshFilter>().mesh = ButtleMeshs[level.buttleIndex];
        Buttle.GetComponent<MeshCollider>().sharedMesh = ButtleMeshs[level.buttleIndex];

        // PIN
        foreach (CoordinateAndRotation coor in level.pins)
        {
            Debug.Log(coor.x);
            GameObject nPin = Instantiate(Pin, new Vector3(coor.x, coor.y, coor.z), Quaternion.Euler(new Vector3(coor.rx, coor.ry, coor.rz)));
            nPin.GetComponent<PinObject>().BombIds = new string[] { "bomb_0" };
            nPin.GetComponent<PinObject>().Pins = nPin;
        }

        // Bucket
        Instantiate(Bucket, new Vector3(level.bucket.x, level.bucket.y, level.bucket.z), Quaternion.Euler(new Vector3(Bucket.transform.rotation.x, Bucket.transform.rotation.y, Bucket.transform.rotation.z)));
        
        // Make Balls
        foreach (BallO ball in level.balls)
        {
            break;
            if (!ball.doesItHaveColor)
            {
                for (int i = 0; i < ball.num; i++)
                {
                    GameObject newGameObject = Instantiate(Ball, new Vector3(ball.startPoint.x + (space * i), ball.startPoint.y, ball.startPoint.z), Ball.transform.rotation);
                    newGameObject.GetComponent<Ball>().HadColor = false;
                    newGameObject.name = "ball_" + i;
                    newGameObject.GetComponent<Ball>().Name = "ball_" + i;
                } 
            } else
            {
                for (int i = 0; i < ball.num; i++)
                {
                    RGBColors randomColors = new RGBColors();
                    RGBColor randomColor = new RGBColor();
                    randomColor.color = new float[] { 0.4f, 0.90f, 0.70f, 1.0f };

                    byte[][] colors = new byte[5][];
                    colors[0] = new byte[4] { 39, 236, 44, 1 };
                    colors[1] = new byte[4] { 236, 146, 39, 1 };
                    colors[2] = new byte[4] { 210, 39, 236, 1 };
                    colors[3] = new byte[4] { 39, 122, 236, 1 };
                    colors[4] = new byte[4] { 236, 44, 39, 1 };

                    int index = Random.Range(0, colors.Length);
                    Color customColor = new Color32(colors[index][0], colors[index][1], colors[index][2], colors[index][3]);

                    GameObject newGameObject = Instantiate(Ball, new Vector3(ball.startPoint.x + (space * i), ball.startPoint.y, ball.startPoint.z), Ball.transform.rotation);
                    newGameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", customColor);
                    newGameObject.GetComponent<Ball>().HadColor = true;
                    newGameObject.name = "ball_" + i + "_color";
                    newGameObject.GetComponent<Ball>().Name = "ball_" + i + "_color";
                }
            }
        }

        // Destroy(Bomb);
        // Destroy(Ball);
        Destroy(Pin);
        Destroy(Bucket);
        return;

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

    public LevelsDetail GetLevel(int levelNum)
    {
        Lev MyLevels = new Lev();
        MyLevels = JsonUtility.FromJson<Lev>(levelsTxt.text);
        string vv = JsonUtility.ToJson(MyLevels.levels[0].pins);

        LevelsDetail selectedLevel = MyLevels.levels[0];

        for (int i = 0; i < MyLevels.levels.Length; i++)
        {
            LevelsDetail level = MyLevels.levels[i];
            if (levelNum == level.level)
            {
                selectedLevel = level;
            }
        }

        // Debug.Log(vv);
        return selectedLevel;
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
