using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MonteLadder : MonoBehaviour {

	public bool Monte = false;
	public float Vitesse = 8f;

	void Update () {
		if (Monte) 
		{
			GetComponent<CharacterController> ().transform.Translate (Vector3.up * Vitesse * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider Col)
	{
		if (Col.gameObject.tag == "Ladder") {
			GetComponent<FirstPersonController> ().enabled = false;
			Monte = true;
		}
	}

	void OnTriggerExit(Collider Col)
	{
		if (Col.gameObject.tag == "Ladder") {
			GetComponent<FirstPersonController> ().enabled = true;
			Monte = false;
		}
	}
}