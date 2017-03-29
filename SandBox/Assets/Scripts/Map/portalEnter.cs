/* 
 * Elisa Kalbé
 * portalEnter.cs
 * 
 * Script pour les actions suivants le passage d'un portail
 * Lorsqu'on passe dans un portail, il disparaît et réapparait 
 * aléatoirement dans la map.
 * A ajouter : boost
 * 
 * Dans la scene Game
 * A mettre sur l'objet : Circle (enfant de l'objet porta)
 *  
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalEnter : MonoBehaviour {


	/*********************************************************************
	************************** FONCTIONS *********************************
	*********************************************************************/

	// Lorsque le joueur passe un portail
	private void OnCollisionEnter(Collision joueur){

		// on verifie qu'il s'agit d'un joueur
		if (joueur.collider.tag == "Player" || joueur.collider.tag == "Equipe1" || joueur.collider.tag == "Equipe2") {

			// ---- On change le portail de position
			// On récupère les caractéristiques du portail concerné
			GameObject parent = this.transform.parent.gameObject;
			// On modifie sa position
			parent.transform.position = Random.insideUnitSphere * 170; // idem que dans portalCreation ( a changer selon scale de la map)
			// On modifie sa rotation
			parent.transform.rotation = Random.rotationUniform;
		}

	}
}
