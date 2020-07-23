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
    public int _index
    {
        get { return SceneManager.GetActiveScene().buildIndex; }
    }

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
            player = Instantiate(PlayerPrefab, new Vector3(-40, -5, 0), Quaternion.identity);
            Camera.main.GetComponent<CameraController>().Target = player;
            LevelManager.Instance.player = player;
        }
        else
        {
            LevelManager.Instance.SpawnPortal();
        }
        NPCManager.Instance.SpawnNPC();
        isStart = false;

    }
    
    
}
