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

public class LevelMaker : MonoBehaviour
{
    public GameObject BallPlace;
    public GameObject GameObjects;
    public GameObject Ball;
    public GameObject Pin;
    public GameObject Bomb;
    public GameObject Buttle;
    public GameObject ButtleParent;
    public GameObject Bucket;
    public float space;
    public List<GameObject> levelObjects;
    public TextAsset levelsTxt;
    public GameObject[] Bombs;
    [SerializeField] Mesh[] ButtleMeshs;
    [SerializeField] Material[] BallMaterial;
    [SerializeField] Material WithoutColorBallMaterial;
    public Dictionary<string, GameObject[]> BallsThatConcatTogether = new Dictionary<string, GameObject[]>();
    [SerializeField] public LevelHandler LevelHandlerScript;

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
        public Coordinate[] bombs;
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
        buildLevel();
        LevelsDetail level = GetLevel(3);
        return;

        // Make Balls
        foreach (BallO ball in level.balls)
        {
            Debug.Log("x: " + GameObjects.transform.position.x);
            Debug.Log("y: " + GameObjects.transform.position.y);
            GameObject parent = Instantiate(GameObjects, new Vector3(ball.startPoint.x, ball.startPoint.y, GameObjects.transform.position.z), GameObjects.transform.rotation);
            parent.transform.SetParent(BallPlace.transform);
            parent.transform.localScale = BallPlace.transform.localScale;

            // break;
            if (!ball.doesItHaveColor)
            {
                for (int i = 0; i < ball.num; i++)
                {
                    LevelHandlerScript.AllBalls++;
                    // GameObject newGameObject = Instantiate(Ball, new Vector3(Ball.transform.position.x + (space * i), Ball.transform.position.y, Ball.transform.position.z), Ball.transform.rotation);
                    // newGameObject.GetComponent<Ball>().HadColor = false;
                    // newGameObject.name = "ball_" + i;
                    // newGameObject.GetComponent<Ball>().Name = "ball_" + i;
                }
            }
            else
            {
                for (int i = 0; i < ball.num; i++)
                {
                    LevelHandlerScript.AllBalls++;
                    RGBColor randomColor = new RGBColor();
                    randomColor.color = new float[] { 0.4f, 0.90f, 0.70f, 1.0f };

                    byte[][] colors = new byte[5][];
                    colors[0] = new byte[4] { 39, 236, 44, 1 };
                    colors[1] = new byte[4] { 236, 146, 39, 1 };
                    colors[2] = new byte[4] { 210, 39, 236, 1 };
                    colors[3] = new byte[4] { 39, 122, 236, 1 };
                    colors[4] = new byte[4] { 236, 44, 39, 1 };

                    

                    GameObject newGameObject = Instantiate(Ball, Ball.transform.position, Ball.transform.rotation);
                    // GameObject newGameObject = Instantiate(Ball);
                    MakeColorForBall(newGameObject);
                    newGameObject.name = "ball_" + LevelHandlerScript.AllBalls + "_color";
                    // newGameObject.transform.parent = GameObjects.transform; // OK
                    newGameObject.transform.SetParent(parent.transform); 
                    // newGameObject.transform.position = new Vector3(ball.startPoint.x + (space * i), ball.startPoint.y, ball.startPoint.z);
                    newGameObject.transform.localScale = Ball.transform.localScale;
                    
                }
            }
        }
        Destroy(Ball);
        // Destroy(GameObjects);
        return;

        // Bucket
        Instantiate(Bucket, new Vector3(level.bucket.x, level.bucket.y, level.bucket.z), Quaternion.Euler(new Vector3(Bucket.transform.rotation.x, Bucket.transform.rotation.y, Bucket.transform.rotation.z)));

        // Make Bombs
        //foreach (Coordinate coor in level.bombs)
        //{
        //    Instantiate(Bomb, new Vector3(coor.x, coor.y, coor.z), Quaternion.Euler(new Vector3(Bomb.transform.rotation.x, Bomb.transform.rotation.y, Bomb.transform.rotation.z)));
        //}

        

