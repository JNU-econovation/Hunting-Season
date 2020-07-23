using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject[] environments;
    public GameObject[] trees;
    private static int count;
    private static int treeCount;
    private void OnEnable()
    {
        trees = Resources.LoadAll<GameObject>("Prefabs/Tree");
        environments = Resources.LoadAll<GameObject>("Prefabs/Environments");
        count = InstantiateManager.Instance._index % 2 == 0 ? 4 : 2;
        treeCount = InstantiateManager.Instance._index % 2 == 0 ? 1 : 0;
        SpawnEnv();
    }

    public void SpawnEnv()
    {
        for (var i = 0; i < treeCount; i++)
        {
            int randIndex = Random.Range(0, 3);
            float randXpos = Random.Range(-45.0f, -15.0f);
            GameObject temp = Instantiate(trees[randIndex], new Vector3(randXpos, -18.36f, 0), Quaternion.identity);
            temp.transform.SetParent(gameObject.transform);
        }
        for (var i = 0; i < count; i++)
        {
            int randIndex = Random.Range(0, environments.Length);
            float randXpos = Random.Range(-45.0f, -15.0f);
            GameObject temp = Instantiate(environments[randIndex], new Vector3(randXpos, -22.51f, 0), Quaternion.identity);
            temp.transform.SetParent(gameObject.transform);
        }
    }
}
