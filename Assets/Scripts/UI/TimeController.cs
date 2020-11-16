using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [Range(0, 300)] public int _timeInSeconds;
    [Range(-10, 10)] public float _speed;
    public TextMeshPro _text;

    [HideInInspector] public float _currentTimer;
    [HideInInspector] public bool _setTimeGame;

    private void Awake()
    {
        _currentTimer = _timeInSeconds;
        TimePass(_currentTimer);
    }
    private void Update()
    {
        if (_setTimeGame)
        {
            _currentTimer += Time.deltaTime * _speed;
            TimePass(_currentTimer);
        }
    }
    void TimePass(float currentTime)
    {
        if (currentTime <= 0) currentTime = 0;

        float minutes = (int)currentTime / 60;
        float seconds = (int)currentTime % 60;

        _text.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        _text.color = (currentTime <= 15) ? Color.red : Color.white;
    }
}