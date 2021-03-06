﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neocam : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    Camera cam;

    public float sensitivity = 4.0f;
    public float smoothing = 2.0f;

    GameObject player;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        mouseLook += smoothV;
        cam.transform.rotation = Quaternion.Inverse(transform.rotation) * Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        cam.transform.position = transform.position;
        transform.rotation = Quaternion.AngleAxis(-mouseLook.x, transform.up);
    }
}
