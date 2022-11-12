using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RM_CameraControl : MonoBehaviour
{
    public Slider slider;
    public float scrollSensitivity = 1.0F;

    public Camera GetCamera
    {
        get
        {
            if (cam == null)
                cam = Camera.main;
            return cam;
        }
    }
    public Camera cam;

    // Start is called before the first frame update
    public void ChangeFieldOfView(Slider s)
    {
        GetCamera.fieldOfView = s.value;
    }

    public void ChangeFieldOfView(float value)
    {
        GetCamera.fieldOfView += value;
        if (slider != null)
            slider.value = GetCamera.fieldOfView;
    }

    private void Update()
    {
        OnScrollButton();
    }

    public void OnScrollButton()
    {

        float scroll =
        Input.mouseScrollDelta.y;
        if(scroll != 0)
        Debug.Log(Input.mouseScrollDelta);

        scroll *= scrollSensitivity;

        if (scroll != 0)
        {
            ChangeFieldOfView(scroll);
        }
    }
}
