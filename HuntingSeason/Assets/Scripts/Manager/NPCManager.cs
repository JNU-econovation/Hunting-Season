using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<NPCManager>();
            }
            return instance;
        }
    }
    private static NPCManager instance;

    private int npcCount;
    public GameObject[] npcPrefabs;

    private void Awake()
    {
        npcCount = InstantiateManager.Instance._index % 2 == 0 ? 2 : 1;

        npcPrefabs = Resources.LoadAll<GameObject>("Prefabs/NPC");

    }
    public void SpawnNPC()
    {
        for(var i = 0; i < npcCount; i++)
        {
            int randIndex = Random.Range(0, npcPrefabs.Length);
            float randXpos = Random.Range(-45.0f, -15.0f);
            Instantiate(npcPrefabs[randIndex], new Vector3(randXpos, -21.3f, 0), Quaternion.identity);
        }
    }
}
