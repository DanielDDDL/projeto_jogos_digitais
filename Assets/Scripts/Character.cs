using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public GameObject bulletEmitter;
	public GameObject bullet;

	float movSpeed = 2.0f;
	float rotationLocation = 5.0f, rotationSpeed = 2.5f;

	void Start () {
		
	}

	void Update () {

		float xAxis = Input.GetAxis ("HorizontalP1");
		float yAxis = Input.GetAxis ("VerticalP1");

		rotationLocation += (xAxis * rotationSpeed);
		transform.eulerAngles = new Vector3(0, 0, rotationLocation);

		var move = new Vector3 (0, yAxis, 0);
		transform.position += move * movSpeed * Time.deltaTime;

		//tiro

		if (Input.GetButtonDown ("FireP1")) {
			Instantiate(bullet,bulletEmitter.transform.position,bulletEmitter.transform.rotation);

		}
		
	}
}
