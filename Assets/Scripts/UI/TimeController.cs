using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [Range(0, 300)] public int _timeInSeconds;
    [Range(-10, 10)] public float _speed;
    public TextMeshPro _text;

    public List<GameObject> _tutorial;

    private float _currentSpeed, _currentTimer;
    private bool _startTimer;

    private void Awake()
    {
        _currentTimer = _timeInSeconds;
        TimePass(_currentTimer);
        StartCoroutine(WaitToStart());
    }
    private void Update()
    {
        if (_startTimer)
        {
            _currentSpeed = Time.deltaTime * _speed;
            _currentTimer += _currentSpeed;
            TimePass(_currentTimer);
        }
    }
    void TimePass(float currentTime)
    {
        if (currentTime <= 0) currentTime = 0;

        float minutes = (int)currentTime / 60;
        float seconds = (int)currentTime % 60;

        _text.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    IEnumerator WaitToStart()
    {
        yield return new WaitUntil(() => _tutorial[0].transform.childCount > 0);
        Destroy(_tutorial[1]);
        _startTimer = true;
    }
}