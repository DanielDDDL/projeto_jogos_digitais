using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	float movSpeed = 2.0f, rotationSpeed = 2.5f;
	float rotation = 5.0f;

	void Start () {
		
	}

	void Update () {

		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

		rotation += (xAxis * rotationSpeed);
		transform.eulerAngles = new Vector3(0, 0, rotation);

		var move = new Vector3 (0, yAxis, 0);
		transform.position += move * movSpeed * Time.deltaTime;

	}
}
