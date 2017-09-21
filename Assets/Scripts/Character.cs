using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public GameObject bulletEmitter;
	public GameObject bullet;

	public float movSpeed;
	public float rotationLocation;
	public float rotationSpeed;

	public int initialHp, initialDamage;
	public int hpMultValue, dmgMultValue;
	private int hp, damage;

	private readonly string player1_dmg_mult = "PLAYER_1_DMG_MULT";
	private readonly string player1_hp_mult  = "PLAYER_1_HP_MULT";
	private readonly string player2_dmg_mult = "PLAYER_2_DMG_MULT";
	private readonly string player2_hp_mult  = "PLAYER_2_HP_MULT";

	void Start () {

		int dmgMult = 0;
		int hpMult = 0;

		//carregando configuracoes
		if (gameObject.tag == "Player1") {
			dmgMult = PlayerPrefs.GetInt (player1_dmg_mult);
			hpMult  = PlayerPrefs.GetInt (player1_hp_mult);

		} else if (gameObject.tag == "Player2") {
			dmgMult = PlayerPrefs.GetInt (player2_dmg_mult);
			hpMult  = PlayerPrefs.GetInt (player2_hp_mult);

		}

		damage = initialDamage + (dmgMult * dmgMultValue);
		hp     = initialHp     + (hpMult * hpMultValue);

		//setting the values on the bullet
		bullet.GetComponent<Projectile> ().damage = damage;

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

	void OnCollisionEnter2D (Collision2D other) {

		if(other.gameObject.tag == "Projectile"){

			//acessando a referencia do script
			int damageDealt = other.gameObject.GetComponent<Projectile>().damage;
			hp -= damageDealt;

			Debug.Log ("Hit! " + gameObject.tag + "'s life went down to " + hp);

			if(hp <= 0){
				//fim de jogo
				//restart, menu principal, whatever
				Debug.Log ("And, by the way, he died");	
			}

		}

	}

}
