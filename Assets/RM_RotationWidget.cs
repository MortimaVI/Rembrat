using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_RotationWidget : MonoBehaviour
{

    static RM_RotationWidget _instance;
    public static RM_RotationWidget Instance;
    public static void SetTarget(GameObject obj)
    {
        if (_instance == null)
        {
            Debug.LogError("RM Widget has no static instance.");
            return;
        }
        _instance.target = obj.transform;
    }

    public Transform target;
    public float rotationSensitivity = 1.0F;
    public float maxRotationSpeed = 10;

    private void Start()
    {
        _instance = this;
    }

    public void RotateTarget(SnapAxis axis, float value)
    {
        if (target == null)
        {
            Debug.LogError("No target selected to rotate.");
            return;
        }
        value *= rotationSensitivity;
        if (value > maxRotationSpeed)
            value = maxRotationSpeed;

        if (value < -maxRotationSpeed)
            value = -maxRotationSpeed;

        float x=0, y=0, z=0;
        switch (axis)
        {
            case SnapAxis.X:
                x = value;
                break;
            case SnapAxis.Y:
                y = value;
                break;
            case SnapAxis.Z:
                z = value;

                break;
        }
        Vector3 rot = new Vector3(x,y,z);

        target.Rotate(rot);
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;
        transform.rotation = target.transform.rotation;
    }
}
