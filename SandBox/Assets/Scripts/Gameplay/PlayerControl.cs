using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	//Variable de speed
	public float Speed;
	public float SpeedMax;
	public float SpeedMin;
	public float bulletSpeed;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate(){

		//Recupere la postion de la souris 
		Vector3 MvtSouris = (Input.mousePosition - (new Vector3 (Screen.width, Screen.height, 0) / 2f));
		//Rotate suivant la position de la souris 
		transform.Rotate (new Vector3 (-MvtSouris.y, MvtSouris.x, 0) * 0.010f);
		//avance tout le temps a une vitesse donné
		transform.Translate (Vector3.forward * Time.deltaTime * Speed);

		tirer ();

	}


	void tirer()
	{
		if(Input.GetKey("Fire1"))
		{
			GameObject newBullet;
			newBullet = Instantiate(bullet);
			newBullet.transform.position = transform.position;				
			Rigidbody rb = newBullet.GetComponent<Rigidbody> ();
			rb.AddForce (transform.forward * bulletSpeed);
		}
	}
		
}
