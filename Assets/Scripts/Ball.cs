using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 500f;

	private Rigidbody rb;
	private bool ballInPlay;

	// Que es el metodo Awake?
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Que es Fire1?
		if (Input.GetButtonDown ("Fire1") && ballInPlay == false) 
		{
			transform.parent = null;
			ballInPlay = true;

			rb.isKinematic = false;
			rb.AddForce (new Vector3(ballInitialVelocity,ballInitialVelocity,0));
		}
	}
}
