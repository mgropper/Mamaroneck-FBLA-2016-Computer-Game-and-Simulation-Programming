﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Camera main;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        main.transform.position = transform.localPosition;
	}
}