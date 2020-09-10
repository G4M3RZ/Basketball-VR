using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [HideInInspector]
    public int _score;
    public List<TextMeshPro> _text;

    private void Awake()
    {
        _text[0].text = "High Score" + "\n\r" + PlayerPrefs.GetInt("HighScore");
        _text[1].text = "Score" + "\n\r" + _score;
    }
    public void AddScore()
    {
        _score++;
        _text[1].text = "Score" + "\n\r" + _score;

        if(_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _text[0].text = "High Score" + "\n\r" + PlayerPrefs.GetInt("HighScore");
            PlayerPrefs.Save();
        }
    }
}