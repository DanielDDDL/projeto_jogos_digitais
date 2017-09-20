using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		speed = 12f;	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(1, 0) * Time.deltaTime * speed);
	}
}
