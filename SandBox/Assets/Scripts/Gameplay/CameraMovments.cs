﻿using UnityEngine;
using System.Collections;

public class CameraMovments : MonoBehaviour {

	//variable pour camera 
	public Ray viewligne;
	public Vector2 SourisPos;


	//Variable de player 
	private Transform _transformplayer;
	private GameObject _player;
	private Vector3 _vaisseaupos;

	//Variable de marge de deplacement
	public float hauteur = 3f;
	public float distance = 50f;
	public float marge = 15f;


	// Use this for initialization
	void Start () {

		//Recherche de joueur 
		_player = GameObject.FindGameObjectWithTag ("Player");
		_transformplayer = _player.transform;

	}
	
	// Update is called once per frame
	//Effectue une ligne entre la position de la souris et le centre de la camera 
	void Update () {
		viewligne = Camera.main.ScreenPointToRay (SourisPos);
	}

	void LateUpdate(){
		SmoothFollow ();
	}

	void SmoothFollow(){
	//Le joueur suit le curseur avec delai

		//Position du vaisseau par rapport a la camera suivant les valeurs données 
		_vaisseaupos = _transformplayer.TransformPoint(0, hauteur , -distance);

		//Position camera 
		transform.position = Vector3.Lerp (transform.position, _vaisseaupos, Time.deltaTime * marge);

		//Rotation suivant la direction de devant (positon actuelle - inital) et d'au dessus (la position actuelle)
		Quaternion _vaisseaurotat = Quaternion.LookRotation(_transformplayer.position -  _vaisseaupos , _transformplayer.up);

		//Rotation camera 
		transform.rotation = Quaternion.Slerp(transform.rotation, _vaisseaurotat , Time.deltaTime * marge);

		transform.LookAt (_transformplayer, _transformplayer.up);

		}
}
