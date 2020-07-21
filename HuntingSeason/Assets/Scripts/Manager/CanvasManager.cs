using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    [SerializeField] private GameObject clockObj;
    [SerializeField] private GameObject hpObj;
    [SerializeField] private GameObject dialogueObj;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }
  
    private void SetCanvasData()
    {

    }
    public void SetHpImg(int hp, int maxHp)
    {
        Text hpText = hpObj.transform.Find("HpText").GetComponent<Text>();
        Image hpImg = hpObj.transform.Find("HpImg").GetComponent<Image>();

        hpText.text = string.Format("{0} / {1}", hp, maxHp);
        hpImg.fillAmount = (float)hp / maxHp;
    }

}
