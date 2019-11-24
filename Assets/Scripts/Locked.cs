﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked : MonoBehaviour
{
    public QuestionManager qm;
    public GameObject door;
    private void Start()
    {
        qm = FindObjectOfType<QuestionManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (qm.getScore() >= 20) {
            door.SetActive(true);
        }
        Debug.Log(qm.getScore());
    }
}
