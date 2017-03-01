using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

		//teamChoosed(joueur);
		//spawn (team);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawn(int team){

		// verifie equipe
		if (team == 1) {
			MainCamera.transform.position = spawnBlue1.transform.position;
		} else {
			transform.position = spawnRed1.transform.position;
			// on rotate pour qu'il soit vers la sortie
			MainCamera.transform.Rotate(0,180,0);
		}
	}


	void teamChoosed(GameObject joueur){

		// equipe choisie
		team = player.team; 


		// on definit le tag correspondant
		if (team == 1) 
			joueur.tag = "Equipe1";
		else 
			joueur.tag = "Equipe2";
	}
}
