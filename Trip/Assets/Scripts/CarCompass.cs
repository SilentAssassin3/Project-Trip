using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCompass : MonoBehaviour
{
    public Vector3 NorthDirection;
    public Transform Player;
    public Quaternion CarDirection;

    public RectTransform Northlayer;
    public RectTransform CarLayer;

    public Transform CarPlace;

    // Update is called once per frame
    void Update()
    {
        ChangeNorthDirection();
        ChangeCarDirection();
    }

    public void ChangeNorthDirection()
    {
        NorthDirection.z = Player.eulerAngles.y;
        Northlayer.localEulerAngles = NorthDirection;
    }

    public void ChangeCarDirection()
    {
        Vector3 dir = transform.position - CarPlace.position;

        CarDirection = Quaternion.LookRotation(dir);

        CarDirection.z = -CarDirection.y;
        CarDirection.x = 0;
        CarDirection.y = 0;

        CarLayer.localRotation = CarDirection * Quaternion.Euler(NorthDirection);
    }
}
