using UnityEngine;

public class FollowToPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] float _lerpRate;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, _lerpRate * Time.deltaTime);
    }
}
