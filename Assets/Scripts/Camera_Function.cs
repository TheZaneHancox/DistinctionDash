using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Function : MonoBehaviour {

    [SerializeField] //(so that we can see inside the inspector)
    private float X_max, X_min, y_max, y_min;

    private Player_Behaviour player;

    /* These values are used to prevent the camera from moving outside of the map.
     * Adjust when map is created.
     */
    private Transform target;
    
    // Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player").transform;
        player = GameObject.FindWithTag("Player").GetComponent<Player_Behaviour>();
	}
	
	// Ensure player has moved before we move the camera
	void LateUpdate () {
        if (player.isalive)
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, X_min, X_max),
            Mathf.Clamp(target.position.y, y_min, y_max),
            transform.position.z); //bounds the camera position
        }
    }
}
