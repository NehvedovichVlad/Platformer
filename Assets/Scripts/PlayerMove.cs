using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed; 
    [SerializeField] private float _friction;
    [SerializeField] private bool _grounded;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Transform _colliderTransform;

    private Platform _currentPlatform;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        Move();
        SitDown();
    }

    private void Move()
    {
        float speedMultiplier = 1f;
        if (_grounded == false)
        { 
            speedMultiplier = 0.2f;

            if ((_rigidbody.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0) ||
                (_rigidbody.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0))
            {
                speedMultiplier = 0;
            }
        }


        _rigidbody.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);

        Vector3 relativeVelocity = _rigidbody.velocity;
        if (_currentPlatform)
            relativeVelocity = _rigidbody.velocity - _currentPlatform.Rigidbody.velocity;

        if(_grounded)
            _rigidbody.AddForce(-relativeVelocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);
    }
    private void Jump()
    {
       _rigidbody.AddForce(0f, _jumpSpeed, 0f, ForceMode.VelocityChange);
    }

    private void SitDown()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || _grounded == false)
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1, 0.5f, 1), Time.deltaTime * 15f);
        }
        else
        {
           _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 15f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
        {
            _currentPlatform = platform;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angle < 45f)
        {
            _grounded = true;
        }
 
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Sin>() || collision.gameObject.GetComponent<ABMovement>())
        {   
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }

        if (_currentPlatform)
        {
            if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
                if (_currentPlatform == platform)
                    _currentPlatform = null;     
        }
        
    }

}
