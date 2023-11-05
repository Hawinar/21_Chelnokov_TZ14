using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Button _jumpBtn;

    [SerializeField] private float _y;
    void Start()
    {
        _jumpBtn.onClick.AddListener(() => Jump());
        _gameOverUI.SetActive(false);

        Time.timeScale = 1f;
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(new Vector2(0, _y));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Obstacle")
        {
            _gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
        if (collision.gameObject.tag == "Finish")
        {
            SaveResults.SaveResults.Save();
            GameManager.LastScore = GameManager.Score;
            if (GameManager.BestScore < GameManager.Score)
                GameManager.BestScore = GameManager.Score;
            GameManager.Score = 0;
            GameManager.SpawnedCount = 0;
            SceneManager.LoadScene("MainMenu");
        }
        if(collision.gameObject.tag == "Border")
        {
            _gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }

    }
}
