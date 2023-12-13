using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject menupanel, infopanel, messagepanel, questionpanel, settingpanel,
        soundpanel, lightpanel, supportpanel, petapanel, pausepanel;


    // Start is called before the first frame update
    void StartButton()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
        messagepanel.SetActive(false);
        questionpanel.SetActive(false);
        settingpanel.SetActive(false);
        pausepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartButton(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void infoButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(true);
        messagepanel.SetActive(false);
        questionpanel.SetActive(false);
        settingpanel.SetActive(false);
    }
    public void messageButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(false);
        messagepanel.SetActive(true);
        questionpanel.SetActive(false);
        settingpanel.SetActive(false);
    }
    public void questionButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(false);
        messagepanel.SetActive(false);
        questionpanel.SetActive(true);
        settingpanel.SetActive(false);
    }
    public void settingButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(false);
        messagepanel.SetActive(false);
        questionpanel.SetActive(false);
        settingpanel.SetActive(true);
    }
    public void lightButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(false);
        messagepanel.SetActive(false);
        questionpanel.SetActive(false);
        settingpanel.SetActive(false);
        soundpanel.SetActive(false);
        lightpanel.SetActive(true);
    }
    public void soundButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(false);
        messagepanel.SetActive(false);
        questionpanel.SetActive(false);
        settingpanel.SetActive(false);
        soundpanel.SetActive(true);
    }
    public void supportButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(false);
        messagepanel.SetActive(false);
        questionpanel.SetActive(false);
        settingpanel.SetActive(false);
        soundpanel.SetActive(false);
        supportpanel.SetActive(true);
    }
    public void petaButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(false);
        messagepanel.SetActive(false);
        questionpanel.SetActive(false);
        settingpanel.SetActive(false);
        soundpanel.SetActive(false);
        supportpanel.SetActive(false);
        petapanel.SetActive(true);
    }
    public void homeButton()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
        messagepanel.SetActive(false);
        questionpanel.SetActive(false);
        settingpanel.SetActive(false);
        soundpanel.SetActive(false);
        supportpanel.SetActive(false);
        petapanel.SetActive(false);
        pausepanel.SetActive(false);
    }
    public void exitButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(false);
        messagepanel.SetActive(false);
        questionpanel.SetActive(false);
        settingpanel.SetActive(true);
        soundpanel.SetActive(false);
        lightpanel.SetActive(false);
        supportpanel.SetActive(false);
    }
    public void quitbutton()
    {
        Application.Quit();
        Debug.Log("udah ketekan kok");
    }
}