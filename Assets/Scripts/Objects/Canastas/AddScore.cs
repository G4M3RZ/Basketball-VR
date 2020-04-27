using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddScore : MonoBehaviour
{
    private CanvasController _canvasController;
    
    private void Awake()
    {
        _canvasController = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).GetComponent<CanvasController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
            _canvasController._score++;
    }
}
