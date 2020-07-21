using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    string linkedSceneName;

    public LayerMask layerMask;

    public bool isPreScenePortal()
    {
        return linkedSceneName == SceneLoader.Instance.preSceneName;
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        // layer 8은 player
        if (collider.gameObject.layer == 8)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                LevelLoader.Instance.LoadNextLevel(linkedSceneName);
        }
    }

}
