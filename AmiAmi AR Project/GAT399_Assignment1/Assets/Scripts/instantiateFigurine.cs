using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instantiateFigurine : MonoBehaviour
{
    public GameObject spawnParent;

    void Start()
    {
        if (spawnParent != null && SelectionManager.SelectedFigurine != null)
        {
            //Instantiate(SelectionManager.SelectedFigurine.prefab, SelectionManager.SelectedFigurine.OriginPosition, FigRotation, spawnParent.transform);
            GameObject SpawnedFig = Instantiate(SelectionManager.SelectedFigurine.prefab, spawnParent.transform);
        }
        else
        {
            if (spawnParent == null)
                Debug.Log("Failed, parent is null");
            else if (SelectionManager.SelectedFigurine == null)
                Debug.Log("Failed, Selected is null");
        }
    }

    void Update()
    {
        DebugTests();
    }

    private void DebugTests()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {  
            SceneManager.LoadScene("SampleScene");
            SelectionManager.SelectedFigurine = null;
        }
    }
}
