using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnPress : MonoBehaviour {
    public KeyCode KeyToWatch;
    public Camera ToActivate;
	
	void Update () {
        if (Input.GetKeyDown(KeyToWatch))
        {
            ToActivate.enabled = true;
        } else if (Input.GetKeyUp(KeyToWatch))
        {
            ToActivate.enabled = false;
        }
    }
}
