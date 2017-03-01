/* 
 * Script qui créée un certain nombre de portails à des
 * positions aléatoires comprises dans la sphère de la map
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCreation : MonoBehaviour {

	public GameObject portal; // objet portal
	public int counterP; // compteur nbr portail
	public int maxP = 15; // nbr max de portail
	public int minP = 10; // nbr min de portail
	public int nbrP; // nbr voulu


	/*********************************************************************
	************************* START & UPDATE *****************************
	*********************************************************************/

	void Start () {	

		//creation des portails
		creation ();
	}


	/*********************************************************************
	************************** FONCTIONS *********************************
	*********************************************************************/

	// creation des portails
	void creation(){
		counterP = 0;
		// nombre de portail aleatoire entre bornes min et max
		nbrP = Random.Range(minP, maxP);

		// Boucle pour la création des portails
		while( counterP <= nbrP ){
			GameObject newPortal; 
			newPortal = Instantiate(portal); 
			// Position aléatoire dans la sphere de la map (multiplier par rayon-50)
			// ex. : si la sphere à un scale de 500, son rayon est de 250
			// on multiplie donc par (250-80) = 80
			newPortal.transform.position = Random.insideUnitSphere * 170; // A CHANGER SI ON MODIFIE TAILLE LIMIT DE JEU
			// Rotation aléatoire
			newPortal.transform.rotation = Random.rotationUniform;
			counterP++;
		}
	}

}
