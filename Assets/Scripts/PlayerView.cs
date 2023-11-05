using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private GameObject _gameOverUI;

    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _goMainMenu;

    private void Start()
    {
        _gameOverUI.SetActive(false);
        _restartBtn.onClick.AddListener(() => Restart());
        _goMainMenu.onClick.AddListener(() => GoToMainMenu());
    }

    // Update is called once per frame
    private void Update()
    {
        _scoreTMP.text = GameManager.Score.ToString();
    }
    private void Restart()
    {
        SceneManager.LoadScene("Game");
        SaveResults.SaveResults.Save();
        GameManager.LastScore = GameManager.Score;
        if(GameManager.BestScore < GameManager.Score)
            GameManager.BestScore = GameManager.Score;
        GameManager.Score = 0;
        GameManager.SpawnedCount = 0;
    }
    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SaveResults.SaveResults.Save();
        GameManager.LastScore = GameManager.Score;
        if (GameManager.BestScore < GameManager.Score)
            GameManager.BestScore = GameManager.Score;
        GameManager.Score = 0;
        GameManager.SpawnedCount = 0;
    }

}
