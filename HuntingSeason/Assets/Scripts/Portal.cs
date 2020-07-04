using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    string linkedSceneName;

    public LayerMask layerMask;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.forward, layerMask);
        if (hit.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                LevelLoader.Instance.LoadNextLevel(linkedSceneName);
        }

    }

    public Vector3 GetPortalPos()
    {
        if (linkedSceneName == SceneLoader.Instance.preSceneName)
        {
            return transform.position;
        }
        else
            return Vector3.zero;
    }
}
