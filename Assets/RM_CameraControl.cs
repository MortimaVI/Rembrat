using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RM_CameraControl : MonoBehaviour
{

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
}
