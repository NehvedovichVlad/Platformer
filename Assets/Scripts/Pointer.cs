using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private Camera _playerCamera;
    private Plane _plane;

    private Vector3 _toAim;
    public Vector3 ToAim { get { return _toAim; } }

    private void Start()
    {
        _plane = new Plane(-Vector3.forward, Vector3.zero);
    }   
    private void LateUpdate()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

        float distance;
        _plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        _aim.position = point;

        _toAim = _aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(ToAim);
    }
}
