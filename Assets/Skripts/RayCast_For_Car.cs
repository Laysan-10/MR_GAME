using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RayCast_For_Car : MonoBehaviour
{
 
    public Transform rayOrigin; // Точка, из которой исходит луч
    public float rayLength = 10f; // Длина луча
    public Transform hand;


 
    public LayerMask layerMask;



    void Update()
    {
        //отображение двух рейкастов
        // Направление луча (вверх)
        Vector3 direction = transform.position;
        Vector3 direction_2 = transform.forward;

        // Начало луча
        Vector3 origin = rayOrigin.position;

        // Конец луча
        Vector3 end = origin + direction * rayLength;

        // Рисуем луч
        Debug.DrawLine(origin, end, Color.red);



        float dotProduct = Vector3.Dot(direction, direction_2);
        float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;


        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction_2, out hit, rayLength, layerMask))
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            Debug.DrawLine(transform.position, hit.point, Color.green);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + direction_2 * rayLength, Color.red);
        }

        Vector3 crossProduct = Vector3.Cross(direction, direction_2);
        float sign = Mathf.Sign(crossProduct.y); //или z, в зависимости от ориентации вашей системы координат

        angle *= sign;

        Debug.Log("Угол между лучами: " + angle);

        //узнать угол между двумя raycast
    }


}
