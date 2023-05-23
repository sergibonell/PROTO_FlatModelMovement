using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestLogic : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        Debug.Log("Activated chest: " + gameObject.name);
        SceneLoader.Instance.LoadScene(Scenes.Test);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
