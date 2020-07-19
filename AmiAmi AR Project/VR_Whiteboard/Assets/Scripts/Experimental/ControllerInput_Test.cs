using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class ControllerInput_Test : MonoBehaviour
{
    private List<InputDevice> leftHandDevices = new List<InputDevice>();
    private List<InputDevice> rightHandDevices = new List<InputDevice>();


    // Debugging
    public bool DisplayDebug = true;
    public Text DebugInfo;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left , leftHandDevices);
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, rightHandDevices);

        float LeftTriggerValue = 0;
        float RightTriggerValue = 0;

        // Left Hand Controller
        if (leftHandDevices.Count >= 1)
        {
            if (leftHandDevices[0].TryGetFeatureValue(CommonUsages.trigger , out LeftTriggerValue))
            {                
                // Do Stuff??
            }
        }

        // Right Hand Controller
        if (rightHandDevices.Count >= 1)
        {
            if (rightHandDevices[0].TryGetFeatureValue(CommonUsages.trigger, out RightTriggerValue))
            {
            }
        }


        // DebugPrinting
        if (DisplayDebug)
            UpdateDetection(LeftTriggerValue, RightTriggerValue);
    }

    public void UpdateDetection(
        float _leftTriggerValue,
        float _rightTriggerValue
        )
    {
        DebugInfo.text = "Left Trigger: " + _leftTriggerValue + "\n"
                       + "Right Trigger: " + _rightTriggerValue + "\n";
    }
}
