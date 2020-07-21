using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    Vector3 initPlayerPos;
    public GameObject mapPrefab;
    public GameObject portalPrefab;
    public GameObject playerPrefab;
    public GameObject player;
    private GameObject map1;
    private GameObject map2;
    Vector3[] a_portalPoses ={ new Vector3(-50,-22.04f,0),new Vector3(-38, -22.04f, 0),new Vector3(-26, -22.04f, 0),new Vector3(-14, -22.04f, 0),
                new Vector3(-2, -22.04f, 0),new Vector3(10, -22.04f, 0),new Vector3(24, -22.04f, 0)};
 
    private void Awake()
    {
        Instance = this;
    }
    public void SpawnMap()
    {
        map1 = Instantiate(mapPrefab);
        if (LevelLoader.Instance.isBigMap)
            map2 = Instantiate(mapPrefab, new Vector3(38.4f, 0, 0), Quaternion.identity);
    }
    public void SpawnPortal()
    {
        var portals = FindObjectsOfType<Portal>();
        for(int i = 0; i < portals.Length; i++)
        {
            portals[i].transform.position = a_portalPoses[i];
            if (portals[i].isPreScenePortal())
                SpawnPlayer(portals[i].transform.position);
        }

    }

    public void SpawnPlayer(Vector3 pos)
    {
        player = Instantiate(playerPrefab, pos, Quaternion.identity);
        Camera.main.GetComponent<CameraController>().Target = player;
    }
}
