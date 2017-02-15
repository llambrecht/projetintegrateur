using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* 
 * Script pour indiquer au joueur de faire demi tour lorsqu'il
 * sort de la map. La scène se recharge au bout de 5 secondes si
 * le joueur est toujours en dehors de la map.
 */

public class limitsMap : MonoBehaviour {

	public GameObject messOut; // message pour dire au joueur de faire demi tour
	public int playerOut = 0;

	// Initialisation
	void Start () {
		messOut.SetActive (false);
	}

	// Lorsque le joueur sort de la map
	private void OnTriggerExit(Collider collision){
		if (collision.tag == "Player") {
			messOut.SetActive (true);
			StartCoroutine(outOfMap());
			playerOut = -1;
		}
	}

	// Lorsque le joueur revient dans la map
	private void OnTriggerEnter(Collider collision){
		if (collision.tag == "Player") {
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
