using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpOpacity : MonoBehaviour {
    private Projector proj;
    private float val = 1f;
    public float Speed = 20f;

    private Material originalMaterial;

	void Start () {
        proj = GetComponent<Projector>();
        originalMaterial = new Material(proj.material);

        Reset();
	}
	
	void Update () {
        Color newColor = Color.Lerp(proj.material.color, Color.black, Time.deltaTime * Speed);
        //proj.material.SetColor("Main Color", newColor);
        proj.material.color = newColor;
    }

    public void Reset()
    {
        proj.material = new Material(originalMaterial);
    }
}
