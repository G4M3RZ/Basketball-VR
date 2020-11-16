using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public bool _gameOver;

    private void Update()
    {
        if (_gameOver)
        {
            float _rot = transform.localEulerAngles.y;
            _rot = Mathf.Lerp(_rot, 359.9f, Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, _rot, 0);
        }
    }
}