using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class PlaneSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    AnchorInputListenerBehaviour AILB;
    PlaneFinderBehaviour PFB;
    ContentPositioningBehaviour CPB;

    DataSet dataset;

    public GameObject FigurePrefab;
    public GameObject GroundPlaneStage;

    GameObject spawnedFigure = null;

    void Start()
    {
        AILB = GetComponent<AnchorInputListenerBehaviour>();
        PFB = GetComponent<PlaneFinderBehaviour>();
        CPB = GetComponent<ContentPositioningBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SpawnFigure()
    //{
    //    if (spawnedFigure == null)
    //    {
    //        spawnedFigure = Instantiate(FigurePrefab);
    //        spawnedFigure.transform.SetParent(GroundPlaneStage.transform);
    //        spawnedFigure.transform.localPosition = Vector3.zero;
    //    }
    //}

    public void ResetFigure()
    {
        //for(int i = 0; i < GameObject.FindGameObjectsWithTag("Figurine").Length ; i++ )
        //{
        //    Destroy(GameObject.FindGameObjectsWithTag("Figurine")[i]); 
        //}
        
                
        AILB.enabled = true;
    }

    
}
