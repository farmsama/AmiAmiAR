using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Censorship : MonoBehaviour
{
    public Text textCom;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug EulerAngle
        if (textCom != null && Input.touchCount > 0 && FindObjectOfType<Finalized_UIFunctions>().InARmode)
        {
            //textCom.text = Camera.main.transform.eulerAngles.ToString();
            //textCom.text = FindObjectOfType<Finalized_UIFunctions>().InARmode.ToString();
            //textCom.text = FindObjectOfType<Finalized_UIFunctions>().InARmode.ToString() + " " + SelectionManager.SelectedFigurine.ToString();
        }

        //Check if instantied figure is null
        if (FindObjectOfType<ARTapToPlaceObject>().GetComponent<ARTapToPlaceObject>().GetInstantiatedFigure() != null)
        {
            //If player is looking at an upwards angle

            //Enable ALL Lensflare
            foreach (GameObject lensflare in GameObject.FindGameObjectsWithTag("LensFlare"))
            {
                if (Camera.main.transform.eulerAngles.x > 180 && Camera.main.transform.eulerAngles.x < 360 
                                            && lensflare.transform.position.y > Camera.main.transform.position.y)
                {
                    if (lensflare.GetComponent<Light>().enabled != true)
                    {
                        lensflare.GetComponent<Light>().enabled = true;
                    }
                }
                else if(Camera.main.transform.eulerAngles.x < 179 && Camera.main.transform.eulerAngles.x > 0
                                            || lensflare.transform.position.y < Camera.main.transform.position.y)
                {
                    if (lensflare.GetComponent<Light>().enabled != false)
                    {
                        lensflare.GetComponent<Light>().enabled = false;
                    }
                }

            }         

        }

    }
}
