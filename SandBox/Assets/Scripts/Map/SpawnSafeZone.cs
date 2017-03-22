/* etabli la zone safe du spawn
 *  - balles des joueurs adverses ne traversent pas la zone
 *  - joueurs adverses ne peuvent traverser la zone
 *  - joueurs de l'équipe ne peuvent tirer à l'interieur de la zone
 *  - une fois sortis, les joueurs de l'équipe peuvent revenir dans la zone
*/

// Elisa Kalbé

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSafeZone : MonoBehaviour {

	public GameObject player; // joueur

	void Start(){
		GameObject player = GameObject.Find("Player"); // recupere joueur
		// collider de la safe zone ignore les joueurs de l'équipe
		Physics.IgnoreCollision(player.GetComponent<Collider>(), this.GetComponent<Collider>());
	}

	// Lorsque le joueur sort de la zone
	private void OnTriggerExit(Collider collision){

		// Attendre la modif de code de Guillaume
		// On verife qu'il s'agit d'une balle
		if (collision.tag == "Bullet") {
			// on detruit la balle lorsqu'elle sort de la zone safe
			//Destroy(collision.gameObject);
			Debug.Log ("Balle sort");
		}
	}

	// Lorsqu'un joueur vient dans la zone
	// Lorsqu'un joueur tire en direction de la zone
	private void OnTriggerEnter(Collider collision){

		// Attendre la modif de code de Guillaume
		// On verife qu'il s'agit d'une balle
		if (collision.tag == "Bullet") {
			// on detruit la balle lorsqu'elle entre dans la zone safe
			//Destroy(collision.gameObject);
			Debug.Log ("Balle entre");
		}
	}
}
