using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _transform;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _lerpSpeed;

    public bool grounded;
    private int _jumpFrameCounter = 0;

    void Update()
    {
        //����������
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || grounded == false)
        {
            _transform.localScale = Vector3.Lerp(_transform.localScale, new Vector3(1f, 0.5f, 1f), _lerpSpeed * Time.deltaTime);
        }
        else
        {
            _transform.localScale = Vector3.Lerp(_transform.localScale, new Vector3(1f, 1f, 1f), _lerpSpeed * Time.deltaTime);
        }
        //������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                Jump();
            }
        }
    }

    public void Jump()
    {
        _rigidbody.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }

    private void FixedUpdate()
    {
        float speedMultipier = 1f;

        //����������� �������� �� ����� ������
        if (grounded == false)
        {
            speedMultipier = 0.1f;
            if (_rigidbody.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultipier = 0f;
            }

            if (_rigidbody.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultipier = 0f;
            }
        }

        //������������
        _rigidbody.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultipier, 0, 0, ForceMode.VelocityChange);

        if (grounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }

        _jumpFrameCounter++;
        if (_jumpFrameCounter == 2)
        {
            _rigidbody.freezeRotation = false;
            _rigidbody.AddRelativeTorque(0, 0, -10f, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //����������� ����������� ������ �� ����
        for (int i = 0; i < collision.contacts.Length; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45f)
            {
                grounded = true;
                _rigidbody.freezeRotation = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
