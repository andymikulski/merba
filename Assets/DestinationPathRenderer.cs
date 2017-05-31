using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestinationPathRenderer : MonoBehaviour {
    public NavMeshAgent Agent;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        if (line == null)
        {
            line = gameObject.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.yellow };
            line.startWidth = 0.5f;
            line.endWidth = 0.5f;
            line.startColor = Color.yellow;
            line.endColor = Color.yellow;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Agent == null || Agent.path == null)
            return;

        float dist = 0f;
        NavMeshPath path = Agent.path;
        line.positionCount = path.corners.Length;

        for (int i = 0; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]);
            if (i > 0)
                dist = dist + Vector3.Distance(path.corners[i - 1], path.corners[i]);
        }
    }
}
