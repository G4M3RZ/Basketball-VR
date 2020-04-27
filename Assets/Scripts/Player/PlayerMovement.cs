using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject _cam;
    private CharacterController _player;
    
    [Range(0,10)]
    public float _speed;
    private float _gravity, _fallVelocity;
    private Vector3 _playerInput, _movePlayer,_camForward, _camRight;

    private void Start()
    {
        _gravity = Physics.gravity.y;
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
        _player = GetComponent<CharacterController>();
    }
    private void Update()
    {
        #region MovimientoPlayer
        float _h, _v;
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");

        _playerInput = new Vector3(_h, 0, _v);
        _playerInput = Vector3.ClampMagnitude(_playerInput, 1);

        GetCamDirection();

        _movePlayer = _playerInput.x * _camRight + _playerInput.z * _camForward;
        _movePlayer = _movePlayer * _speed;

        SetGravity();

        _player.Move(_movePlayer * Time.deltaTime);
        #endregion
    }

    void GetCamDirection()
    {
        _camForward = _cam.transform.forward;
        _camRight = _cam.transform.right;

        _camForward.y = _camRight.y = 0;

        _camForward = _camForward.normalized;
        _camRight = _camRight.normalized;
    }
    void SetGravity()
    {
        if (_player.isGrounded)
        {
            _fallVelocity = _gravity * Time.deltaTime;
            _movePlayer.y = _fallVelocity;
        }
        else
        {
            _fallVelocity += _gravity * Time.deltaTime;
            _movePlayer.y = _fallVelocity;
        }
    }
}
