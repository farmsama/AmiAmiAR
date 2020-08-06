using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEditor.Build.Reporting;

public class ControllerInput_Test : MonoBehaviour
{
    private List<InputDevice> leftHandDevices = new List<InputDevice>();
    private List<InputDevice> rightHandDevices = new List<InputDevice>();

    // Debugging
    public bool DisplayDebug = true;
    public Text DebugInfo;


    [Header("Inputs")]
    // Triggers
    public float LeftTriggerValue = 0;
    public float RightTriggerValue = 0;
    public bool LeftTriggerBool = false;
    public bool RightTriggerBool = false;

    // Grip Button
    public bool LeftGripBool = false;
    public bool RightGripBool = false;

    // ABXY Button
    public bool Xbutton = false;
    public bool Ybutton = false;
    public bool Abutton = false;
    public bool Bbutton = false;

    // Analogs
    public Vector2 LeftAnalogValue = new Vector2();
    public Vector2 RightAnalogValue = new Vector2();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left, leftHandDevices);
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, rightHandDevices);


        // Left Hand Controller
        if (leftHandDevices.Count >= 1)
        {
            // Left Index Trigger
            if (leftHandDevices[0].TryGetFeatureValue(CommonUsages.trigger, out LeftTriggerValue)) { }
            if (leftHandDevices[0].TryGetFeatureValue(CommonUsages.triggerButton, out LeftTriggerBool)) { }

            // Grip Button
            if (leftHandDevices[0].TryGetFeatureValue(CommonUsages.gripButton, out LeftGripBool)) { }

            // X and Y button
            if (leftHandDevices[0].TryGetFeatureValue(CommonUsages.primaryButton, out Xbutton)) { }
            if (leftHandDevices[0].TryGetFeatureValue(CommonUsages.secondaryButton, out Ybutton)) { }

            // Left Analog
            if (leftHandDevices[0].TryGetFeatureValue(CommonUsages.primary2DAxis, out LeftAnalogValue)) { }
        }

        // Right Hand Controller
        if (rightHandDevices.Count >= 1)
        {
            // Right Index Trigger
            if (rightHandDevices[0].TryGetFeatureValue(CommonUsages.trigger, out RightTriggerValue)) { }
            if (rightHandDevices[0].TryGetFeatureValue(CommonUsages.triggerButton, out RightTriggerBool)) { }

            // Grip Button
            if (rightHandDevices[0].TryGetFeatureValue(CommonUsages.gripButton, out RightGripBool)) { }

            // A and B button
            if (rightHandDevices[0].TryGetFeatureValue(CommonUsages.primaryButton, out Abutton)) { }
            if (rightHandDevices[0].TryGetFeatureValue(CommonUsages.secondaryButton, out Bbutton)) { }

            // Left Analog
            if (rightHandDevices[0].TryGetFeatureValue(CommonUsages.primary2DAxis, out RightAnalogValue)) { }
        }

        // Adjusting Controller Values
        if (LeftTriggerValue < 0.01f) LeftTriggerValue = 0;
        if (RightTriggerValue < 0.01f) RightTriggerValue = 0;


        // DebugPrinting
        if (DisplayDebug)
            UpdateDetection();
    }

    public void UpdateDetection(
        )
    {
        DebugInfo.text = "Left Trigger: " + LeftTriggerValue + " , " + LeftTriggerBool + "\n"
                       + "Left Analog: " + LeftAnalogValue.x + " , " + LeftAnalogValue.y + "\n"
                       + "Left Grip Button: " + LeftGripBool + "\n"
                       + "A Button: " + Abutton + "\n"
                       + "B Button: " + Bbutton + "\n"
                       + "X Button: " + Xbutton + "\n"
                       + "Y Button: " + Ybutton + "\n"
                       + "Right Trigger: " + RightTriggerValue + " , " + RightTriggerBool + "\n"
                       + "Right Analog: " + RightAnalogValue.x + " , " + RightAnalogValue.y + "\n"
                       + "Right Grip Button: " + RightGripBool + "\n";

    }
}
