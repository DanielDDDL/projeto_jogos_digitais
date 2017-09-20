using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public GameObject bulletEmitter;
	public GameObject bullet;

	public float movSpeed;
	public float rotationLocation;
	public float rotationSpeed;

	void Start () {
		
	}

	void Update () {

		float xAxis, yAxis;


		if (gameObject.tag == "Player1") {
		
			xAxis = Input.GetAxis ("HorizontalP1");
			yAxis = Input.GetAxis ("VerticalP1");

			if (Input.GetButtonDown ("FireP1"))
				Fire ();

		} else {
		
			xAxis = Input.GetAxis ("HorizontalP2");
			yAxis = Input.GetAxis ("VerticalP2");

			if (Input.GetButtonDown ("FireP2"))
				Fire ();
		}

		rotationLocation += (xAxis * rotationSpeed);
		transform.eulerAngles = new Vector3(0, 0, rotationLocation);

		var move = new Vector3 (0, yAxis, 0);
		transform.position += move * movSpeed * Time.deltaTime;

	}

	void Fire(){
		Instantiate(bullet,bulletEmitter.transform.position,bulletEmitter.transform.rotation);
	}
}
