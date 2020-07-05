using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    string linkedSceneName;

    public LayerMask layerMask;

    private void Start()
    {
       //StartCoroutine(DetectPlayer());
    }

    IEnumerator DetectPlayer()
    {
        while (true)
        {
            yield return null;
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), transform.forward * -1, 10f, layerMask);
            RaycastHit2D hit1 = Physics2D.Raycast(new Vector2(transform.position.x + 1f, transform.position.y), transform.forward * -1, 10f, layerMask);
            RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x + 1f, transform.position.y + 1f), transform.forward * -1, 10f, layerMask);
            RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x + 1f, transform.position.y - 1f), transform.forward * -1, 10f, layerMask);
            RaycastHit2D hit4 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1f), transform.forward * -1, 10f, layerMask);
            RaycastHit2D hit5 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1f), transform.forward * -1, 10f, layerMask);
            RaycastHit2D hit6 = Physics2D.Raycast(new Vector2(transform.position.x - 1f, transform.position.y), transform.forward * -1, 10f, layerMask);
            RaycastHit2D hit7 = Physics2D.Raycast(new Vector2(transform.position.x - 1f, transform.position.y + 1f), transform.forward * -1, 10f, layerMask);
            RaycastHit2D hit8 = Physics2D.Raycast(new Vector2(transform.position.x - 1f, transform.position.y - 1f), transform.forward * -1, 10f, layerMask);
            if (hit || hit1 || hit2 || hit3)
            {
                print(hit.collider);
                if (Input.GetKeyDown(KeyCode.UpArrow))
                    LevelLoader.Instance.LoadNextLevel(linkedSceneName);
            }
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
