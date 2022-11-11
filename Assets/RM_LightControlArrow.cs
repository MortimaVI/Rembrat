using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_LightControlArrow : MonoBehaviour
{
    public RM_LightWidget.LightDirection direction = RM_LightWidget.LightDirection.Up;

    public void OnMouseDown()
    {
        RM_Manager.Instance.lightWidget.MoveLight(direction);
    }
}
