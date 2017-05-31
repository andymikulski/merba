using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobaCamera : MonoBehaviour {
    public Transform Target;
    private Vector3 offset;
    private Vector3 dragOrigin;
    private Vector3 oldPos;
    private bool isDragging = false;
    public float dragSpeed = 10f;

    public float FollowSpeed = 20f;

	// Use this for initialization
	void Start () {
        offset = transform.position - Target.position;
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            isDragging = true;
            oldPos = transform.position;
            dragOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        if (isDragging && Input.GetMouseButton(2))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - dragOrigin;
            transform.position = oldPos - (pos * dragSpeed);
        } else if (!isDragging) {
            transform.position = Vector3.Lerp(transform.position, Target.position + offset, Time.deltaTime * FollowSpeed);
        }

        if (Input.GetMouseButtonUp(2))
        {
            isDragging = false;
        }
    }
}
