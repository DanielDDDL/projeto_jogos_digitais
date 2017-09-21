using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private bool isGameFinished;
	public Text endGameText;

	// Use this for initialization
	void Start () {
		isGameFinished = false;
		ClearEndingGameText();
	}

	public bool IsGameFinished(){
		return isGameFinished;
	}

	public void FinishGame(string winner) {
		isGameFinished = true;
		AddEndGameText (winner);
	}

	public void RestartGame () {
		Debug.Log ("Jogo reiniciado");

		//recarregando cena
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void InitialMenu(){

		Debug.Log ("Voltando para o menu inicial");

		//limpando os valores selecionados anteriormente
		PlayerPrefs.DeleteAll();

		//voltando para a outra cena
		SceneManager.LoadScene ("character_selection");

	}

	void AddEndGameText (string winner) {

		//sorry :(
		string text = "";
		if (winner != null) {
			text += "Vencedor: " + winner + ". ";
		}

		text += "Pressione 'R' para reiniciar a partida ou a tecla 'T' para voltar ao menu inicial.";
		SetEndingGameText (text);

	}

	void SetEndingGameText(string text){

		if (text != null) {
			endGameText.text = text;
		} else {
			ClearEndingGameText ();
		}

	}

	void ClearEndingGameText(){
		endGameText.text = "";
	}

	// Update is called once per frame
	void Update () {
		
	}
}
