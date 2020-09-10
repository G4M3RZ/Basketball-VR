using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    [HideInInspector] public bool _isUp;
    [Range(0,10)] public float _highDistance;

    private Transform _mainCam, _hands;
    private float _currentPos;

    private void Awake()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _hands = transform.GetChild(0);
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, _mainCam.localEulerAngles.y, 0);
        HandsUpAndDown();
    }
    void HandsUpAndDown()
    {
        float condition = _mainCam.localEulerAngles.x - 360;
        float setPos = (condition <= -90) ? 0 : _highDistance;
        _isUp = (condition <= -90) ? false : true;

        _currentPos = Mathf.Lerp(_currentPos, setPos, Time.deltaTime * 5f);
        _hands.localPosition = new Vector3(0, _currentPos, _hands.localPosition.z);
    }
}