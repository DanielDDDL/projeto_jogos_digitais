using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float initialForce;
	public int qntHitsLeft;

	// Use this for initialization
	void Start () {
		Rigidbody2D temporaryRigidBody = GetComponent<Rigidbody2D>();
		temporaryRigidBody.AddForce(transform.right * initialForce);
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnCollisionEnter2D (Collision2D other) {
		
		if (other.gameObject.tag == "Player") 
			//acertou algum jogador, a bala nao ricocheteia
			qntHitsLeft = 0;
		else 
			//caso contrario, apenas diminui a quantidade hits restantes
			qntHitsLeft--;
		
		if (qntHitsLeft == 0) 
			Destroy (gameObject);



	}

}
