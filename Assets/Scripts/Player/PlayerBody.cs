using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private GameObject _mainCam, _hands;
    [Range(0,10)]
    public float _highDistance;
    [HideInInspector]
    public bool _isUp;

    private void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        _hands = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        TurnBody();
        HandsUpDown();
    }

    void TurnBody()
    {
        transform.rotation = Quaternion.Euler(0, _mainCam.transform.localEulerAngles.y, 0);
    }
    void HandsUpDown()
    {
        Vector3 startPos, endPos;

        startPos = new Vector3(0, 0, _hands.transform.localPosition.z);
        endPos = new Vector3(0, _highDistance, _hands.transform.localPosition.z);

        if (_mainCam.transform.localEulerAngles.x - 360 <= -90)
        {
            _isUp = false;
            _hands.transform.localPosition = Vector3.Lerp(_hands.transform.localPosition, startPos, Time.deltaTime * 5f);
        }
        else
        {
            _isUp = true;
            _hands.transform.localPosition = Vector3.Lerp(_hands.transform.localPosition, endPos, Time.deltaTime * 5f);
        }
    }
}
