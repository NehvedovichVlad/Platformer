using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set;}

    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.isKinematic = true;
        Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
    }
}
