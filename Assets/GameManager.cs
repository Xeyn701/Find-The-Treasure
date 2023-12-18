using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
        public static GameManager instance;

        [SerializeField] private TMP_Text coinText;
        private int temporaryCoinAmount = 0;

        [SerializeField] private GameObject finishObj;
        private int totalCoinsInScene = 45;


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
            CheckWinCondition();
        }

        public void AddCoin(int amount)
        {
            temporaryCoinAmount += amount;
            UpdateCoinText();

            if (temporaryCoinAmount >= totalCoinsInScene)
            {
                ActivateFinishObject();
            }
        }

        private void ActivateFinishObject()
        {
            if (finishObj != null)
            {
                finishObj.SetActive(true);
            }
        }
        public void SaveCoinsAtCheckpoint()
        {
            PlayerPrefs.SetInt("SavedCoins", temporaryCoinAmount);
        }

        public void ResetTemporaryCoins()
        {
            temporaryCoinAmount = PlayerPrefs.GetInt("SavedCoins", 0);
            UpdateCoinText();
        }

        public void UpdateCoinText()
        {
            coinText.text = temporaryCoinAmount + "/" + totalCoinsInScene;
        }

        private void LoadSavedCoins()
        {
            temporaryCoinAmount = PlayerPrefs.GetInt("SavedCoins", 0);
        }

        public void CheckWinCondition()
        {
            if (PlayerPrefs.HasKey("WinCondition"))
            {
                int winCon = PlayerPrefs.GetInt("WinCondition");
                int winAmt = winCon + 1;
                PlayerPrefs.SetInt("WinCondition", winAmt);

                Debug.Log("Current Win: " + winAmt);

                if (winAmt >= 3)
                {
                    GameWin();
                }

                return;
            }

            if (!PlayerPrefs.HasKey("WinCondition"))
            {
                Debug.Log("Current Win: 1");
                PlayerPrefs.SetInt("WinCondition", 1);
            }
        }

        private void GameWin()
        {
            PlayerPrefs.SetInt("SavedCoins", 0);
        }
    
}