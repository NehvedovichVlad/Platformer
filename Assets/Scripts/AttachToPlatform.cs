using UnityEngine;


public class AttachToPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMove>(out PlayerMove playerMove))
        {
            playerMove.transform.parent = transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMove>(out PlayerMove playerMove))
        {
            playerMove.transform.parent = null;
        }
    }
}
