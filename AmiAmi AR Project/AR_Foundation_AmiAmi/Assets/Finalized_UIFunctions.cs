using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;

public class Finalized_UIFunctions : MonoBehaviour
{
    [Header("Menu Pages")]
    public GameObject[] StaticUI;
    public GameObject ActiveUI;

    [Space(10)]
    [Header("poses stuff")]
    public RectTransform PoseCatalogue;
    public Vector3 openPos = new Vector3(-480, 0, 0);
    public Vector3 closedPos = new Vector3(480, 0, 0);
    private Vector3 buttonVelocity = Vector3.zero;
    private float smoothTime = 0.5f;
    public GameObject poseButton;
    public GameObject resetButton;
    public GameObject UIText_DragLeftnRightToRotate;

[Space(20)]
    public bool InARmode = false;
    public bool openPoses = false;  // Poses pages sliding out

    
    private SelectionManager SM;
    private ARTapToPlaceObject arTapToPlaceObj;


    public ARSession arSession;

    // Start is called before the first frame update
    void Start()
    {
        SM = FindObjectOfType<SelectionManager>();
        arTapToPlaceObj = FindObjectOfType<ARTapToPlaceObject>();

        // disable all UI pages but the first page
        ActiveUI.SetActive(false);
        foreach (GameObject obj in StaticUI)
        {
            obj.SetActive(false);
        }
        StaticUI[0].SetActive(true);
        openPoses = false;

        //Debug.Log(PoseCatalogue.localPosition);

        arSession.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (openPoses == false && PoseCatalogue.localPosition != closedPos)
        {
            // close catalogue  
            PoseCatalogue.localPosition = Vector3.SmoothDamp(PoseCatalogue.localPosition, closedPos, ref buttonVelocity, smoothTime);
        }
        else if (openPoses == true && PoseCatalogue.localPosition != openPos)
        {
            // open catalogue
            PoseCatalogue.localPosition = Vector3.SmoothDamp(PoseCatalogue.localPosition, openPos, ref buttonVelocity, smoothTime);

            if (SelectionManager.SelectedFigurine != null)
            {
                SM.LoadDetailPage(SM.figureindex);
            }
        }

        if (arTapToPlaceObj.isFigurineInstantiated() && openPoses == false)
        {
            poseButton.SetActive(true);
            resetButton.SetActive(true);
            UIText_DragLeftnRightToRotate.SetActive(true);
        }
        else
        {
            poseButton.SetActive(false);
            resetButton.SetActive(false);
            UIText_DragLeftnRightToRotate.SetActive(false);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && openPoses == true)
        {
            TogglePosesPage();
        }

    }

    public void SelectStaticUI(int ArrayIndex)
    {
        foreach (GameObject obj in StaticUI)
        {
            obj.SetActive(false);
        }

        StaticUI[ArrayIndex].SetActive(true);
        openPoses = false;
    }

    public void EnterARMode()
    {
        InARmode = true;
        //SM.ReplaceSelected(SM.ListOfFigurines[0]);
        SelectionManager.SelectedFigurine = SM.ListOfFigurines[0];

        foreach (GameObject obj in StaticUI)
        {
            obj.SetActive(false);
        }

        ActiveUI.SetActive(true);
        openPoses = false;


        arSession.enabled = true;


    }

    public void ExitARMode(int staticUI_ArrayIndex)
    {
        openPoses = false;
        InARmode = false;
        ActiveUI.SetActive(false);

        foreach (GameObject obj in StaticUI)
        {
            obj.SetActive(false);
        }

        StaticUI[staticUI_ArrayIndex].SetActive(true);

        arSession.enabled = false;
    }

    public void OpenURLLink()
    {
        SM.OpenURL();
        openPoses = false;
    }

    public void TogglePosesPage()
    {
        openPoses = !openPoses;
    }
}
