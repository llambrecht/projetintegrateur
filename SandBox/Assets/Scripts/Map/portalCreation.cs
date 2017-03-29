/* 
 * Elisa Kalbé
 * portalCreation.cs
 * 
 * Script qui créée un certain nombre de portail à des
 * positions aléatoires comprises dans la sphère de la map.
 * 
 * Dans la scene Game
 * A mettre sur l'objet : CreationMap
 * 
 * Paramètre :
 * 		- Portal : portal
 * 			model du portail
 * 		- CounterP : 0
 * 			nombre de portails present dans la scène
 * 		- MaxP : 30
 * 			nombre maximum de portails (défini en fonction de la taille de la map
 * 			ici le scale de la map et de 500)
 * 		- MinP : 20
 * 			nombre minimum de portails (défini en fonction de la taille de la map)
 * 		- NbrP : 0
 * 			nombre de portail a cloner ( entre minP et maxP )
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class portalCreation : MonoBehaviour {

	public GameObject portal; // objet portal
	public int counterP; // compteur nbr portail
	public int maxP = 30; // nbr max de portail
	public int minP = 20; // nbr min de portail
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
			// on multiplie donc par (250-80) = 170
			newPortal.transform.position = Random.insideUnitSphere * 170; // A CHANGER SI ON MODIFIE TAILLE LIMITe DE JEU
			// Rotation aléatoire
			newPortal.transform.rotation = Random.rotationUniform;
			counterP++;
		}
	}

}
