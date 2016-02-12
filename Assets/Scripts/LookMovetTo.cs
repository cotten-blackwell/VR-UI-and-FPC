﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LookMovetTo : MonoBehaviour {
    public GameObject ground;
    public Transform infoBubble;

    private Text infoText;

    void Start()
    {
        if (infoBubble != null)
        {
            infoText = infoBubble.Find("Text").GetComponent<Text>();

        }
    }

	// Update is called once per frame
	void Update () {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f);

        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == ground)
            {
                if (infoBubble != null)
                {
                    infoText.text = "X:" + hit.point.x.ToString("F2") + ", Z:" + hit.point.z.ToString("F2");
                    infoBubble.LookAt(camera.position);
                    infoBubble.Rotate(0.0f, 180.0f, 0.0f);
                }
                Debug.Log("hit (x,y,z): " + hit.point.ToString("F2"));
                transform.position = hit.point;
            }
        }
	}
}
