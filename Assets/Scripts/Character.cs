using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	public GameObject bulletEmitter;
	public GameObject bullet;
	public GameController gameController;

	public Text lblHpPlayer;

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

			Debug.Log ("HP  recuperado p1: " + hpMult);
			Debug.Log ("Dmg recuperado p1: " + dmgMult);

		} else if (gameObject.tag == "Player2") {
			dmgMult = PlayerPrefs.GetInt (player2_dmg_mult);
			hpMult  = PlayerPrefs.GetInt (player2_hp_mult);

			Debug.Log ("HP  recuperado p2: " + hpMult);
			Debug.Log ("Dmg recuperado p2: " + dmgMult);

		}

		damage = initialDamage + (dmgMult * dmgMultValue);
		hp     = initialHp     + (hpMult * hpMultValue);

		//setando os valores nas balas
		bullet.GetComponent<Projectile> ().damage = damage;

		UpdateLabelHp ();

	}

	void Update () {

		UpdateLabelHp ();

		if (gameController.IsGameFinished ()) {
			
			if (Input.GetKeyDown(KeyCode.R)) {
				gameController.RestartGame ();

			} else if (Input.GetKeyDown(KeyCode.T)) {
				gameController.InitialMenu ();

			}

		} else {
			
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

	}

	void Fire(){
		Instantiate(bullet,bulletEmitter.transform.position,bulletEmitter.transform.rotation);
	}

	void UpdateLabelHp(){
		lblHpPlayer.text = hp + "";
	}

	void OnCollisionEnter2D (Collision2D other) {

		if(other.gameObject.tag == "Projectile"){

			//acessando a referencia do script
			int damageDealt = other.gameObject.GetComponent<Projectile>().damage;
			hp -= damageDealt;

			Debug.Log ("Hit! " + gameObject.tag + "'s life went down to " + hp);

			if(hp <= 0){
				
				//fim de jogo

				//por que iriamos passar disso?
				//por que chutar cachorro morto?
				hp = 0;

				string playerNameIsh = "";
				if(gameObject.tag == "Player1")
					//se quem morreu foi o player 1...
					playerNameIsh = "Player 2";
				else 
					//se quem morreu foi o player 2...
					playerNameIsh = "Player 1";
				

				gameController.FinishGame(playerNameIsh);//TODO: passar o nome do player que venceu
				Debug.Log ("And, by the way, he died");	
			}

		}

	}

}
