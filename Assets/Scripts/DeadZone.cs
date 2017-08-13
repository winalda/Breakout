using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	void OnTriggerEnter()
	{
		Debug.Log ("Colicion ***********");
		GM.instance.LoseLife ();
	}

}
