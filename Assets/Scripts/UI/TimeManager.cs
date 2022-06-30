using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _timeScale = 0.2f;
    private float _startFixedDeltaTime;
    void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = _timeScale;
        }
        else
        {
            Time.timeScale = 1f;
        }

        Time.fixedDeltaTime = _startFixedDeltaTime * _timeScale;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
