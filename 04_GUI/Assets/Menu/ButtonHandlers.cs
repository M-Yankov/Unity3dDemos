using UnityEngine;
using System.Collections;

public class ButtonHandlers : MonoBehaviour
{
    private GameObject canvasMenu;
    private GameObject buttonsWrapper;
    private GameObject settingsWrapper;

    void Start()
    {
        this.canvasMenu = GameObject.FindGameObjectWithTag("MenuCamera");
        this.buttonsWrapper = GameObject.FindGameObjectWithTag("ButtonsWrapper");
        this.settingsWrapper = GameObject.FindGameObjectWithTag("Setting");
    }

    public void ResumeButtonHanlder()
    {
        ConfigScript.TooglePause();
        this.canvasMenu.SetActive(false);
    }

    public void ExitHandler()
    {
        Application.Quit();
    }

    public void ToogleSettingsHandler()
    {
        if (this.buttonsWrapper == null)
        {
            throw new System.NullReferenceException("CannotFind ButtonsWrapper");
        }

        if (this.settingsWrapper == null)
        {
            throw new System.NullReferenceException("CannotFind SettingsWrapper");
        }

        this.buttonsWrapper.SetActive(!this.buttonsWrapper.activeSelf);
        this.settingsWrapper.SetActive(!this.settingsWrapper.activeSelf);
    }
}
