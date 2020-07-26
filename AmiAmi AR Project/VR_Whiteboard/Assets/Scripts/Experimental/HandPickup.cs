using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPickup : MonoBehaviour
{
    ControllerInput_Test Input;

    [Header("ControllerInformation")]
    public Collider_HandDetection L_collider;
    public Collider_HandDetection R_collider;

    public GameObject L_controller;
    public GameObject R_controller;

    public GameObject L_heldTarget;
    public GameObject R_heldTarget;


    [Header("User Information")]
    public bool isRightHanded = true;
    public bool isEmpty_right = true;
    public bool isEmpty_left = true;

    // Start is called before the first frame update
    void Start()
    {
        Input = FindObjectOfType<ControllerInput_Test>();
    }

    // Update is called once per frame
    void Update()
    {
        Pickup();
    }

    void Pickup()
    {
        if (isEmpty_left && isRightHanded == false)
        {
            if (L_collider.closestTarget != null && Input.LeftGripBool)
            {
                // pickup
                L_heldTarget = L_collider.closestTarget;
                L_heldTarget.transform.SetParent(L_controller.transform, false);
                L_heldTarget.transform.localPosition = Vector3.zero;

                isEmpty_left = false;
            }
        }
        else
        {
            if (L_heldTarget != null && Input.LeftGripBool)
            {
                //L_heldTarget.transform.SetParent(null);
            }
        }

        if (isEmpty_right && isRightHanded == true)
        {
            if (R_collider.closestTarget != null && Input.RightGripBool)
            {
                // pickup
                R_heldTarget = R_collider.closestTarget;
                R_heldTarget.transform.SetParent(R_collider.transform, false);
                R_heldTarget.transform.localPosition = Vector3.zero;

                isEmpty_right = false;
            }
        }
        else
        {
            if (R_heldTarget != null && Input.RightGripBool)
            {
                //R_heldTarget.transform.SetParent(null);
            }
        }
    }
}
