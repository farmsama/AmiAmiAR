using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerLine : MonoBehaviour
{
    public LineRenderer line;
    public float raydist = 300f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, CalculateEnd());
    }

    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endPosition = DefaultEnd(raydist);

        if (hit.collider)
        {
            endPosition = hit.point;
        }

        return endPosition;
    }

    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, raydist);
        return hit;
    }

    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }
}
