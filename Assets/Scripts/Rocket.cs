using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation ,targetRotation, Time.deltaTime * _rotationSpeed);
    }
}
