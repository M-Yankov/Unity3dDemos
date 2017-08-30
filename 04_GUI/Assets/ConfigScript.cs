using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigScript : MonoBehaviour
{
    private static bool isPaused;
    private GameObject menuCanvas;

    void Start()
    {
        Cursor.visible = false;
        this.menuCanvas = GameObject.FindGameObjectWithTag("MenuCamera");
        GameObject.FindGameObjectWithTag("Setting").SetActive(false);
        this.menuCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            TooglePause();
            if (this.menuCanvas != null)
            {
                this.menuCanvas.SetActive(isPaused);
            }
            // Application.Quit();
        }
    }

    public static bool IsGamePaused
    {
        get
        {
            return isPaused;
        }
    }

    public static void TooglePause()
    {
        isPaused = !isPaused;
        Cursor.visible = isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
