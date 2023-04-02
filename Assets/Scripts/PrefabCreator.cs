using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawn;

    private void Create()
    {
        Instantiate(_prefab, _spawn.position, _spawn.rotation);
    }
}
