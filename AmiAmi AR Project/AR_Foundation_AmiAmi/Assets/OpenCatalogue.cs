using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenCatalogue : MonoBehaviour
{
    RectTransform RT;
    public bool isOpen = true;

    public Vector3 openPos = new Vector3(-480, 0, 0);
    public Vector3 closedPos = new Vector3(480, 0, 0);
    private Vector3 buttonVelocity = Vector3.zero;
    private float smoothTime = 0.5f;

    public SelectionManager SM;

    // Start is called before the first frame update
    void Start()
    {
        RT = GetComponent<RectTransform>();
        SM = FindObjectOfType<SelectionManager>();
        Debug.Log(RT.localPosition);
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

            if (SelectionManager.SelectedFigurine != null)
            {
                SM.LoadDetailPage(SM.figureindex);
            }
        }
    }

    public void OnButtonPressed()
    {
        isOpen = !isOpen;
    }
}
