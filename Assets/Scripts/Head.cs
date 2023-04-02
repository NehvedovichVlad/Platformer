using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Transform _target;
    void Update()
    {
        transform.position = _target.position; 
    }
}
