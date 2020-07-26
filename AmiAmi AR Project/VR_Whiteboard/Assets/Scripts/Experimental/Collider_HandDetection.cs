using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_HandDetection : MonoBehaviour
{
    List<GameObject> TargetsInCollider;

    public GameObject closestTarget;

    // Start is called before the first frame update
    void Start()
    {
        TargetsInCollider = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetsInCollider.Count > 0)
        {
            float distance = 100f;
            GameObject possibleTarget = null;
            closestTarget = null;

            foreach (GameObject t in TargetsInCollider)
            {
                float currdist = Vector3.Distance(this.gameObject.transform.position, t.transform.position);

                if (currdist < distance)
                {
                    distance = currdist;
                    possibleTarget = t;
                }
            }

            if (possibleTarget != null)
            {
                closestTarget = possibleTarget;
            }
        }
    }

    void OnTriggerEnter(Collider _target)
    {
        if (_target.gameObject.tag == "Interact")
        {
            TargetsInCollider.Add(_target.gameObject);
        }
    }

    void OnTriggerExit(Collider _target)
    {
        if (_target.gameObject.tag == "Interact")
        {
            TargetsInCollider.Remove(_target.gameObject);
        }
    }
}
