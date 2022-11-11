using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_Manager : MonoBehaviour
{
    public GameObject modelRoot;
    public RM_CameraAnchor cameraAnchor;
    public RM_Anchor lightAnchor;
    public RM_ModelAnchor modelAnchor;
    public RM_ModelList modelManager;
    public RM_LightWidget lightWidget;

    public bool randomizeOnStart = true;

    static RM_Manager _instance;
    public static RM_Manager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<RM_Manager>(true);

            return _instance;
        }
    }

    public void RepositionCameraToRandomPoint() {
        cameraAnchor.RepositionToRandomPoint();
    }
    public void RotateModel() {
        modelAnchor.RandomRotate();
    }
    public void RepositionLightToRandomPoint() {
        lightAnchor.RepositionToRandomPoint();
    }

    private void Start()
    {
        if (_instance == this)
        {
            //Intentionally blank
        }
        else if (_instance != null)
        {
            Debug.LogError("Only one instance of RM_Manager is allowed to exist.");
            GameObject.Destroy(this);
            return;
        }
        _instance = this;

        if(randomizeOnStart)
            RandomizeStart();
    }

    void RandomizeStart()
    {
        cameraAnchor.RepositionToRandomPoint();
        lightAnchor.RepositionToRandomPoint();
        modelManager.ChooseRandomModel();
    }
}
