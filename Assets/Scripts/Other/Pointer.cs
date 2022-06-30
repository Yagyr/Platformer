using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private Camera _playerCamera;
    void LateUpdate()
    {
        //Создаем луч
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

        //Создаем плоскость
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        //Точка на плоскости, в которую попадает луч
        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        _aim.position = point;

        //Следование прицела за курсором
        Vector3 toAim = _aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

    }
}
