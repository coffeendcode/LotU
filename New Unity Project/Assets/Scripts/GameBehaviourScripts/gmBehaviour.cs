﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gmBehaviour : MonoBehaviour
{

    public static gmBehaviour instance = null;
    public bool isPaused;

    public int test = 4;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
