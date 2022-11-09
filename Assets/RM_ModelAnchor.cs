using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_ModelAnchor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            Debug.Log("Moving " + name + " to the center of its parent.");
            transform.localPosition = Vector3.zero;
        }
    }

    public void RandomRotate()
    {
        Vector3 rotation = Toolbox.Range(Vector3.zero, new Vector3(360,360,360));
        transform.localEulerAngles = rotation;
    }
}
