using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject FoodPrefab;
    public Sprite Map;
    public static bool timeStart = false;
    public static float time = 20.0f;
    public static float  multiplier = 1;
    //public static float point;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 4, 3);
    }

    // Update is called once per frame
    private void Update()
    {

        if (GameObject.FindWithTag("Food"))
        {
            timeStart = true;
            if (timeStart)
            {
                if (time > 0)
                {
                    time -= Time.deltaTime;
                    if (multiplier > 0.01f)
                        multiplier -= (Time.deltaTime/20);
                }
                else
                    multiplier = 0.01f;
            }
        }
    }
    void Spawn()
    {
        int x = (int)Random.Range(Map.border.x + 60, Map.border.z - 60);
        int y = (int)Random.Range(Map.border.w - 45, Map.border.y + 45);
        GameObject newFood = Instantiate(FoodPrefab, new Vector2(x, y), Quaternion.identity);
        Destroy(newFood, 30.0f);
    }
}
