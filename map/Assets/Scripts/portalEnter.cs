/* 
 * Script pour les actions suivants le passage d'un portail
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalEnter : MonoBehaviour {
	public GameObject parent; // parent du portal ( comprend tous les éléments formant le portail)


	/*********************************************************************
	************************** FONCTIONS *********************************
	*********************************************************************/

	// Lorsque le joueur passe un portail
	private void OnCollisionEnter(Collision joueur){

		// on verifie qu'il s'agit d'un joueur
		if (joueur.collider.tag == "Player" || joueur.collider.tag == "Equipe1" || joueur.collider.tag == "Equipe2") {

			// ---- On change le portail de position
			// On récupère les caractéristiques du portail concerné
			parent = this.transform.parent.gameObject;
			// On modifie sa position
			parent.transform.position = Random.insideUnitSphere * 90;
			// On modifie sa rotation
			parent.transform.rotation = Random.rotationUniform;
		}

	}
}
