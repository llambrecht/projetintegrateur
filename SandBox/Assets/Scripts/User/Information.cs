using UnityEngine;
using System.Collections;

public class Information : MonoBehaviour {

	public string joueur;
	public string lvl;
	public int id;
	public string experience;
	public int vaisseau_actif;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
