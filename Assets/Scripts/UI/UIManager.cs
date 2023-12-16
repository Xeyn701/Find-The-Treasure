using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private GameObject PauseScreen;

    [SerializeField]
    private GameObject PlayScreen;

    [SerializeField]
    private GameObject QuestionScreen;

    [SerializeField]
    private Slider sfxSlider;

    [SerializeField]
    private Slider bgmSlider;

    private void Awake()
    {
        gameOverScreen.SetActive(false);

        if (sfxSlider != null)
        {
            sfxSlider.onValueChanged.AddListener(OnSfxChanged);
            if (PlayerPrefs.HasKey("sfxVol"))
            {
                sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
            }
        }

        if (bgmSlider != null)
        {
            bgmSlider.onValueChanged.AddListener(OnBgmChanged);
            if (PlayerPrefs.HasKey("bgmVol"))
            {
                bgmSlider.value = PlayerPrefs.GetFloat("bgmVol");
            }
        }
    }
    public void PauseGame()
    {

        PlayButtonSound();
        Time.timeScale = 0;
        QuestionScreen.SetActive(false);
        PlayScreen.SetActive(false);
        PauseScreen.SetActive(true);

        if (PlayerPrefs.HasKey("bgmVol"))
        {
            bgmSlider.value = PlayerPrefs.GetFloat("bgmVol");
        }

        if (PlayerPrefs.HasKey("sfxVol"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PlayScreen.SetActive(true);
        PauseScreen.SetActive(false);
        QuestionScreen.SetActive(false);
    }

    public void QuestionButton()
    {
        Time.timeScale = 0;
        PlayScreen.SetActive(false);
        PauseScreen.SetActive(false);
        QuestionScreen.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        PlayButtonSound();
        SceneManager.LoadScene("MainMenu");
    }

    private void OnSfxChanged(float value)
    {
        PlayButtonSound();
        AudioPlayer.instance.ChangeSfxVolume(value);
    }
    private void OnBgmChanged(float value)
    {
        PlayButtonSound();
        AudioPlayer.instance.ChangeBgmVolume(value);
    }


    public void PlayButtonSound()
    {
        AudioPlayer.instance.PlaySFX(3);
    }
    #region Game Over
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}
