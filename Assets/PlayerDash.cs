using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDash : MonoBehaviour {

    public KeyCode TriggerKey;
    public AnimationCurve DashCurve;

    private float defaultSpeed;
    private NavMeshAgent Agent;

    private bool isDashing = false;
    private float startedAt = -1;

    void Start () {
        Agent = GetComponent<NavMeshAgent>();
        defaultSpeed = Agent.speed;
    }

    public void InterruptDash()
    {
        isDashing = false;
        Agent.speed = defaultSpeed;
    }
    
    void Update()
    {
        if (!isDashing && Input.GetKeyDown(TriggerKey) && Agent.remainingDistance >= 5f)
        {
            isDashing = true;
            startedAt = Time.time;
        }
        
        if (isDashing)
        {
            float lastTime = DashCurve.keys[DashCurve.keys.Length - 1].time * 0.9f;
            float elapsed = Time.time - startedAt;
            
            if (elapsed >= lastTime) {
                Agent.speed = defaultSpeed;
                isDashing = false;

                Vector3 explosionPos = Agent.transform.position;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, 15f);
                foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        rb.AddExplosionForce(5000f, explosionPos, 15f, 3f);
                    }
                }
            } else {
                Agent.speed = DashCurve.Evaluate(elapsed) * defaultSpeed;
            }
        }
    }
}
