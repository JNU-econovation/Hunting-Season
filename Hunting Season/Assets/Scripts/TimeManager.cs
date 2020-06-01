using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<TimeManager>();
            }
            return instance;
        }
    }
    private static TimeManager instance;
    [SerializeField] float time = 6;
    [SerializeField] float dayTime;
 
    void Update()
    {
        time += Time.deltaTime;
        if (time >= dayTime)
        {
            time = 0;
        }
    }
    public int GetHour()
    {
        return (int)(time / dayTime * 24);
    }
    public float GetDayTime()
    {
        return dayTime;
    }
}
