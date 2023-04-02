using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaeToTargetEuler : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rightEuler;

    private Vector3 _targetEuler;

    [SerializeField] private float _rotationSpeed;


    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation , Quaternion.Euler(_targetEuler), Time.deltaTime * _rotationSpeed);
    }
    public void RotateLeft()
    {
        _targetEuler = _leftEuler;
    }

    public void RotateRight()
    {
        _targetEuler = _rightEuler;
    }
}
