using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClass
{
    public int level;
    public float timeElapsed;
    public string playerName;
}

public class Ob
{
    public string playerName;
    public List<MyClass> classes;
}

public class MakeBalls : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Pin;
    public GameObject Bomb;
    public float space;
    public List<GameObject> levelObjects;

    // Start is called before the first frame update
    void Start()
    {
        

    MyClass myObject = new MyClass();
        myObject.level = 1;
        myObject.timeElapsed = 47.5f;
        myObject.playerName = "Dr Charles Francis";
        string json = JsonUtility.ToJson(myObject);
        Debug.Log(json);


        for (int i = 0; i < 2; i++)
        {
            GameObject NewBomb = Instantiate(Bomb, new Vector3(Bomb.transform.position.x, Bomb.transform.position.y, Bomb.transform.position.z), Bomb.transform.rotation);
            NewBomb.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
            NewBomb.name = "bomb_" + i;
            levelObjects.Add(NewBomb);
        }

        
        for (int i = 0; i < levelObjects.Count; i++)
        {
            if (levelObjects[i].name == "bomb_1")
            {
                Debug.Log(levelObjects[i].name);
                Destroy(levelObjects[i]);
            }
        }

        Destroy(Bomb);
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

        Destroy(Ball);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
