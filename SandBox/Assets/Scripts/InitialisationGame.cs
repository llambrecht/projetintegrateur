﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Elisa Kalbé & Nathan Urbain

public class InitialisationGame : MonoBehaviour {

	private Information player;
	private int team;
	private GameObject MainCamera;

	// point de spawn equipe bleue
	public GameObject spawnBlue1; 
	public GameObject spawnBlue2;
	public GameObject spawnBlue3;

	// point de spawn equipe rouge
	public GameObject spawnRed1;
	public GameObject spawnRed2;
	public GameObject spawnRed3;

	// Use this for initialization
	void Start () {

		MainCamera = GameObject.FindGameObjectWithTag ("MainCamera");

		//Recup info player 
		player = GameObject.FindGameObjectWithTag("Information").GetComponent<Information>();

		//Creation Vaisseau depuis dossier ressources 
		GameObject joueur = Instantiate (Resources.Load(player.model)) as GameObject;
		joueur.name = "Player";
		joueur.transform.position = new Vector3(8.47f , 0f, -10f);
		joueur.GetComponent<PlayerControl>().bullet = GameObject.FindGameObjectWithTag ("Bullet");

		setTag(joueur);
		spawn (team, joueur);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawn(int team, GameObject joueur){

		// verifie equipe
		if (team == 1) {
			joueur.transform.position = spawnBlue1.transform.position;
			// on rotate pour qu'il soit vers la sortie
			joueur.transform.Rotate(0,90,0);
		} else {
			joueur.transform.position = spawnRed1.transform.position;
			joueur.transform.Rotate(0,-90,0);
		}
	}


	void setTag(GameObject joueur){

		// equipe choisie
		team = player.team; 


		// on definit le tag correspondant
		if (team == 1) 
			joueur.tag = "Equipe1";
		else 
			joueur.tag = "Equipe2";
	}
}