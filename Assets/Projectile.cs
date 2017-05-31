using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public AnimationCurve PathX;
    public AnimationCurve PathY;
    public AnimationCurve PathZ;

    public float maxDistance = 20f;

    private float timeStart;

    void Start()
    {
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update () {
        float elapsed = Time.time - timeStart;
        float xPos = PathX.Evaluate(elapsed);
        float yPos = PathY.Evaluate(elapsed);
        float zPos = PathZ.Evaluate(elapsed);
    }
}
