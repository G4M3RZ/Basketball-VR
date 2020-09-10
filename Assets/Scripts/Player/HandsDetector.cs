using System.Collections;
using UnityEngine;

public class HandsDetector : MonoBehaviour
{
    private Transform _ball;
    public Material _ballMat;
    private Rigidbody _ballRgb;

    public GvrReticlePointer _reticle;
    private PlayerBody _pb;
    private bool _isGrabed;

    [Range(0,50)] public float _frontForce, _upForce;
    [Range(0, 5)] public float _catchSpeed, _dropTime;

    private void Awake()
    {
        _ballMat.color = Color.white;
        _reticle.reticleGrowthSpeed = _catchSpeed * 2;
        _pb = GetComponentInParent<PlayerBody>();
    }
    private void Update()
    {
        if (_ball != null && _isGrabed)
        {
            _ball.localPosition = Vector3.Lerp(_ball.localPosition, Vector3.zero, Time.deltaTime * 10);
            ChangeMaterial();
        }
    }
    void ChangeMaterial()
    {
        Color setAlpha = _ballMat.color;
        setAlpha.a = (_pb._isUp) ? 0.5f : 1;
        _ballMat.color = setAlpha;
    }
    IEnumerator GrabBall(Transform ball)
    {
        yield return new WaitUntil(() => _reticle.ReticleInnerDiameter >= 0.025f);

        _ball = ball;
        _ballRgb = _ball.GetComponent<Rigidbody>();
        _ballRgb.constraints = RigidbodyConstraints.FreezeAll;
        _ball.parent = transform;
        _ball.localRotation = Quaternion.Euler(0, -90, 0);
        _isGrabed = true;

        yield return new WaitUntil(() => _ball.localPosition == Vector3.zero);

        StartCoroutine(DropBall());
    }
    IEnumerator DropBall()
    {
        yield return new WaitForSeconds(_dropTime);

        _isGrabed = false;
        _ball.parent = null;
        _ballRgb.constraints = ~RigidbodyConstraints.FreezeAll;

        Vector3 upForce = transform.up * _upForce * 20;
        Vector3 frontFoce = transform.forward *_frontForce * 10;
        Vector3 ballDirection = (_pb._isUp) ? frontFoce + upForce : frontFoce;
        _ballRgb.AddForce(ballDirection);

        _ballMat.color = Color.white;
        _ball = null;
        _ballRgb = null;
    }
    public void ObjectSelected(Transform _obj)
    {
        if (!_isGrabed)
            StartCoroutine(GrabBall(_obj));
    }
    public void ObjectDeselect()
    {
        if (!_isGrabed)
            StopAllCoroutines();
    }
}