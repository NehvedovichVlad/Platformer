using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> ObjectsForActivate = new();
    [SerializeField] private Transform _playerTransform;
    private void Start()
    {
        var allObjects = FindObjectsOfType<ActivateByDistance>();
        foreach (var item in allObjects)
        {
            ObjectsForActivate.Add(item);
        }
    }

    private void Update()
    {
        foreach (var item in ObjectsForActivate)
        {
            item.CheckDistance(_playerTransform.position);
        }
    }
}
