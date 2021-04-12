﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    GameObject tutorial;
    public void ShowTutorial()
    {
        tutorial.SetActive(true);
    }

    public void HideTutorial()
    {
        tutorial.SetActive(false);

    }
}
