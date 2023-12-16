using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.PackageManager.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] private TMP_Text coinText;
    private int temporaryCoinAmount = 0; 
    private int savedCoinAmount = 0; 

    private int coinAmount;

    [SerializeField]
    private GameObject finishObj;

    [SerializeField]
    private Transform finishPos;

    public int SceneCoinAmount;

    [SerializeField]
    private int SceneID;

        private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        AudioPlayer.instance.PlayBGM(1);
        LoadSavedCoins();
        UpdateCoinText();
    }

    public void AddCoin(int amount)
    {
        temporaryCoinAmount += amount;
        UpdateCoinText();
    }
    public void SaveCoinsAtCheckpoint()
    {
        savedCoinAmount = temporaryCoinAmount;
    }
    public void ResetTemporaryCoins()
    {
        temporaryCoinAmount = savedCoinAmount; 
        UpdateCoinText();
    }
    public void UpdateCoinText()
    {
        coinText.text = "" + temporaryCoinAmount;
    }
    private void LoadSavedCoins()
    {
        if (PlayerPrefs.HasKey("SavedCoins"))
        {
            savedCoinAmount = PlayerPrefs.GetInt("SavedCoins");
        }
    }
    private void SaveCoins()
    {
        PlayerPrefs.SetInt("SavedCoins", savedCoinAmount);
    }

    private void GetCoin()
    {

        int amount = PlayerPrefs.GetInt("Money");
        coinAmount = amount;

        UpdateCoinText();
    }

    private void CheckCoin()
    {

        if (PlayerPrefs.HasKey("Money"))
        {
            GetCoin();
        }
        else
        {
            UpdateCoinText();
        }
    }


    public void SpawnFinish()
    {

        GameObject obj = Instantiate(finishObj, finishPos.position, Quaternion.identity, finishPos);
        Collectibles collectibles = obj.GetComponent<Collectibles>();
        collectibles.ItemSet();
    }

        public void CheckWinCondition()
    {
        if (PlayerPrefs.HasKey("WinCondition"))
        {
            int winCon = PlayerPrefs.GetInt("WinCondition");
            int winAmt = winCon + 1;
            PlayerPrefs.SetInt("WinCondition", winAmt);

            Debug.Log("Current Win" + winAmt);

            if (winAmt >= 3)
            {
                GameWin();
            }

            return;
        }

        if (!PlayerPrefs.HasKey("WinCondition"))
        {
            Debug.Log("Current Win" + 1);
            PlayerPrefs.SetInt("WinCondition", 1);
            return;
        }
    }

    private void GameWin()
    {
        AudioPlayer.instance.AudioValueSave();
        SaveCoins(); 
        SceneManager.LoadScene("MainMenu");
    }
}
