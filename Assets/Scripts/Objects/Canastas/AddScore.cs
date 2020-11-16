using UnityEngine;

public class AddScore : MonoBehaviour
{
    private ParticleSystem _ps;
    private ScoreController _score;
    
    private void Awake()
    {
        _ps = GetComponent<ParticleSystem>();
        _score = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ScoreController>();
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