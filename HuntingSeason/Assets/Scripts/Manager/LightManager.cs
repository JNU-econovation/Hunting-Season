using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
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
    Light2D pointLight2D;
    private void Awake()
    {
        pointLight2D = pointLight.GetComponent<Light2D>();
    }
    public void SetDayLight()
    {
        StartCoroutine(TurnToDay());
        if(LevelManager.Instance.player != null)
            pointLight.transform.position = LevelManager.Instance.player.transform.position;
    }

    public void SetNightLight()
    {
        StartCoroutine(TurnToNight());
        if (LevelManager.Instance.player != null)
            pointLight.transform.position = LevelManager.Instance.player.transform.position;
    }

    IEnumerator TurnToDay()
    {
        while (pointLight2D.pointLightOuterRadius < 60f && pointLight2D.pointLightInnerRadius < 56f)
        {
            yield return null; 
            pointLight2D.pointLightOuterRadius += Time.deltaTime;
            pointLight2D.pointLightInnerRadius += Time.deltaTime;
        }

        pointLight.SetActive(false);
        globalLight.SetActive(true);
    }

    IEnumerator TurnToNight()
    {
        pointLight.SetActive(true);
        globalLight.SetActive(false);

        while (pointLight2D.pointLightOuterRadius > 4f && pointLight2D.pointLightInnerRadius > 0f)
        {
            yield return null;
            pointLight2D.pointLightOuterRadius -= Time.deltaTime;
            pointLight2D.pointLightInnerRadius -= Time.deltaTime;
        }
    }
}
