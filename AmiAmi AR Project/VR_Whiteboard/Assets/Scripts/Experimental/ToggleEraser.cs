using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEraser : MonoBehaviour
{
    PlayerBrush brush;
    ControllerInput_Test input;
    bool lastGrip = false;

    public GameObject[] TogglePenEraser;

    // Start is called before the first frame update
    void Start()
    {
        input = FindObjectOfType<ControllerInput_Test>();
        brush = FindObjectOfType<PlayerBrush>();

    }

    // Update is called once per frame
    void Update()
    {

        if (input.Bbutton == true && lastGrip == false)
            toggleErasermode();


        lastGrip = input.Bbutton;
    }

    void toggleErasermode()
    {
        TogglePenEraser[0].SetActive(!TogglePenEraser[0].activeSelf);
        TogglePenEraser[1].SetActive(!TogglePenEraser[1].activeSelf);

        brush.isDrawing = !brush.isDrawing;


    }
}
