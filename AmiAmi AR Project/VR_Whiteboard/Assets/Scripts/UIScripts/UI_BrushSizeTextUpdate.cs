using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BrushSizeTextUpdate : MonoBehaviour
{
    InputField BrushSize_InputField;
    public int BrushSizeLimit = 200;

    public Slider BrushSlider;

    void Start()
    {
        BrushSize_InputField = GetComponent<InputField>();
        BrushSize_InputField.text = BrushSlider.value.ToString();
    }

    private void Update()
    {

    }

    public void SetBrushSize_InputFieldValue()
    {
        BrushSize_InputField.text = BrushSlider.value.ToString();

        if (int.Parse(BrushSize_InputField.text) > BrushSlider.GetComponent<Slider>().maxValue)
        {
            BrushSize_InputField.text = BrushSlider.GetComponent<Slider>().maxValue.ToString();
        }
        else
        {
            BrushSize_InputField.text = BrushSlider.value.ToString();
        }
    }
}
