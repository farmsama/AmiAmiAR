using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Space(20)]
    public bool InARmode = false;
    public bool openPoses = false;  // Poses pages sliding out

    
    private SelectionManager SM;

    

    // Start is called before the first frame update
    void Start()
    {
        SM = FindObjectOfType<SelectionManager>();

        // disable all UI pages but the first page
        ActiveUI.SetActive(false);
        foreach (GameObject obj in StaticUI)
        {
            obj.SetActive(false);
        }
        StaticUI[0].SetActive(true);
        openPoses = false;

        Debug.Log(PoseCatalogue.localPosition);
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
        SM.ReplaceSelected(SM.ListOfFigurines[0]);

        foreach (GameObject obj in StaticUI)
        {
            obj.SetActive(false);
        }

        ActiveUI.SetActive(true);
        openPoses = false;
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
