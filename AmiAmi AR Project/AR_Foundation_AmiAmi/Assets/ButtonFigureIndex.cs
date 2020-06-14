using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFigureIndex : MonoBehaviour
{
    public int FigureIndex;

    SelectionManager SM;

    public void Start()
    {
       SM = FindObjectOfType<SelectionManager>();
    }


    public void ThisButtonPressed()
    {
        SM.LoadDetailPage(FigureIndex);
    }
}
