using System;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public Single RotationsPerMinute = 10.0f;

    void Update()
    {
        transform.Rotate(0f, 6.0f * RotationsPerMinute * Time.deltaTime, 0f);
    }
}