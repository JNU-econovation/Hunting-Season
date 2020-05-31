using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float time = 0;
    [SerializeField] float dayTime;
    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= dayTime)
        {
            time = 0;
        }
    }
}
