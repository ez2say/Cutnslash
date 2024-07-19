using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Root
{
    public class Level : MonoBehaviour
    {
        public TextMeshProUGUI ScoreText => _scoreText;

        [SerializeField] private TextMeshProUGUI _scoreText;

        public TextMeshProUGUI livesText;

        public TextMeshProUGUI gameOverText;

        public Button restartButton;

        public bool gameIsOver;

        private int _score;

        private int _lives;

        [SerializeField] private SpawnObjects _spawnObjects;

        public GameObject levelMenu;

        public void Construct()
        {
            _score = 0;
            _lives = 3;
        }

        public void UpdateTheScore(int scorePointsToAdd)
        {
            _score += scorePointsToAdd;
            _scoreText.text = _score.ToString();
        }


        public void UpdateLives()
        {
            if (gameIsOver == false)
            {
                _lives--;
                livesText.text = "Lives: " + _lives;

                if (_lives == 0)
                {
                    GameOver();
                }
            }

        }

        public void GameOver()
        {
            gameIsOver = true;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }
}
