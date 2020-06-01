using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Clock : MonoBehaviour
{
    Animator animator;
    [SerializeField] private GameObject obj_HourHand;
    float dayTime;
    bool CanChange;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        dayTime = TimeManager.Instance.GetDayTime();
        StartCoroutine(StreamTime());
    }

    IEnumerator StreamTime()
    {
        while (true)
        {

            int currentHour = TimeManager.Instance.GetHour();
            obj_HourHand.transform.Rotate(new Vector3(0, 0, -30 / (dayTime / 24)) * Time.deltaTime);

            if (currentHour == 6) //아침
            {
                if (CanChange)
                {
                    animator.SetTrigger("Day");
                    CanChange = false;
                }
            }
            else if (currentHour == 18)
            {
                if (CanChange)
                {
                    animator.SetTrigger("Night");
                    CanChange = false;
                }
            }
            else
            {
                CanChange = true;
            }

            yield return null;
        }
    }



 
}
