using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToAim : MonoBehaviour
{
    [SerializeField] private Transform _body;
    [SerializeField] private Pointer _pointer;

    private float _yEuler;
    void LateUpdate()
    {

        if (_pointer.ToAim.x < 0)
        {
            _yEuler = Mathf.Lerp(_yEuler, 45, Time.deltaTime * 7f);
        }
        else
        {
            _yEuler = Mathf.Lerp(_yEuler, -45, Time.deltaTime * 7f);
        }
        _body.localEulerAngles = new Vector3(0, _yEuler, 0);
    }
}
    