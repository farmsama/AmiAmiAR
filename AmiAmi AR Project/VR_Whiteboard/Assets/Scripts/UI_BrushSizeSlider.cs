using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BrushSizeSlider : MonoBehaviour
{
    public InputField BrushSizeInputField;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBrush_SliderValue()
    {
        int newValue = int.Parse(BrushSizeInputField.text);

        if (newValue > slider.maxValue)
        {
            slider.value = slider.maxValue;
        }
        else
        {
            slider.value = newValue;
        }
    }

    public void UpdateBrushSize()
    {
        Debug.Log(slider.value);
    }
}
