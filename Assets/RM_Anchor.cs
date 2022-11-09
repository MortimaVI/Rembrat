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

    MeshFilter mesh = null;
    public MeshFilter GetMesh
    {
        get
        {
            if (positioningBox == null)
            {
                Debug.LogError("Positioning box was null.");
                return null;
            }

            if (mesh == null)
            {
                mesh = positioningBox.GetComponent<MeshFilter>();
            }

            if (mesh == null)
                Debug.LogError("No mesh was found in positioningBox");

            return mesh;
        }
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
        if (GetMesh == null)
        {
            Debug.LogError("Get Mesh returned null.");
            return;
        }

        Vector3 vec = Toolbox.Range(GetMesh.mesh.bounds.min, GetMesh.mesh.bounds.max);
        
        //Lazy, hacky way to move the vector out of the bounds
        //so the ClosestPoint function can move it back to the perimeter
        vec *= 1000;

        vec = GetMesh.mesh.bounds.ClosestPoint(vec);
        transform.localPosition = vec;

        ValidatePosition();
    }


}
