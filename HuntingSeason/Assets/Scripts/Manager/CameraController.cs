using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public static CameraController Instance;

    public GameObject Target;
    public int Smoothvalue =2;
    public float PosY = 1;


    // Use this for initialization
    public Coroutine my_co;

    void Update()
    {
        if (Target == null)
            return;
        Vector3 Targetpos = new Vector3(Target.transform.position.x, Target.transform.position.y + PosY, -10);
        transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * Smoothvalue);

        if(LevelLoader.Instance.isBigMap)
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -42f, 16.6f), Mathf.Clamp(transform.position.y, -21.2f, 100), transform.position.z);
        else
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -42f, -21.8f), Mathf.Clamp(transform.position.y, -21.2f, 100), transform.position.z);



    }



}
