using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationSpeed = 1f;

    private Transform _player;
    void Start()
    {
        _player = FindObjectOfType<PlayerMove>().transform;

        Vector3 toPlayer = _player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toPlayer, Vector3.forward);
    }

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;

        Vector3 toPlayer = _player.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }
}
