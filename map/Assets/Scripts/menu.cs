/*
 * Script pour le menu du jeu
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {

	public GameObject chooseTeam; // menu pour choisir equipe
	public GameObject interfaceC; // objet interface contenant script
	public int team; // equipe choisie

	/* On ne detruit pas l'objet interface afin de recuperer la variable numEquipe
	pour savoir dans quelle equipe est le joueur */
	void Awake(){
		DontDestroyOnLoad (interfaceC);
	}
		

	/*********************************************************************
	************************* START & UPDATE *****************************
	*********************************************************************/

	void Start () {
		chooseTeam.SetActive(true);
		// pause choix equipe
		Time.timeScale=0.0f;
	}


	/*********************************************************************
	************************** FONCTIONS *********************************
	*********************************************************************/

	// Clique sur bouton equipe 1
	public void OnEquipe1Click(){
		team = 1; // numero de l'equipe
		Time.timeScale = 1.0f; // jeu commence
		Application.LoadLevel("map"); // chargement map
	}

	// Clique sur bouton equipe 2
	public void OnEquipe2Click(){
		team = 2; // numero de l'equipe
		Time.timeScale = 1.0f; // jeu commence
		Application.LoadLevel("map"); // chargement map
	}
}
