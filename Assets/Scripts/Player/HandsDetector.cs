using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandsDetector : MonoBehaviour
{
    private GameObject _seleccion;
    private Vector3 _ballNewPos;
    private Rigidbody _ballRgb;
    private PlayerBody _pb;
    private bool _isGrabed;

    [Range(0,50)]
    public float _frontForce, _upForce;
    [Range(0,5)]
    public float _selectionSpeed;
    [Range(0,10)]
    public float _timeToDrop;

    private Image _selectionMark, _dropMark;
    private float _fillSelection, _fillDrop;

    private void Start()
    {
        _pb = GetComponentInParent<PlayerBody>();
        _selectionMark = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).GetChild(0).GetComponent<Image>();
        _dropMark = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).GetChild(1).GetComponent<Image>();
        _selectionMark.fillAmount = _fillSelection = _fillDrop = 0;
    }
    private void Update()
    {
        CathBall();
        ChangeMaterial();
        
        if (_seleccion != null)
        {
            if (_seleccion.transform.localPosition == Vector3.zero)
                DropBall();
        }
    }

    void CathBall()
    {
        if(_seleccion != null && !_isGrabed)
        {
            _selectionMark.fillAmount = _fillSelection;
            _fillSelection = (_fillSelection < 1) ? _fillSelection += Time.deltaTime * _selectionSpeed : _fillSelection = 1;

            if (_fillSelection == 1)
            {
                _ballRgb = _seleccion.GetComponent<Rigidbody>();
                _ballRgb.constraints = RigidbodyConstraints.FreezeAll;
                _seleccion.transform.parent = transform;
                _ballNewPos = _seleccion.transform.localPosition;
                _isGrabed = true;
            }
        }
        else
        {
            _selectionMark.fillAmount = _fillSelection = 0;
        }

        if (_isGrabed)
        {
            _seleccion.transform.localRotation = Quaternion.Euler(0, -90, 0);
            _seleccion.transform.localPosition = _ballNewPos;
            _ballNewPos = Vector3.Lerp(_ballNewPos, Vector3.zero, Time.deltaTime * 10);
        }
    }
    void ChangeMaterial()
    {
        if (_pb._isUp)
        {

        }
        else
        {

        }
    }
    void DropBall()
    {
        if (_seleccion != null && _isGrabed)
        {
            _dropMark.fillAmount = _fillDrop;
            _fillDrop = (_fillDrop < 1) ? _fillDrop += Time.deltaTime / _selectionSpeed : _fillDrop = 1;

            if(_fillDrop == 1)
            {
                _dropMark.fillAmount = _fillDrop = 0;

                _seleccion.transform.parent = null;
                _seleccion = null;

                _ballRgb.constraints = ~RigidbodyConstraints.FreezeAll;

                if (_pb._isUp)
                {
                    _ballRgb.AddForce(transform.forward * _frontForce * 10);
                    _ballRgb.AddForce(transform.up * _upForce * 20);
                }
                else
                {
                    _ballRgb.AddForce(transform.forward * _frontForce * 10);
                }

                _ballRgb = null;
                _isGrabed = false;
            }
        }
    }

    public void ObjectSelected(GameObject _obj)
    {
        if(!_isGrabed)
            _seleccion = _obj;
    }
    public void ObjectDeselect()
    {
        if (!_isGrabed)
            _seleccion = null;
    }
}