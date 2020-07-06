using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static LightManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LightManager>();
            }
            return instance;
        }
    }
    private static LightManager instance;
    public GameObject pointLight;
    public GameObject globalLight;

    public void SetDayLight()
    {
        globalLight.SetActive(true);
        pointLight.SetActive(false);
    }

    public void SetNightLight()
    {
        globalLight.SetActive(false);
        pointLight.SetActive(true);
        pointLight.transform.position = InstantiateManager.Instance.player.transform.position;
    }
}
