using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f;

	private Vector3 playerPost = new Vector3 (0,-9.5f,0);
	
	// Update is called once per frame
	void Update () {
		float xPost = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		playerPost = new Vector3 (Mathf.Clamp(xPost,-8f,8f),-9.5f,0);
		transform.position = playerPost;
	}
}
