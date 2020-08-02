using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRinputmodule : BaseInputModule
{
    public Camera m_Camera;

    public OVRInput.Button clickButton = OVRInput.Button.PrimaryIndexTrigger;
    public OVRInput.Controller controller = OVRInput.Controller.All;

    private GameObject m_CurrentObject = null;
    private PointerEventData m_Data = null;
    
    
    TogglePenAndPointer TPP;


    protected override void Awake()
    {
        base.Awake();

        m_Data = new PointerEventData(eventSystem);
        TPP = FindObjectOfType<TogglePenAndPointer>();
    }

    

    public override void Process()
    {
        m_Data.Reset();
        m_Data.position = new Vector2(m_Camera.pixelWidth / 2, m_Camera.pixelHeight / 2);


        if (TPP.PenPoint[1].GetComponent<LineRenderer>().enabled == true)
        {
            eventSystem.RaycastAll(m_Data, m_RaycastResultCache);
            m_Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
            m_CurrentObject = m_Data.pointerCurrentRaycast.gameObject;
        }

        m_RaycastResultCache.Clear();

        HandlePointerExitAndEnter(m_Data, m_CurrentObject);

        if (OVRInput.GetDown(clickButton, controller))
        {            
            ProcessPress(m_Data);
        }

        if (OVRInput.GetUp(clickButton, controller))
        {
            ProcessRelease(m_Data);
        }

    }

    public PointerEventData GetData()
    {
        return m_Data;
    }

    public void ProcessPress(PointerEventData data) { }
    public void ProcessRelease(PointerEventData data) { }
}
