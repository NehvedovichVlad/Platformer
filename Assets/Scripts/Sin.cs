using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Sin : Platform
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _amplitude = 0.5f;

    private float _startPosition; 

    private void Awake()
    {
        base.Awake();

        _startPosition = transform.position.y;
    }

    private void FixedUpdate()
    {
        Rigidbody.MovePosition(new Vector3(transform.position.x, Mathf.Sin(Time.time * _speed) * _amplitude + _startPosition, 0));
    }

}
