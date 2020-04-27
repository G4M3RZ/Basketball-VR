using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [HideInInspector]
    public int _score;
    private int _highScore;
    private TextMeshProUGUI _scoreText, _timeText;
    public TextMeshPro _highScoreText;

    private void Awake()
    {
        _scoreText = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        _timeText = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreText.text = _highScore.ToString();
    }

    private void Update()
    {
        _scoreText.text = "Score: " + _score;

        SaveScore();
    }

    void TimeInGame()
    {

    }
    void SaveScore() 
    {
        if(_highScore < _score)
        {
            _highScore++;
            _highScoreText.text = _highScore.ToString();
            PlayerPrefs.SetInt("HighScore", _highScore);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            PlayerPrefs.DeleteAll();
    }
}
