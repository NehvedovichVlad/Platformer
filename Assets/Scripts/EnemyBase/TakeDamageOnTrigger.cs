using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private bool _dieOnAnyCollision;
    [SerializeField] private EnemyHealth _enemyHealth;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.TryGetComponent(out Bullet bullet))
            {
                _enemyHealth.TakeDamage(1);
            }
        }
        if (_dieOnAnyCollision)
        {
            if (!other.isTrigger)     
                _enemyHealth.TakeDamage(10000);
        }
    }
   
}
