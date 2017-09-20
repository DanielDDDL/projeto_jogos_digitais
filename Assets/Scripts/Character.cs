using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	float movSpeed = 2.0f;
	float rotationLocation = 5.0f, rotationSpeed = 2.5f;

	public GameObject projectilePrefab;

	void Start () {
		
	}

	void Update () {

		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

		rotationLocation += (xAxis * rotationSpeed);
		transform.eulerAngles = new Vector3(0, 0, rotationLocation);

		var move = new Vector3 (0, yAxis, 0);
		transform.position += move * movSpeed * Time.deltaTime;

		if (Input.GetButtonDown ("Fire1")) {
			Instantiate(projectilePrefab, transform.position, transform.rotation);
		}
		
	}
}
