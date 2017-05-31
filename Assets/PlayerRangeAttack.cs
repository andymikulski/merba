using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour {
    public float maxHeight;
    public float maxDistance;

    public AnimationCurve ProjectileArc;

    private bool isShooting = false;
    private float startedAt = -1f;

    public KeyCode TriggerKey;
    private bool hasTrigger;
    
	void Update () {
		if (hasTrigger)
        {
            // right click = cancel the trigger
            if (Input.GetMouseButtonDown(1))
            {
                hasTrigger = false;
            // left click = spawn the projectile prefab
            } else if (Input.GetMouseButtonDown(0))
            {
                hasTrigger = false;
            }
        } else if (Input.GetKeyDown(TriggerKey))
        {
            hasTrigger = true;
        }
	}
}
