using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour {
    public Vector3 Target;
    public float Speed;
    
	void Update () {
        transform.position = Vector3.Lerp(transform.position, Target, Speed * Time.deltaTime);
	}
}
