using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Positions self around the perimeter of the held mesh.
/// </summary>

public class RM_Anchor : MonoBehaviour
{
    public GameObject positioningBox;

    public enum LightingMode { RANDOM, BACKLIGHT, FRONTLIGHT }
    public LightingMode LightMode = LightingMode.RANDOM;

    Collider col = null;
    public Bounds GetBounds
    {
        get
        {
            if (positioningBox == null)
            {
                Debug.LogError("Positioning box was null.");
                return new Bounds();
            }

            if (col == null)
            {
                col = positioningBox.GetComponent<Collider>();
            }

            if (col == null)
                Debug.LogError("No collider was found in positioningBox");

            return col.bounds;
        }
    }


    public void Move(Vector3 vec)
    {
        transform.Translate(vec);

        transform.position = GetBounds.ClosestPoint(transform.position);
    }
    private void Start()
    {
        RepositionToRandomPoint();
    }

    void ValidatePosition()
    {
        float z =
            transform.localPosition.z;
        //If Backlight, set the z to negative
        if (LightMode == LightingMode.BACKLIGHT)
        {
            z = Mathf.Abs(z) * -1;
        }
        //If Frontlight, set the z to positive
        else if (LightMode == LightingMode.FRONTLIGHT)
        {
            z = Mathf.Abs(z);
        }

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
    }
    public void RepositionToRandomPoint()
    {
        Bounds bounds = GetBounds;
        Vector3 vec = Toolbox.Range(bounds.min, bounds.max);

        Debug.Log("Setting to closest point");
        vec = bounds.ClosestPoint(vec);
        transform.position = vec;

        ValidatePosition();
    }

    private void FixedUpdate()
    {

    }

}
