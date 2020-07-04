﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemBoot : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("B");
    }
    void Start()
    {
        InstantiateManager.Instance.isStart = true;
    }

}
