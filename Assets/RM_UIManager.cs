using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RM_UIManager : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject uiModelButtonDupe;


    void FillModelListWithButtons()
    {
        //Get the model gameObject root

        //For each model, create a button
        foreach (Transform child in RM_Manager.Instance.modelRoot.transform)
        {
            if (child == RM_Manager.Instance.modelRoot.transform)
                continue;

            if (child == null)
                continue;

            CreateButtonDupe(child);
        }

        //Add the button to the scrollviewcontent
    }

    void CreateButtonDupe(Transform model)
    {
        GameObject dupe = GameObject.Instantiate(uiModelButtonDupe);
        dupe.SetActive(true);
        dupe.name = model.name;

        dupe.GetComponentInChildren<TMPro.TMP_Text>(true).text = model.name;
        dupe.transform.SetParent(scrollViewContent.transform);
    }
    private void Start()
    {
        FillModelListWithButtons();
    }
}
