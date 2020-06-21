using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogueController : MonoBehaviour
{
    public GameObject Segment1;
    public GameObject Subgroup1;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickSegment1()
    {
        if (Subgroup1.activeSelf == false)
            Subgroup1.SetActive(true);
        else
            Subgroup1.SetActive(false);

        RectTransform RT_s1 = Segment1.GetComponent<RectTransform>();
        if (RT_s1.sizeDelta.y == 400)
            RT_s1.sizeDelta = new Vector2(RT_s1.sizeDelta.x, 200);
        else if (RT_s1.sizeDelta.y == 200)
            RT_s1.sizeDelta = new Vector2(RT_s1.sizeDelta.x, 400);
    }
}
