using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileTouchControl : MonoBehaviour
{
    Touch touch;
    Vector2 touchPos;
    Quaternion rotY;

    float rotSpdMod = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                rotY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotSpdMod, 0f);

                transform.rotation = rotY * transform.rotation;
            }
        }
    }
}
