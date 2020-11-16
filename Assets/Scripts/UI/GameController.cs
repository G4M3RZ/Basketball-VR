using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform _hands;
    public GameObject _winObject, _fade;
    public string _newSceneName;
    TimeController _time;
    FinalScore _score;

    private void Awake()
    {
        _time = GetComponent<TimeController>();
        _score = transform.GetChild(0).GetComponent<FinalScore>();
        _time._setTimeGame = false;

        StartCoroutine(WaitToStartGame());
        StartCoroutine(WaitToEndGame());
    }
    IEnumerator WaitToStartGame()
    {
        yield return new WaitUntil(() => _hands.childCount > 0);

        Transform ball = _hands.GetChild(0);
        Destroy(ball.GetChild(ball.childCount - 1).gameObject);
        _time._setTimeGame = true;
    }
    IEnumerator WaitToEndGame()
    {
        _score._gameOver = false;
        _winObject.SetActive(false);

        yield return new WaitUntil(() => _time._currentTimer <= 0);

        _score._gameOver = true;
        _winObject.SetActive(true);

        yield return new WaitForSeconds(10f);

        GameObject fade = Instantiate(_fade, GameObject.FindGameObjectWithTag("MainCamera").transform);
        Fade sceneName = fade.GetComponent<Fade>();
        sceneName._sceneName = _newSceneName;
    }
}