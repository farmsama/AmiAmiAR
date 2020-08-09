using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushSettingGrp : MonoBehaviour
{
    public GameObject BrushSettingGrpObj;
    public GameObject MathQN;
    
    // VR controller
    ControllerInput_Test input;
    bool lastGrip = false;


    // Start is called before the first frame update
    void Start()
    {
        input = FindObjectOfType<ControllerInput_Test>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BrushSettingGrpObj.SetActive(!BrushSettingGrpObj.activeInHierarchy);
        }

        // Check click once
        if (input.LeftGripBool == true && lastGrip == false)
            ToggleBrushSetting();

        lastGrip = input.LeftGripBool;
    }

    public void ToggleBrushSetting()
    {
        BrushSettingGrpObj.SetActive(!BrushSettingGrpObj.activeInHierarchy);
        MathQN.SetActive(!MathQN.activeInHierarchy);
    }
}
