using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    // Core systems
    public ModelData[] ListOfFigurines;
    public static ModelData SelectedFigurine;
    
    [Space(10)]
    public string Ar_sceneName;

    // UI stuffs
    public bool DetailPage = false;

    public void ClearSelected()
    {
        SelectedFigurine = null;
    }

    public void ReplaceSelected(ModelData _selected)
    {
        SelectedFigurine = _selected;
    }   


    // UI Button functions
    public void LoadARScene()
    {
        SceneManager.LoadScene(Ar_sceneName);
    }

    public void LoadDetailPage(int _figureIndex)
    {
        ReplaceSelected(ListOfFigurines[_figureIndex]);
        DetailPage = true;
    }

    public void ExitDetailPage()
    {
        DetailPage = false;
        ClearSelected();
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
