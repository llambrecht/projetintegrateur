using UnityEngine;
using System.Collections;

/* 
 * Script pour le comportement des vaisseaus
 */

public class spaceshipBehaviour : MonoBehaviour{
	
    public float _speed = 10.0f; // vitesse
    public float _strafeSpeed = 10.0f; // vitesse quand vers la droite ou gauche
    private const float CAMERA_TURN_FACTOR = 10.0f; // vitesse camera avec la souris
    public GameObject _cameraPivot; // objet camera

	// Initialisation
    void Start (){
        Cursor.visible = true;
	}

    void Update (){
		
        // Mouvement souris
        float horizontalMouseInput = Input.GetAxis("Mouse X");
        float verticalMouseInput = Input.GetAxis("Mouse Y");

 		// Camera
        transform.RotateAround(transform.position, transform.up, 
			CAMERA_TURN_FACTOR * horizontalMouseInput);
        _cameraPivot.transform.RotateAround(_cameraPivot.transform.position,
            _cameraPivot.transform.right, 
            - CAMERA_TURN_FACTOR * verticalMouseInput);

        // Touche flèches du clavier
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

		// Modification position joueur
        transform.position += transform.forward * _speed * Time.deltaTime * verticalInput
                           + transform.right * _strafeSpeed * Time.deltaTime * horizontalInput;
    }
}
