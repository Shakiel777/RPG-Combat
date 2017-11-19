// Copyright 2017 - David Rood
// A-Gen-C Entertainment (AGC)
// Shakiel@roadrunner.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position - offset;
    }
}
