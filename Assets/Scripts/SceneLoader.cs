using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }
    private Animator animator;
    [SerializeField]
    private float loadTime;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        animator = GetComponentInChildren<Animator>();

        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(Scenes scene)
    {
        StartCoroutine(LoadSceneCoroutine(scene.ToString()));
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(loadTime);

        SceneManager.LoadScene(sceneName);

        animator.SetTrigger("End");
    }
}