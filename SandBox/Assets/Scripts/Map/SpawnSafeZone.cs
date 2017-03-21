/* etabli la zone safe du spawn
 *  - balles des joueurs adverses ne traversent pas la zone
 *  - joueurs adverses ne peuvent traverser la zone
 *  - joueurs de l'équipe ne peuvent tirer à l'interieur de la zone
 *  - une fois sortis, les joueurs de l'équipe ne peuvent revenir dans la zone
*/

// Elisa Kalbé

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSafeZone : MonoBehaviour {

	//public int equipe; // numero de l'equipe, a definir pour chacune des zone safe dans la map

	// Lorsque le joueur sort de la zone
	private void OnTriggerExit(Collider collision){

		// On verife qu'il s'agit d'une balle
		if (collision.tag == "Bullet") {
			// on detruit la balle lorsqu'elle sort de la zone safe
			//Destroy(collision);
			Debug.Log ("Balle sort");
		}
	}

	// Lorsqu'un joueur vient dans la zone
	// Lorsqu'un joueur tire en direction de la zone
	private void OnTriggerEnter(Collider collision){

		// On verifie qu'il s'agit d'un joueur
		if (collision.tag == "Equipe1" || collision.tag == "Equipe2") {
			// il ne passe pas
			Debug.Log ("joueur entre");

		}

		// On verife qu'il s'agit d'une balle
		else if (collision.tag == "Bullet") {
			// on detruit la balle lorsqu'elle entre dans la zone safe
			//Destroy(collision);
			Debug.Log ("Balle entre");
		}
	}
}
