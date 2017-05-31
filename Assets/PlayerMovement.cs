using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {
    private NavMeshAgent Agent;
    private Animator Anim;

    private Vector3 previousPosition;
    private float measuredSpeed;
    
    public float headLookSpeed;

    public KeyCode QueueKey;

    public GameObject Marker;

    private PlayerDash dash;

    private List<Transform> moveQueue;

    // Use this for initialization
    void Start () {
        dash = GetComponent<PlayerDash>();
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponentInChildren<Animator>();
        Anim.SetFloat("Speed_f", 0f);       
        Marker.transform.position = transform.position;
        previousPosition = transform.position;
    }


    // Update is called once per frame
    void Update () {
        Vector3 curMove = transform.position - previousPosition;
        measuredSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;

        Anim.SetFloat("Speed_f", measuredSpeed);
        
        RaycastHit hit;

        for(int i = Camera.allCamerasCount - 1; i >= 0; i--)
        {
            if (Camera.allCameras[i].enabled && Physics.Raycast(Camera.allCameras[i].ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Floor")))
            {
                if (Input.GetMouseButton(1))
                {
                    if (dash != null && dash.isActiveAndEnabled)
                        dash.InterruptDash();

                    Agent.SetDestination(hit.point);
                    Agent.transform.LookAt(hit.point);
                    break;
                }

                if (Input.GetMouseButtonUp(1))
                {
                    GameObject newMarker = Instantiate(Marker) as GameObject;
                    newMarker.transform.position = hit.point - (Vector3.down * 5f);
                    newMarker.SetActive(true);
                    break;
                }

                //float lookAngle = Mathf.Clamp(AngleDir(transform.forward, transform.position - hit.point, transform.up), -1f, 1f);
                //float nextAngle = Mathf.Lerp(Anim.GetFloat("Head_Horizontal_f"), lookAngle, headLookSpeed * Time.deltaTime);
                // Anim.SetFloat("Head_Horizontal_f", nextAngle);
            }
        }

        

        
    }

    public float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        return -1 * dir;
    }
}
