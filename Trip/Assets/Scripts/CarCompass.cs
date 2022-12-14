using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarCompass : MonoBehaviour
{
    public Vector3 NorthDirection;
    public GameObject player;
    public Quaternion CarDirection;

    public RectTransform Northlayer;
    public RectTransform CarLayer;

    public GameObject carPlace;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = carPlace.transform.position - player.transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, dir);
        CarLayer.rotation = Quaternion.Euler(0, 0, angle);

        //ChangeNorthDirection();
        //ChangeCarDirection();
    }
    /*
    public void ChangeNorthDirection()
    {
        NorthDirection.z = Player.eulerAngles.y;
        Northlayer.localEulerAngles = NorthDirection;
    }

    public void ChangeCarDirection()
    {
        Vector2 dir = Player.transform.position - CarPlace.transform.position;

        CarDirection = Quaternion.LookRotation(dir);

        CarDirection.z = -CarDirection.y;
        CarDirection.x = 0;
        CarDirection.y = 0;

        CarLayer.localRotation = CarDirection * Quaternion.Euler(NorthDirection);
    }

    */
}
