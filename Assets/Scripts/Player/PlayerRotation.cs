using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private float _speedRotation = 5f;

    private void Update()
    {
        //������� ������ �� ��������
        float rotationY = transform.position.x > _aim.position.x ? 50f : -50f;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, rotationY, 0), _speedRotation * Time.deltaTime);
    }
}
