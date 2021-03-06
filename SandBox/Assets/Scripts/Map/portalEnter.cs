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
 * A mettre sur l'objet : Circle (enfant de l'objet portal)
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

			// On récupère les caractéristiques du portail concerné
			GameObject parent = this.transform.parent.gameObject;

			// ---- On regarde quel bonus le joueur a eu
			// INVINCIBILITE : le joueur ne peux etre touché pendant quelques secondes
			if (parent.tag == "Invincible") {
				Debug.Log ("Invincible");
				StartCoroutine (invicible());
			}

			// INVISIBILITE : le joueur ne peux etre vu pendant quelques secondes
			if (parent.tag == "Invisible") {
				StartCoroutine (invisible());
			}

			// DEGAT : le joueur fait plus de dégat pendant quelques secondes
			if (parent.tag == "Degat") {
				Debug.Log ("Degat");
				StartCoroutine (degat());
			}

			// ESPION : le joueur apparaît aux couleurs de l'équipe adversaire pendant quelques secondes
			if (parent.tag == "Espion") {
				Debug.Log ("Espion");
				StartCoroutine (espion());
			}

			// ACCELERATION : le vaisseau du joueur accelere pendant quelques secondes
			if (parent.tag == "Accelere") {
				StartCoroutine (accelere());
			}


			// ---- On change le portail de position
			// On modifie sa position
			parent.transform.position = Random.insideUnitSphere * 170; // idem que dans portalCreation ( a changer selon scale de la map)
			// On modifie sa rotation
			parent.transform.rotation = Random.rotationUniform;
		}

	}
		
	// Routine pour acceleration
	private IEnumerator accelere(){

		// demarre acceleration
		GameObject obj = GameObject.Find("Player");
		obj.GetComponent<PlayerControl> ().Speed=50; // modifie valeur vitesse

		// attend 5 secondes
		yield return new WaitForSeconds(10);

		// fini acceleration
		obj.GetComponent<PlayerControl>().Speed=15; //valeur acceleration par défault

	}

	// Routine pour invisibilité
	private IEnumerator invisible(){
		
		// demarre invisible
		GameObject obj = GameObject.Find("Player");
		obj = obj.gameObject.transform.GetChild (0).gameObject;
		Color alphaColor = obj.GetComponent<MeshRenderer>().material.color;
		obj.GetComponent<MeshRenderer> ().material.color = new Color(alphaColor.r, alphaColor.g, alphaColor.b, 0);

		// attend 5 secondes
		yield return new WaitForSeconds(10);

		// fin invisible
		obj.GetComponent<MeshRenderer> ().material.color = new Color(alphaColor.r, alphaColor.g, alphaColor.b, 255);

	}

	// Routine pour augmenter degat
	private IEnumerator degat(){

		// demarre acceleration
		Debug.Log("debut degat (manque script guillaume)");
		GameObject obj = GameObject.Find("Player");
		// modifie valeur degat

		// attend 5 secondes
		yield return new WaitForSeconds(10);

		// fini acceleration
		// remet valeur degat par défault
		Debug.Log("Fin degat");

	}

	// Routine pour mode espion
	private IEnumerator espion(){

		// demarre mode espion
		Debug.Log("debut espion (manque prefab nathan)");
		GameObject obj = GameObject.Find("MainCamera");

		// attend 5 secondes
		yield return new WaitForSeconds(10);

		// fin
		Debug.Log("Fin espion");

	}

	// Routine pour invincibilité
	private IEnumerator invincible(){

		// demarre mode espion
		Debug.Log("debut invinvible (manque code objectif de jeu (arnaud?))");
		GameObject obj = GameObject.Find("Player");

		// attend 5 secondes
		yield return new WaitForSeconds(10);

		// fin
		Debug.Log("Fin invincible");

	}
}
