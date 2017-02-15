using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Script qui créée un certain nombre de portails à des
 * positions aléatoires comprises dans la sphère de la map
 */

public class portalCreation : MonoBehaviour {

	public GameObject portal; // objet portal
	public int counterP; 
	public int maxP = 15; // nbr max de portail
	public int minP = 10; // nbr min de portail
	public int nbrP; 

	// Initialisation
	void Start () {	
		
		counterP = 0;
		// nombre de portail aleatoire entre bornes min et max
		nbrP = Random.Range(minP, maxP);

		// Boucle pour la création des portails
		while( counterP <= nbrP ){
			GameObject newPortal; 
			newPortal = Instantiate(portal); 
			// Position aléatoire dans la sphere de la map (multiplier par rayon-10)
			// ex. : si la sphere à un scale de 200, son rayon est de 100
			// on multiplie donc par (100-10) = 90
			newPortal.transform.position = Random.insideUnitSphere * 90;
			// Rotation aléatoire
			newPortal.transform.rotation = Random.rotationUniform;
			counterP++;
		}
	}
}
