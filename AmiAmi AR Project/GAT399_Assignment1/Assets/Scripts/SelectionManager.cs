using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    public ModelData[] ListOfFigurines;
    public static ModelData SelectedFigurine;


    public void Update()
    {
        DebugTests();   
    }

    public void ClearSelected()
    {
        SelectedFigurine = null;
    }

    public void ReplaceSelected(ModelData _selected)
    {
        SelectedFigurine = _selected;
    }

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
