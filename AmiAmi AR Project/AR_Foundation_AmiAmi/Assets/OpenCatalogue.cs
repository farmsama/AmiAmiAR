using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCatalogue : MonoBehaviour
{
    RectTransform RT;
    public bool isOpen = true;

    Vector3 openPos = new Vector3(-480, 0, 0);
    Vector3 closedPos = new Vector3(480, 0, 0);
    private Vector3 buttonVelocity = Vector3.zero;
    private float smoothTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        RT = GetComponent<RectTransform>();
        //Debug.Log(RT.localPosition);
    }

    void Update()
    {
        if (isOpen == true && RT.localPosition != closedPos)
        {
            // close catalogue  
            RT.localPosition = Vector3.SmoothDamp(RT.localPosition, closedPos, ref buttonVelocity, smoothTime);
        }
        else if (isOpen == false && RT.localPosition != openPos)
        {
            // open catalogue
            RT.localPosition = Vector3.SmoothDamp(RT.localPosition, openPos, ref buttonVelocity, smoothTime);
        }
    }

    public void OnButtonPressed()
    {
        isOpen = !isOpen;
    }
}
