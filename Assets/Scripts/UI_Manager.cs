using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    //Handle to Text
    [SerializeField] private Text _scoreText;
   
    
    void Start()
    {
        _scoreText.text = $"Score: {0}";
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = $"Score: {playerScore}";
    }
    void Update()
    {
        
    }
}
