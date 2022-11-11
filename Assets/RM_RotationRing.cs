using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_RotationRing : MonoBehaviour
{
    public SnapAxis axis = SnapAxis.X;

    public RM_RotationWidget root;
    Vector3 lastClick;

    public bool rollingRing = false;
    public void OnMouseUp()
    {
        rollingRing = false;
    }

    public void OnMouseDown()
    {
        if (root == null)
            root = GetComponentInParent<RM_RotationWidget>();

        if (root == null)
        {
            Debug.LogError("No Rotation Widget found in parent of Rotation Ring");
            return;
        }


        Debug.Log(name + " Mouse Downed.");
        rollingRing = true;
        lastClick = Input.mousePosition;
    }

    private void FixedUpdate()
    {
        if (rollingRing)
            RollRing();
    }
    void RollRing()
    {
        Debug.Log("Rolling ring.");

        Vector2 delta = lastClick - Input.mousePosition;

        float mult = 1;

        float highest = Mathf.Abs(delta.y);
        if (delta.y < 0)
            mult = -1;

        if (Mathf.Abs(delta.x) > highest)
        {
            highest = Mathf.Abs(delta.x);
            if (delta.x < 0)
                mult = -1;
        }

        highest *= mult;


        if ( axis == SnapAxis.X)
        {
            root.RotateTarget(axis, highest);
            //Rotate by the x delta
        }
        else if (axis == SnapAxis.Y)
        {
            //Rotate by the y delta
            root.RotateTarget(axis, highest);
        }
        else if (axis == SnapAxis.Z)
        {
           
            root.RotateTarget(axis, highest);
        }
        
    }
}
