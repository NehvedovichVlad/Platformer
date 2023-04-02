using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.TakeDamage(_damageValue);
            }
        }
    }
}
