using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotations : MonoBehaviour
{
    [SerializeField] float maxXRotationSpeed;
    [SerializeField] float maxYRotationSpeed;
    [SerializeField] float maxZRotationSpeed;

    float secondsX;
    float secondsY;
    float secondsZ;

    [SerializeField] float XAnimationDuration;
    [SerializeField] float YAnimationDuration;
    [SerializeField] float ZAnimationDuration;

    [SerializeField] AnimationCurve ease;

    void Start()
    {
        StartCoroutine(xRotacion());
        StartCoroutine(YRotacion());
        StartCoroutine(ZRotacion());
    }
    
    public IEnumerator xRotacion()
    {
        while (true)
        {
            while (secondsX < XAnimationDuration)
            {
                secondsX += Time.deltaTime;
                float X = Mathf.Lerp(maxXRotationSpeed, -maxXRotationSpeed, ease.Evaluate(secondsX / XAnimationDuration));

                Vector3 A = new Vector3(X, 0, 0);

                transform.Rotate(A * Time.deltaTime);

                yield return null;
            }
            secondsX = 0;
            yield return null;
        }
    }
    public IEnumerator YRotacion()
    {
        while (true)
        {
            while (secondsY < YAnimationDuration)
            {
                secondsY += Time.deltaTime;
                float Y = Mathf.Lerp(maxYRotationSpeed, -maxYRotationSpeed, ease.Evaluate(secondsY / YAnimationDuration));

                Vector3 B = new Vector3(0, Y, 0);

                transform.Rotate(B * Time.deltaTime);

                yield return null;
            }
            secondsY = 0;
            yield return null;
        }
    }
    public IEnumerator ZRotacion()
    {
        while (true)
        {
            while (secondsZ < ZAnimationDuration)
            {
                secondsZ += Time.deltaTime;
                float Z = Mathf.Lerp(maxZRotationSpeed, -maxZRotationSpeed, ease.Evaluate(secondsZ / ZAnimationDuration));

                Vector3 C = new Vector3(0, 0, Z);

                transform.Rotate(C * Time.deltaTime);

                yield return null;
            }
            secondsZ = 0;
            yield return null;
        }
    }
}


/*
 tiene que girar

interpolando la velocidad en la que gira
 */