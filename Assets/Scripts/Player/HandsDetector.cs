using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsDetector : MonoBehaviour
{
    private GameObject _seleccion;
    private Rigidbody _ballRgb;
    private PlayerBody _pb;
    private bool _isGrabed;

    [Range(0,50)]
    public float _frontForce, _upForce;

    public Material[] _ball;

    private void Start()
    {
        _pb = GetComponentInParent<PlayerBody>();
    }
    private void Update()
    {
        CathBall();
 
        //cambiar forma de tirar
        if(Input.GetKeyDown(KeyCode.R) && _isGrabed && _seleccion.transform.localPosition == Vector3.zero)
            DropBall();
    }
    void CathBall()
    {
        if (_seleccion != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && !_isGrabed)  //cambiar forma de agarrar
            {
                _ballRgb = _seleccion.GetComponent<Rigidbody>();
                _seleccion.transform.parent = transform;
                _isGrabed = true;
            }
        }

        if (_isGrabed)
        {
            _ballRgb.constraints = RigidbodyConstraints.FreezeAll;
            _seleccion.transform.localRotation = Quaternion.Euler(0, -90, 0);
            _seleccion.transform.localPosition = Vector3.Lerp(_seleccion.transform.localPosition, Vector3.zero, Time.deltaTime * 10);

            if (_pb._isUp)
            {
                for (int i = 0; i < _ball.Length; i++)
                {
                    
                }
            }
            else
            {
                for (int i = 0; i < _ball.Length; i++)
                {

                }
            }
        }
    }
    void DropBall()
    {
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

    public void ObjectSelected(GameObject _obj)
    {
        if(!_isGrabed)
            _seleccion = _obj;
    }
    public void ObjectDeselect()
    {
        if(!_isGrabed)
            _seleccion = null;
    }
}
