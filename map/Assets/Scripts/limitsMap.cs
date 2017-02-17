/* 
 * Script pour indiquer au joueur de faire demi tour lorsqu'il
 * sort de la map. La scène se recharge au bout de 5 secondes si
 * le joueur est toujours en dehors de la map.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class limitsMap : MonoBehaviour {

	public GameObject messOut; // message pour dire au joueur de faire demi tour
	public int playerOut = 0; // verifier si le joueur est dehors


	/*********************************************************************
	************************* START & UPDATE *****************************
	*********************************************************************/

	void Start () {
		messOut.SetActive (false);
	}


	/*********************************************************************
	************************** FONCTIONS *********************************
	*********************************************************************/

	// Lorsque le joueur sort de la map
	private void OnTriggerExit(Collider collision){

		// On verifie qu'il s'agit du joueur
		if (collision.tag == "Player" || collision.tag == "Equipe1" || collision.tag == "Equipe2") {
			messOut.SetActive (true); // affiche message
			// routine pour afficher message quitte partie au bout de 5 sec
			StartCoroutine(outOfMap()); 
			playerOut = -1;
		}
	}

	// Lorsque le joueur revient dans la map
	private void OnTriggerEnter(Collider collision){
		if (collision.tag == "Player" || collision.tag == "Equipe1" || collision.tag == "Equipe2") {
			messOut.SetActive (false);
			playerOut = 0;
		}
	}

	// Recharge la scene au bout de 5 secondes
	private IEnumerator outOfMap(){
		// attend 5 secondes
		yield return new WaitForSeconds(5);

		// si le joueur est toujours dehors
		if(playerOut == -1){
			// recharge la scene
			Application.LoadLevel("map");
		}
	}
}
