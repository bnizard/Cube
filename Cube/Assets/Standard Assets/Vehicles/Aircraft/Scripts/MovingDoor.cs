using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoor : MonoBehaviour {
	public GameObject upDoor;
	public GameObject downDoor;
	private float Vitesse = 5f;
	private enum Move {Up, Zero, Down};
	private float InitYDoor;
	Move mydirection;


	// Use this for initialization
	void Start () {
		mydirection = Move.Zero;
		InitYDoor = upDoor.gameObject.transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		if ((upDoor.gameObject.transform.position.y >= InitYDoor + 1.8 && mydirection == Move.Up) || (upDoor.gameObject.transform.position.y < InitYDoor + 0.02 && mydirection == Move.Down))
			mydirection = Move.Zero;
		if (mydirection == Move.Up) {
			upDoor.transform.Translate(Vector3.up * Vitesse * Time.deltaTime); // tu peux changer les valeurs!
			downDoor.transform.Translate(Vector3.down * Vitesse * Time.deltaTime); // tu peux changer les valeurs!
		} else if (mydirection == Move.Down) {
			upDoor.transform.Translate(Vector3.down * Vitesse * Time.deltaTime); // tu peux changer les valeurs!
			downDoor.transform.Translate(Vector3.up * Vitesse * Time.deltaTime); // tu peux changer les valeurs!
		}
	}

	void OnTriggerStay(Collider Col)
	{
		if (Col.gameObject.tag == "Door" && Input.GetKeyDown(KeyCode.E)) {
			mydirection = Move.Up;
			Debug.Log("Enter Door");
		}
	}

	void OnTriggerExit(Collider Col)
	{
		if (Col.gameObject.tag == "Door") {
			mydirection = Move.Down;
			Debug.Log("Exit Door");
		}
	}
}
