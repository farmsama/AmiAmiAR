using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePenAndPointer : MonoBehaviour
{
    // VR controller
    ControllerInput_Test input;
    bool lastGrip = false;
    public GameObject[] PenPoint;

    // Start is called before the first frame update
    void Start()
    {
        input = FindObjectOfType<ControllerInput_Test>();

    }

    // Update is called once per frame
    void Update()
    {
        // Check click once
        if (input.RightGripBool == true && lastGrip == false)
            TogglePenSetting();

        lastGrip = input.RightGripBool;

    }


    public void TogglePenSetting()
    {
        PenPoint[0].SetActive(!PenPoint[0].activeSelf);


        LineRenderer lr = PenPoint[1].GetComponent<LineRenderer>();
        lr.enabled = !lr.enabled;

    }
}
