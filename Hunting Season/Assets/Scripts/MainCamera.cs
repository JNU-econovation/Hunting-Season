using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = LevelManager.Instance.GetPlayer();
    }

    
    void Update()
    {
        float playerXpos = player.transform.position.x;

        if(-8.5 <= playerXpos && playerXpos <= 8.5f)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
