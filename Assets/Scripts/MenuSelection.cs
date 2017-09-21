using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour {

	//para serem gravadas nas preferencias do jogador
	private readonly string player1_dmg_mult = "PLAYER_1_DMG_MULT";
	private readonly string player1_hp_mult  = "PLAYER_1_HP_MULT";
	private readonly string player2_dmg_mult = "PLAYER_2_DMG_MULT";
	private readonly string player2_hp_mult  = "PLAYER_2_HP_MULT";

	private int p1DamageMult, p1HpMult;
	private int p2DamageMult, p2HpMult;

	public int pointsP1;
	public int pointsP2;

	public Text txtDamageP1, txtHpP1;
	public Text txtDamageP2, txtHpP2;
	public Text txtPointsP1, txtPointsP2;

	public void AddDamageP1() {
		if (pointsP1 > 0) {
			p1DamageMult++;
			pointsP1--;
			NotifyChanges ();
		}
	}

	public void AddHpP1() {
		if (pointsP1 > 0) {
			p1HpMult++;
			pointsP1--;
			NotifyChanges ();
		}
	}

	public void AddDamageP2() {
		if (pointsP2 > 0) {
			p2DamageMult++;
			pointsP2--;
			NotifyChanges ();
		}
	}

	public void AddHpP2() { 
		if (pointsP2 > 0) {
			p2HpMult++;
			pointsP2--;
			NotifyChanges ();
		}
	}

	void NotifyChanges(){

		txtDamageP1.text = p1DamageMult + "";
		txtHpP1.text = p1HpMult + "";
		txtPointsP1.text = pointsP1 + "";

		txtDamageP2.text = p2DamageMult + "";
		txtHpP2.text = p2HpMult + "";
		txtPointsP2.text = pointsP2 + "";

	}

	public void StartGame(){
		//salvando preferencias
		PlayerPrefs.SetInt(player1_dmg_mult,p1DamageMult);
		PlayerPrefs.SetInt(player1_hp_mult,p1HpMult);
		PlayerPrefs.SetInt(player2_dmg_mult,p2DamageMult);
		PlayerPrefs.SetInt(player2_hp_mult,p2HpMult);

		//iniciando nova cena
		//jeito apropriado: usando o metodo LoadScene do SceneManager
		Application.LoadLevel("main_scene");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//soething in here. notice me senpai
	}
}
