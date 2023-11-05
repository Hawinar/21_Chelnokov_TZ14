using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScoreTMP;
    [SerializeField] private TextMeshProUGUI _lastScoreTMP;

    [SerializeField] private GameObject _leaderboardUI;

    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _leaderboardBtn;
    void Start()
    {
        _leaderboardUI.SetActive(false);
        _playBtn.onClick.AddListener(() => Play());
        _leaderboardBtn.onClick.AddListener(() => ShowLeaderboard());

        _bestScoreTMP.text = $"Best Score\n{GameManager.BestScore}";
        _lastScoreTMP.text = $"Score\n{GameManager.LastScore}";
    }
    private void Play()
    {
        SceneManager.LoadScene("Game");
    }
    private void ShowLeaderboard()
    {
        _leaderboardUI.SetActive(true);
    }
}
