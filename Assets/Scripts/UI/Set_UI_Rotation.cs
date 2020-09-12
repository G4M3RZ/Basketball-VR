using UnityEngine;

public class Set_UI_Rotation : MonoBehaviour
{
    public Transform _target;
    private void Awake()
    {
        if(_target != null)
        {
            Vector3 turnBack = new Vector3(-1, 1, 1);
            transform.localScale = turnBack;
            transform.LookAt(_target);
            Destroy(this);
        }
    }
}