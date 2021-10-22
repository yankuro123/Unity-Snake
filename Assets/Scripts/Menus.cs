using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menus : MonoBehaviour
{
 
    public Button Pause;
    public Button Exit;
    public SpriteRenderer Txt;
    public SpriteRenderer Txt1;
    public static bool OffSet = false;
    public bool PauseLock = false;

    private bool loadLock;
    // Start is called before the first frame update
    void Start()
    {
        Button pause = Pause.GetComponent<Button>();
        Txt = Txt.GetComponent<SpriteRenderer>();
        Txt1 = Txt1.GetComponent<SpriteRenderer>();
        pause.onClick.AddListener(Task);
        Button exit = Exit.GetComponent<Button>();
        exit.onClick.AddListener(Application.Quit);
    }

    // Update is called once per frame
    void Update()
    {
        if (OffSet == false)
        {
            Txt.GetComponent<SpriteRenderer>().enabled = false;
            Txt1.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && PauseLock)
        {
            Time.timeScale = 1;
            PauseLock = false;
            Txt.GetComponent<SpriteRenderer>().enabled = false;
            Txt1.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void Task()
    {
        if (PauseLock == false)
        {
            PauseLock = true;
            OffSet = true;
            Time.timeScale = 0;
            Txt.GetComponent<SpriteRenderer>().enabled = true;
            Txt1.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            PauseLock = false;
            Txt.GetComponent<SpriteRenderer>().enabled = false;
            Txt1.GetComponent<SpriteRenderer>().enabled = false;

        }
    }
}
