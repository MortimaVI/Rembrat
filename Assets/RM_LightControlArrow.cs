using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_LightControlArrow : MonoBehaviour
{
    public RM_LightWidget.LightDirection direction = RM_LightWidget.LightDirection.Up;

    bool movingLight = false;

    public void OnMouseDown()
    {
        movingLight = true;
        RM_Manager.Instance.lightWidget.MoveLight(direction);
    }

    private void FixedUpdate()
    {
        if(movingLight)
            RM_Manager.Instance.lightWidget.MoveLight(direction);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
            movingLight = false;
    }
}
