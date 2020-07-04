using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiateManager : MonoBehaviour
{
    public static InstantiateManager Instance;

    private Portal[] portals;
    [SerializeField] private GameObject PlayerPrefab;
    public GameObject player { get; set; }
    public bool isStart;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

       
    }

    private void Start()
    {
        portals = FindObjectsOfType<Portal>();
        if (isStart)
            player = Instantiate(PlayerPrefab, new Vector3(20, -3.5f,0), Quaternion.identity);
        else
            player = InstantiatePlayer();
        Camera.main.GetComponent<CameraController>().Target = player;
        isStart = false;
    }

    private GameObject InstantiatePlayer()
    {
        foreach (var portal in portals)
        {
            Vector3 pos = portal.GetPortalPos();
            if (pos != Vector3.zero)
            {
                return Instantiate(PlayerPrefab, pos, Quaternion.identity);
            }
        }
        return null;
    }
}
