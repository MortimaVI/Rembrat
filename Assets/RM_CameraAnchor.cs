using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_CameraAnchor : MonoBehaviour
{
    public GameObject positioningBox;

    Collider mesh = null;
    public Bounds GetBounds
    {
        get
        {
            if (positioningBox == null)
            {
                Debug.LogError("Positioning box was null.");
            }

            if (mesh == null)
            {
                mesh = positioningBox.GetComponent<Collider>();
            }

            if (mesh == null)
            {
                Debug.LogError("No mesh was found in positioningBox");
                return new Bounds();
            }

            return mesh.bounds;
        }
    }

    public void RepositionToRandomPoint()
    {
        if (GetBounds == null)
        {
            Debug.LogError("Get Mesh returned null.");
            return;
        }

        Vector3 vec = Toolbox.Range(GetBounds.min, GetBounds.max);

        //Lazy, hacky way to move the vector out of the bounds
        //so the ClosestPoint function can move it back to the perimeter
        //vec *= 1000;

        vec = GetBounds.ClosestPoint(vec);
        transform.localPosition = vec;

    }
}
