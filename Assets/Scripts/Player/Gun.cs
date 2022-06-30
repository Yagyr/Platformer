using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _shotPeriod = 0.2f;

    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;

    private float _timer;

    [SerializeField] private ParticleSystem _showEffect;

    protected void Start()
    {
        _flash.SetActive(false);
    }
    protected void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if (_timer > _shotPeriod && Input.GetMouseButton(0))
        {
            _timer = 0;
            Shot();
        }
    }

    public virtual void Shot()
    {
        var newBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = _spawn.forward * _bulletSpeed;
        _flash.SetActive(true);
        _shotSound.Play();
        Invoke(nameof(HideFlash), 0.12f);
        _showEffect.Play();
    }
    public void HideFlash()
    {
        _flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBullets)
    {
        
    }
}
