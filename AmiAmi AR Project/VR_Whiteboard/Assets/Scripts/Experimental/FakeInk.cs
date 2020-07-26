using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeInk : MonoBehaviour
{
    public List<GameObject> History;
    ControllerInput_Test Input;
    HandPickup HandInfo;

    [Header("Fake Ink")]
    public GameObject fakeInkSplat;

    public ColorPicker colourPicker;

    // Start is called before the first frame update
    void Start()
    {
        History = new List<GameObject>();
        Input = FindObjectOfType<ControllerInput_Test>();
        HandInfo = FindObjectOfType<HandPickup>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Surface")
        {
            Debug.Log("Printing");

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            if (HandInfo.isRightHanded == true && Input.RightTriggerBool)
            {
                GameObject ink = Instantiate(fakeInkSplat, pos, rot);
                History.Add(ink);
            }
            else if (HandInfo.isRightHanded == false && Input.LeftTriggerBool)
            {
                GameObject ink = Instantiate(fakeInkSplat, pos, rot);
                History.Add(ink);
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            Debug.Log("Printing");

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            if (HandInfo.isRightHanded == true && Input.RightTriggerBool)
            {
                GameObject ink = Instantiate(fakeInkSplat, pos, rot);
                History.Add(ink);
            }
            else if (HandInfo.isRightHanded == false && Input.LeftTriggerBool)
            {
                GameObject ink = Instantiate(fakeInkSplat, pos, rot);
                History.Add(ink);
            }
        }
    }

    public void UpdatePenColour()
    {
        if (colourPicker != null)
        {
            fakeInkSplat.GetComponent<Renderer>().sharedMaterial.color = new Color(colourPicker.R,
                                                                               colourPicker.G,
                                                                               colourPicker.B);

            GetComponent<Renderer>().sharedMaterial.color = new Color(colourPicker.R,
                                                                   colourPicker.G,
                                                                   colourPicker.B);
        }
    }
}