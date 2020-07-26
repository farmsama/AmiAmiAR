using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushSettingGrp : MonoBehaviour
{
    public GameObject BrushSettingGrpObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BrushSettingGrpObj.SetActive(!BrushSettingGrpObj.activeInHierarchy);
        }
    }
}
