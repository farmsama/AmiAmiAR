using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;
using System;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    public Camera cam;

    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    GameObject instantiatedFigure = null;

    public GameObject tapToPlaceFigure_UI; //Only appears when there is NO figure
    public GameObject ResetButton_UI; //Only appears when there IS A Figure
    public GameObject lookAround_UI;
    public GameObject dragLeftOrRightToRot_UI;

    public ARPlaneManager planeManager;

    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();

        //Initialise UI - Set Active
        tapToPlaceFigure_UI.SetActive(false);
        ResetButton_UI.SetActive(false);
        dragLeftOrRightToRot_UI.SetActive(false);
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        //UI Before Figure placement
        if (instantiatedFigure == null)
        {
            if (placementPoseIsValid != true)
            {
                lookAround_UI.SetActive(true);
                tapToPlaceFigure_UI.SetActive(false);
            }
            else
            {
                lookAround_UI.SetActive(false);
                tapToPlaceFigure_UI.SetActive(true);
            }
        }
        else
        {

        }

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }

    }

    private void PlaceObject()
    {
        if (instantiatedFigure == null)
        {
            if (SelectionManager.SelectedFigurine != null)
            {
                instantiatedFigure = Instantiate(SelectionManager.SelectedFigurine.prefab, placementPose.position, new Quaternion(placementPose.rotation.x, placementPose.rotation.y + 180, placementPose.rotation.z, placementPose.rotation.w));
                //instantiatedFigure = Instantiate(SelectionManager.SelectedFigurine.prefab, placementPose.position, SelectionManager.SelectedFigurine.prefab.transform.rotation);

                tapToPlaceFigure_UI.SetActive(false);
                ResetButton_UI.SetActive(true);
                dragLeftOrRightToRot_UI.SetActive(true);

                foreach (var plane in planeManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }
            }
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid && instantiatedFigure == null)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f,0.5f));        
        var hits = new List<ARRaycastHit>();
        var rayCastMgr = FindObjectOfType<ARRaycastManager>();

        rayCastMgr.Raycast(screenCenter, hits, TrackableType.Planes);
        


        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var CameraForward = Camera.main.transform.forward;
            var CamBearing = new Vector3(CameraForward.x, 0, CameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(CamBearing);
        }
    }

    public void ResetFigurinePlacement()
    {
        if (instantiatedFigure != null)
        {
            Destroy(instantiatedFigure);

            tapToPlaceFigure_UI.SetActive(true);
            ResetButton_UI.SetActive(false);
            dragLeftOrRightToRot_UI.SetActive(false);

            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(true);
            }
        }
    }

    public bool isFigurineInstantiated()
    {
        if (instantiatedFigure != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
