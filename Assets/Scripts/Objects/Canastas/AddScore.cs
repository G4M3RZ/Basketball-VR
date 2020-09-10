using UnityEngine;

public class AddScore : MonoBehaviour
{
    private ScoreController _score;
    private ParticleSystem _ps;
    
    private void Awake()
    {
        _score = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ScoreController>();
        _ps = transform.GetChild(0).GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _ps.Play();
            _score.AddScore();
        }
    }
}