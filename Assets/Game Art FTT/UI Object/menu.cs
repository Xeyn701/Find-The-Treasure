using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject menupanel, infopanel, messagepanel, questionpanel, settingpanel,
        soundpanel, lightpanel, supportpanel, petapanel, pausepanel;

    [SerializeField]
    private Slider sfxSlider;

    [SerializeField]
    private Slider bgmSlider;

    private void Awake()
    {
        sfxSlider.onValueChanged.AddListener(this.OnSfxChanged);
        bgmSlider.onValueChanged.AddListener(this.OnBgmChanged);
    }



    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer.instance.PlayBGM(0);
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnSfxChanged(float value)
    {
        StartButton();
        AudioPlayer.instance.ChangeSfxVolume(value);
    }
    private void OnBgmChanged(float value)
    {
        StartButton();
        AudioPlayer.instance.ChangeBgmVolume(value);
    }

    void StartButton()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
        messagepanel.SetActive(false);
        questionpanel.SetActive(false);
        settingpanel.SetActive(false);
        pausepanel.SetActive(false);
    } 

    public void StartButton(string scenename)
    {
        PlayerPrefs.SetInt("playerHealth", 3);
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
        StartButton();
        menupanel.SetActive(true);
        settingpanel.SetActive(false);
        menupanel.SetActive(false);
        infopanel.SetActive(false);
        messagepanel.SetActive(false);
        questionpanel.SetActive(false);
        settingpanel.SetActive(false);
        soundpanel.SetActive(true);

        if (PlayerPrefs.HasKey("bgmVol"))
        {
            bgmSlider.value = PlayerPrefs.GetFloat("bgmVol");
        }

        if (PlayerPrefs.HasKey("sfxVol"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        }

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
        Application.Quit(); // Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Exits play mode (will only be executed in the editor)
#endif
        Debug.Log("udah ketekan kok");
    }
}