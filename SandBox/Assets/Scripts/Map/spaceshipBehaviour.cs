/* 
 * Script pour le comportement des vaisseaux
 */

// by Elisa Kalbé

using UnityEngine;
using System.Collections;

public class spaceshipSpawn : MonoBehaviour{

	private int team;
	private Information player;


	// point de spawn equipe bleue
	public GameObject spawnBlue1; 
	public GameObject spawnBlue2;
	public GameObject spawnBlue3;

	// point de spawn equipe rouge
	public GameObject spawnRed1;
	public GameObject spawnRed2;
	public GameObject spawnRed3;



	/*********************************************************************
	************************* START & UPDATE *****************************
	*********************************************************************/
  
	void Start (){

		// On recupere l'equipe choisie
		teamChoosed();

		// Place joueur selon son équipe
		/* Il y a une zone safe sur la map pour chaque équipe, 
		 * chaque zone dispose de 2 points de spawn, les joueurs apparaîssent
		 * alternativement sur l'un puis sur l'autre.
		 * Les points de spawn sont matérialisés sur la map par des EmptyObject */
		/* pour l'instant le joueur apparait sur le spawn 1, a voir en mulitijoueur pour 
		alterne le point de spawn */
		spawn (team);

		// curseur visible
        Cursor.visible = true;
	}
		
    void Update (){

		// mouvements camera et joueur (en attendant)
		//moovePlayerCamera ();
	}



	/*********************************************************************
	************************** FONCTIONS *********************************
	*********************************************************************/

	// Pour savoir quelle equipe a été choisie
	void teamChoosed(){

		// on recupere objet interface sur lequel est placé le script "menu"
		// qui contient la variable indiquant l'équie
		player = GameObject.FindGameObjectWithTag("Information").GetComponent<Information>();

		// equipe choisie
		team = player.team; 


		// on definit le tag correspondant
		if (team == 1) 
			this.tag = "Equipe1";
		else 
			this.tag = "Equipe2";
	}

	// En attendant pour tester
	// Mouvements joueur et camera
	/*
	void moovePlayerCamera(){
		
		// Mouvement souris
		float horizontalMouseInput = Input.GetAxis("Mouse X");
		float verticalMouseInput = Input.GetAxis("Mouse Y");

		// Camera
		transform.RotateAround(transform.position, transform.up, 
			CAMERA_TURN_FACTOR * horizontalMouseInput);
		_cameraPivot.transform.RotateAround(_cameraPivot.transform.position,
			_cameraPivot.transform.right, 
			- CAMERA_TURN_FACTOR * verticalMouseInput);

		// Touche flèches du clavier
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		// Modification position joueur
		transform.position += transform.forward * _speed * Time.deltaTime * verticalInput
			+ transform.right * _strafeSpeed * Time.deltaTime * horizontalInput;
	}
	*/

	// pour que le joueur spawn dans la zone safe selon son equipe
	void spawn(int team){

		// verifie equipe
		if (team == 1) {
			transform.position = spawnBlue1.transform.position;
		} else {
			transform.position = spawnRed1.transform.position;
			// on rotate pour qu'il soit vers la sortie
			transform.Rotate(0,180,0);
		}
	}

}
