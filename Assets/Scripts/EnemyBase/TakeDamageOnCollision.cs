using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private bool _dieOnAnyCollision;
    [SerializeField] private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.TryGetComponent(out Bullet bullet))
            {
                _enemyHealth.TakeDamage(1);
            }
        }
        if (_dieOnAnyCollision)
        {
            _enemyHealth.TakeDamage(10000);
        }
    }
}
 