using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] private UnityEvent _eventsOnTriggerEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerMove>())
            {
                _eventsOnTriggerEnter.Invoke();
            }
        }
    }
}
