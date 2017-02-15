using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Script pour les actions suivants le passage d'un portail
 */

public class portalEnter : MonoBehaviour {
	public GameObject parent;

	// Lorsque le joueur passe un portail
	private void OnCollisionEnter(Collision joueur){
		if (joueur.collider.tag == "Player") {

			// ---- On change le portail de position
			// On récupère les caractéristiques du portail concerné
			parent = this.transform.parent.gameObject;
			// On modifie sa position
			parent.transform.position = Random.insideUnitSphere * 90;
			// On modifie sa rotation
			parent.transform.rotation = Random.rotationUniform;

			// ---BOOST 

		}

	}
}
