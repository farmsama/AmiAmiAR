using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Figurine", menuName = "Figurine")]
public class ModelData : ScriptableObject
{
    public Vector3 OriginPosition;
    public GameObject prefab;
}
