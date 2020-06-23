using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _restartGame;
    [SerializeField] private Sprite[] _livesSprites;
    [SerializeField] private Image _LivesImg;
    private GameManager _gameManager;
    
    
    void Start()
    {
        
        _scoreText.text = $"Score: {0}";
        _gameOverText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.Log("Game Manager is NULL");
        }
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = $"Score: {playerScore}";
    }

    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _livesSprites[currentLives];
        
        if (currentLives == 0)
        {
           GameOverSequence();
        }
    }

    public void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartGame.gameObject.SetActive(true);
        StartCoroutine(TextFlickerRoutine());
    }
    
    
    
    IEnumerator TextFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