        // Destroy(Bomb);
        
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
        //Destroy(Ball);
        
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

    public void MakeColorForBall(GameObject Object)
    {
        Object.GetComponent<MeshRenderer>().material = GetRandomBallMaterial();
        Object.GetComponent<Ball>().HadColor = true;
        return;
        byte[][] colors = new byte[5][];
        colors[0] = new byte[4] { 39, 236, 44, 1 };
        colors[1] = new byte[4] { 236, 146, 39, 1 };
        colors[2] = new byte[4] { 210, 39, 236, 1 };
        colors[3] = new byte[4] { 39, 122, 236, 1 };
        colors[4] = new byte[4] { 236, 44, 39, 1 };
        int index = Random.Range(0, colors.Length);
        Color customColor = new Color32(colors[index][0], colors[index][1], colors[index][2], colors[index][3]);

        Object.GetComponent<MeshRenderer>().material.SetColor("_Color", customColor);
        Object.GetComponent<Ball>().HadColor = true;
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

    public void buildLevel()
    {
        Debug.Log("build level");
        Debug.Log(LevelPage.selectedLevel);

        // GET LEVEL
        LevelsDetail level = GetLevel(3);

        // Buttle
        Buttle.gameObject.SetActive(true);
        GameObject CreatedButtle = Instantiate(Buttle, Buttle.transform.position, Buttle.transform.rotation);
        CreatedButtle.transform.SetParent(ButtleParent.transform);
        CreatedButtle.transform.position = Buttle.transform.position;
        CreatedButtle.transform.rotation = Buttle.transform.rotation;
        CreatedButtle.transform.localScale = Buttle.transform.localScale;
        CreatedButtle.GetComponent<MeshFilter>().mesh = ButtleMeshs[0];
        CreatedButtle.GetComponent<MeshCollider>().sharedMesh = ButtleMeshs[0];
        // Destroy(Buttle);
        Buttle.gameObject.SetActive(false);

        // Make Balls
        Ball.gameObject.SetActive(true);
        foreach (BallO ball in level.balls)
        {
            if (!ball.doesItHaveColor)
            {
                for (int i = 0; i < ball.num; i++)
                {
                    GameObject CreatedBall = Instantiate(Ball, new Vector3(ball.startPoint.x + (space * i), ball.startPoint.y, Ball.transform.position.z), Ball.transform.rotation);
                    CreatedBall.GetComponent<MeshRenderer>().material = WithoutColorBallMaterial;
                    CreatedBall.GetComponent<Ball>().HadColor = false;

                    LevelHandlerScript.AllBalls++;
                }
            }
            else
            {
                for (int i = 0; i < ball.num; i++)
                {
                    GameObject CreatedBall = Instantiate(Ball, new Vector3(ball.startPoint.x + (space * i), ball.startPoint.y, Ball.transform.position.z), Ball.transform.rotation);
                    levelObjects.Add(CreatedBall);
                    CreatedBall.GetComponent<MeshRenderer>().material = GetRandomBallMaterial();
                    CreatedBall.GetComponent<Ball>().HadColor = true;

                    LevelHandlerScript.AllBalls++;
                }
            }
        }
        Ball.gameObject.SetActive(false);

        // PIN
        Pin.gameObject.SetActive(true);
        foreach (CoordinateAndRotation coor in level.pins)
        {
            GameObject nPin = Instantiate(Pin, new Vector3(coor.x, coor.y, coor.z), Quaternion.Euler(new Vector3(coor.rx, coor.ry, coor.rz)));
            nPin.GetComponent<PinObject>().BombIds = new string[] { "bomb_0" };
            nPin.GetComponent<PinObject>().Pins = nPin;
        }
        Pin.gameObject.SetActive(false);
        // Destroy(Pin);
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

    public Material GetRandomBallMaterial()
    {
        int index = Random.Range(0, BallMaterial.Length);
        return BallMaterial[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
