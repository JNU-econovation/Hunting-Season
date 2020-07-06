using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;
    public string currentSceneName;
    public string preSceneName;
    public Animator transition;
    float transitionTime = 1f;
    public bool isBigMap;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void LoadNextLevel(string nextScene)
    {
        SceneLoader.Instance.preSceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(LoadLevel(nextScene));
    }

    IEnumerator LoadLevel(string nextScene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(nextScene);
    }
}
