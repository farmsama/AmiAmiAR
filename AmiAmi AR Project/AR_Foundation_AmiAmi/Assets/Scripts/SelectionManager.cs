using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    // Core systems
    public ModelData[] ListOfFigurines;
    public static ModelData SelectedFigurine;
    public int figureindex;
    
    [Space(10)]
    public string Ar_sceneName;

    // UI stuffs
    [Space(20)]
    public bool ViewingDetails = false;
    public GameObject DetailPageObj;

    public GameObject TargetFig_Button;

    public void Start()
    {
        // AutoCreation of All avaliable buttons and set the index values.
        for (int i = 0; i < ListOfFigurines.Length; i++)
        {
            //Debug.Log(i);
            //GameObject instantiateButton = Instantiate(TargetFig_Button, TargetFig_Button.transform.position, TargetFig_Button.transform.rotation);
            //instantiateButton.GetComponent<ButtonFigureIndex>().FigureIndex = i;
        }
    }


    //-----------------------------------------------------------//
    //-----------------------------------------------------------//
    //-----------------------------------------------------------//
    // General Functions regarding Selection
    public void ClearSelected()
    {
        SelectedFigurine = null;
    }

    public void ReplaceSelected(ModelData _selected)
    {
        SelectedFigurine = _selected;
    }


    //-----------------------------------------------------------//
    //-----------------------------------------------------------//
    //-----------------------------------------------------------//
    // UI Button functions
    public void LoadARScene()
    {
        //SceneManager.LoadScene(Ar_sceneName);
        DetailPageObj.SetActive(false);
        OpenCatalogue oc = FindObjectOfType<OpenCatalogue>();
        oc.OnButtonPressed();
    }

    public void LoadDetailPage(int _figureIndex)
    {
        DetailPageObj.SetActive(true);
        ReplaceSelected(ListOfFigurines[_figureIndex]);
        ViewingDetails = true;
        figureindex = _figureIndex;

    }

    public void ExitDetailPage()
    {
        DetailPageObj.SetActive(false);
        ViewingDetails = false;
        ClearSelected();

        figureindex = 0;
    }

    public void OpenURL()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/3d/characters/unity-chan-model-18705");
    }

    //-----------------------------------------------------------//
    //-----------------------------------------------------------//
    //-----------------------------------------------------------//
    // DEBUG STUFF AND TEST SCRIPTS
    //-----------------------------------------------------------//
    //-----------------------------------------------------------//
    //-----------------------------------------------------------//
    private void DebugTests()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ReplaceSelected(ListOfFigurines[0]);

            if (SelectedFigurine == null) Debug.Log("is null");
            else Debug.Log("is not null");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (SelectedFigurine == null) Debug.Log("is null");
            else Debug.Log("is not null");

            SceneManager.LoadScene("SampleScene2");
        }

        if (SelectedFigurine == null) Debug.Log("Has nothing selected");
    }
}
