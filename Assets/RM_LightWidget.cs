using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_LightWidget : MonoBehaviour
{
    public enum LightDirection {Up, Down, Left, Right, In, Out }

    public float movementSensitivity = 1.0F;
    public void MoveLight(LightDirection dir)
    {
        Vector3 mov = Vector3.zero;
        switch (dir)
        {
            case LightDirection.Up:
                mov = Vector3.up;
                break;
            case LightDirection.Right:
                mov = Vector3.right;
                break;
            case LightDirection.Out:
                mov = Vector3.forward;
                break;
            case LightDirection.Left:
                mov = Vector3.left;
                break;
            case LightDirection.In:
                mov = Vector3.back;
                break;
            case LightDirection.Down:
                mov = Vector3.down;
                break;
        }

        mov *= movementSensitivity;

        RM_Manager.Instance.lightAnchor.Move(mov);
    }
}
