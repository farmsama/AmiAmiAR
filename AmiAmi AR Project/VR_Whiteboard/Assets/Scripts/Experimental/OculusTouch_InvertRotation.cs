using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusTouch_InvertRotation : MonoBehaviour
{
    public Vector3 setRotation = new Vector3(30, -180, -20);

    void Start()
    {
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(setRotation);
    }
}
