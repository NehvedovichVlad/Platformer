using UnityEngine;

public class BatchPrefavCreator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawns;

    [ContextMenu("Create")]
    public void Create()
    {
        for (int i = 0; i < _spawns.Length; i++)
        {
            Instantiate(_prefab, _spawns[i].position, _spawns[i].rotation);
        }
    }
    
}
