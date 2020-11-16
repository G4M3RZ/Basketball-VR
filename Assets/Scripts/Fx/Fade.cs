using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public string _sceneName;
    private Material _fadeMat;
    private Color _color;

    private void Start()
    {
        _fadeMat = GetComponent<MeshRenderer>().material;
        _color = Color.black;
        _color.a = (_sceneName != "") ? 0 : 1;

        _fadeMat.color = _color;
    }
    private void Update()
    {
        _color.a = (_sceneName != "") ? _color.a += Time.deltaTime : _color.a -= Time.deltaTime;
        _color.a = Mathf.Clamp(_color.a, 0, 1);
        _fadeMat.color = _color;

        if (_color.a == 1)
            SceneManager.LoadScene(_sceneName);
        else if(_color.a == 0)
            Destroy(this.gameObject);
    }
}