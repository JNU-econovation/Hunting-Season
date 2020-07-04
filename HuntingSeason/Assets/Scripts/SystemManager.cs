using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SystemManager : MonoBehaviour
{
    public static SystemManager Instance;

    private Portal[] portals;
    [SerializeField] private GameObject PlayerPrefab;
    public GameObject player { get; set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

   

}
