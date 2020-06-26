using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finalized_UIFunctions : MonoBehaviour
{
    public GameObject[] StaticUI;
    public GameObject ActiveUI;

    public bool InARmode = false;

    private SelectionManager SM;
    

    // Start is called before the first frame update
    void Start()
    {
        SM = FindObjectOfType<SelectionManager>();

        // disable all UI pages
        ActiveUI.SetActive(false);
        foreach (GameObject obj in StaticUI)
        {
            obj.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStaticUI(int ArrayIndex)
    {
        foreach (GameObject obj in StaticUI)
        {
            obj.SetActive(false);
        }

        StaticUI[ArrayIndex].SetActive(true);
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
    }

    public void ExitARMode(int staticUI_ArrayIndex)
    {
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
    }
}
