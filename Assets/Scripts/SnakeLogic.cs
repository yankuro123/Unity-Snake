using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SnakeLogic : MonoBehaviour
{
    Vector2 dir = Vector2.right * 2;
    List<Transform> tail = new List<Transform>();
    bool ate = false;
    public GameObject SnakeTail;
    public string scene;
    public float time = 30.0f;


    //private float multiplier = 0.3f;
    private float nextActionTime = 0.0f;
    private float period = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Move", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            dir = Vector2.right * 2;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            dir = Vector2.left * 2;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            dir = Vector2.up * 2;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            dir = Vector2.down * 2;
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            Move();
        }
       
    }
    private void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);
        if (ate)
        {
            GameObject g = (GameObject)Instantiate(SnakeTail, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        }
        if(tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            ate = true;
            Destroy(collision.gameObject);
            if ( period > 0.0f)
            period = period - 0.001f;
            Score.Value += Mathf.FloorToInt(100 * FoodSpawn.multiplier);
            FoodSpawn.time = 20.0f;
            FoodSpawn.multiplier = 1;
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }
}
