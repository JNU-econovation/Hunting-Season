using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
            }
            return instance;
        }
    }
    private static LevelManager instance;

    [SerializeField] private GameObject player;
    void Start()
    {
        
    }

    public GameObject GetPlayer()
    {
        return player; 
    }
}
