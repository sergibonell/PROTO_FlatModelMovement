using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedObject;
    private IInteractable inter;

    private int defaultLay;
    private int highlightLay;

    private void Awake()
    {
        defaultLay = LayerMask.NameToLayer("Default");
        highlightLay = LayerMask.NameToLayer("Highlighted");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IInteractable>(out inter) && selectedObject == null)
        {
            selectedObject = other.gameObject;
            changeLayer(highlightLay);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == selectedObject)
        {
            changeLayer(defaultLay);
            selectedObject = null;
        }
    }

    private void changeLayer(int layer)
    {
        if (selectedObject == null)
        {
            Debug.LogWarning("Can't highlight null object"); 
            return;
        }

        selectedObject.layer = layer;
        foreach(Transform child in selectedObject.transform)
            child.gameObject.layer = layer;
    }

    private void OnInteract()
    {
        if (inter != null)
            inter.OnInteract();
    }
}
