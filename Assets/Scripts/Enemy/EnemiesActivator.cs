using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemiesActivator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private float _distanceToEnemy = 20f;

    [SerializeField] Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].gameObject == null)
            {
                _enemies.Remove(_enemies[i].gameObject);
                return;
            }

            float distance = Vector3.Distance(_playerTransform.position, _enemies[i].transform.position);
            if (distance < _distanceToEnemy)
            {
                _enemies[i].gameObject.SetActive(true);
            }
            else
            {
                _enemies[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(_playerTransform.position, Vector3.forward, _distanceToEnemy);
    }
}
