using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RM_LookAt : MonoBehaviour
{
    [Tooltip("The target that this object will look at")]
    public Transform lookAtThis;


    // Update is called once per frame
    void Update()
    {
        if (lookAtThis != null)
            transform.LookAt(lookAtThis);
    }
}
