using UnityEngine;
using UnityEngine.Events;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 1 ;
    [SerializeField] private UnityEvent _eventOnTakeDamage;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if (_health <= 0)
        {
            Die();
        }
        _eventOnTakeDamage?.Invoke();
    }

    public void Die()
    {
        if (gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }
}
    