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
    public bool IsDay;
    private int hour;
    void Update()
    {
        time += Time.deltaTime;
        if (time >= dayTime)
        {
            time = 0;
        }
        hour = (int)(time / dayTime * 24);
        if (6 <= hour && hour < 18)
        {
            IsDay = true;
            LightManager.Instance.SetDayLight();
        }
        else
        {
            IsDay = false;
            LightManager.Instance.SetNightLight();
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
