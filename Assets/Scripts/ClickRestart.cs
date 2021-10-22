using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClickRestart : MonoBehaviour
{
    public string scene;

    private bool loadLock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !loadLock)
        {
            LoadScene();
            Score.Value = 0;
            FoodSpawn.timeStart = false;
            FoodSpawn.time = 30.0f;
            FoodSpawn.multiplier = 1;
        }
    }
    void LoadScene()
    {
        loadLock = true;
        SceneManager.LoadScene(scene);
    }
}
