using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxRotationSpeed;
    private Rigidbody _rig;
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
        _rig.AddRelativeForce(_velocity, ForceMode.VelocityChange);
        _rig.angularVelocity = new Vector3(
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed));
    }
}
