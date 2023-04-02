using UnityEngine;

public class ABMovement : Platform
{
    [SerializeField] private Transform _targetA;
    [SerializeField] private Transform _targetB;
    [SerializeField] private float _speed = 0.5f;

     private Vector3 _target;

    void Awake()
    {
        base.Awake();

        _target = _targetA.position;
        _targetA.parent = null;
        _targetB.parent = null;
    }

    void FixedUpdate()
    {
        Rigidbody.MovePosition(Vector3.MoveTowards(transform.position, _target, Time.deltaTime * _speed));


        if (transform.position == _target)
        {
            _target = _targetB.position;
        }

        if (transform.position == _targetB.position)
        {
            _target = _targetA.position;

        }
    }

}