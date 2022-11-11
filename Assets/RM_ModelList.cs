using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_ModelList : MonoBehaviour
{

    public GameObject modelRoot;
    public GameObject activeModel;

    public void ChooseRandomModel()
    {
        if (modelRoot == null || modelRoot.transform.childCount == 0)
            return;


        int n = Random.Range(0, modelRoot.transform.childCount);
        Transform t = modelRoot.transform.GetChild(n);
        ChangeModel(t.gameObject);
    }

   public void ChangeModel(GameObject model)
    {
        if (model == null || modelRoot == null)
        {
            Debug.LogError("Given model or the model root of " + name + " is null.");
            return;
        }

        int modelIndex = model.transform.GetSiblingIndex();

        //Get the model from the model root

        Transform child = modelRoot.transform.GetChild(modelIndex);
        activeModel = child.gameObject;
        activeModel.gameObject.SetActive(true);

        //Deactivate all other models but the current active model
        foreach (Transform t in modelRoot.transform)
            if (t != activeModel.transform)
                t.gameObject.SetActive(false);

        RM_RotationWidget.SetTarget(activeModel);
    }
}
