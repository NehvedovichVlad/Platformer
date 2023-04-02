using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] private int _healthValue;
    private bool _isActive = true;
    private void OnTriggerEnter(Collider other)
    {
        if (_isActive == false) return;
        
        if (other.attachedRigidbody.TryGetComponent(out PlayerHealth playerHealth))
        {
            _isActive = false;
            playerHealth.AddHealth(_healthValue);

            Destroy(gameObject);
        }        
    }
}
 