/*
 * Elisa Kalbé
 * menuTeam.cs
 * 
 * Script pour le menu du choix de l'équipe
 * 
 * Dans scène ChoixEquipe
 * A mettre sur l'objet : EventSystem
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuTeam : MonoBehaviour {

	private int team; // equipe choisie
		

	/*********************************************************************
	************************* START & UPDATE *****************************
	*********************************************************************/

	void Start () {

		team = GameObject.FindGameObjectWithTag ("Information").GetComponent<Information>().team;
	}


	/*********************************************************************
	************************** FONCTIONS *********************************
	*********************************************************************/

	// Clique sur bouton equipe 1
	public void OnEquipe1Click(){
		GameObject.FindGameObjectWithTag ("Information").GetComponent<Information>().team = 1; // numero de l'equipe
		SceneManager.LoadScene("Game"); // chargement map
	}

	// Clique sur bouton equipe 2
	public void OnEquipe2Click(){
		GameObject.FindGameObjectWithTag ("Information").GetComponent<Information>().team=  2; // numero de l'equipe
		SceneManager.LoadScene("Game"); // chargement map
	}
}
