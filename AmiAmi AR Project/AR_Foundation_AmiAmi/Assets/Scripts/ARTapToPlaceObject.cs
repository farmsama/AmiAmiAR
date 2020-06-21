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

    public bool isGhostingOption = true;

    public OpenCatalogue openCatelogue;

    //ghosting Figurine
    GameObject ghostingFigure;

    //FingerGestureAnimObj
    public GameObject FingerGestureAnimObj;

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

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && openCatelogue.isOpen == false)
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
                instantiatedFigure = Instantiate(SelectionManager.SelectedFigurine.prefab, placementPose.position, placementPose.rotation);

                if (ghostingFigure == null)
                {
                    Vector3 rot = instantiatedFigure.transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x, rot.y + 180, rot.z);
                    instantiatedFigure.transform.rotation = Quaternion.Euler(rot);
                }
                else
                {
                    instantiatedFigure.transform.rotation = ghostingFigure.transform.rotation;
                }
                //instantiatedFigure = Instantiate(SelectionManager.SelectedFigurine.prefab, placementPose.position, new Quaternion(placementPose.rotation.x, placementPose.rotation.y + 180, placementPose.rotation.z, placementPose.rotation.w));

                tapToPlaceFigure_UI.SetActive(false);
                ResetButton_UI.SetActive(true);
                dragLeftOrRightToRot_UI.SetActive(true);

                if (FingerGestureAnimObj != null)
                {
                    FingerGestureAnimObj.SetActive(true);
                }

                foreach (var plane in planeManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }

                if (ghostingFigure != null)
                {
                    Destroy(ghostingFigure);
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
            if (isGhostingOption == true)
            {
                //Set figurine to Placement market
                ghostingFigure = Instantiate(SelectionManager.SelectedFigurine.prefab);
                ghostingFigure.transform.parent = placementIndicator.transform;
                ghostingFigure.transform.localPosition = Vector3.zero;
                ghostingFigure.transform.rotation = instantiatedFigure.transform.rotation;
            }

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
