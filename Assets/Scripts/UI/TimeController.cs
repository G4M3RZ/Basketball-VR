using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [Range(0, 300)] public int _timeInSeconds;
    [Range(-10, 10)] public float _speed;
    public TextMeshPro _text;
    private float _currentSpeed, _currentTimer;

    private void Awake()
    {
        _currentTimer = _timeInSeconds;
        TimePass(_currentTimer);
    }
    private void Update()
    {
        _currentSpeed = Time.deltaTime * _speed;
        _currentTimer += _currentSpeed;
        TimePass(_currentTimer);
    }
    void TimePass(float currentTime)
    {
        if (currentTime <= 0) currentTime = 0;

        float minutes = (int)currentTime / 60;
        float seconds = (int)currentTime % 60;

        _text.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}