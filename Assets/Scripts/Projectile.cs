using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float initialForce;

	// Use this for initialization
	void Start () {
		Rigidbody2D temporaryRigidBody = GetComponent<Rigidbody2D>();
		temporaryRigidBody.AddForce(transform.right * initialForce);
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnCollisionEnter2D (Collision2D other) {

		Debug.Log ("Colisão detectada!");

	}

}
