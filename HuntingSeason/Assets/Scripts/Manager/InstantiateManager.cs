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
        Instance = this;      
    }

    private void Start()
    {
        LevelManager.Instance.SpawnMap();
       
        portals = FindObjectsOfType<Portal>();
        if (isStart)
        {
            player = Instantiate(PlayerPrefab, new Vector3(-40, -10, 0), Quaternion.identity);
            Camera.main.GetComponent<CameraController>().Target = player;
        }
        else
        {
            LevelManager.Instance.SpawnPortal();
        }
        
        isStart = false;

    }
    
    
}
