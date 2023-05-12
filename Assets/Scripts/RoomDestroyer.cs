using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ClosedCenter"))
            Destroy(other.gameObject.transform.parent.gameObject);
    }
}
