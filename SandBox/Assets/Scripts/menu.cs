using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void deconnexion()
	{
		player = GameObject.FindGameObjectWithTag ("Information");
		Destroy (player);
		SceneManager.LoadScene ("Connexion");
	}

	public void toinscription()
	{
		SceneManager.LoadScene ("Inscription");
		player = GameObject.FindGameObjectWithTag ("Information");
		Destroy (player);
	}

	public void toconnexion()
	{
		SceneManager.LoadScene ("Connexion");
	}

	public void toplay()
	{
		SceneManager.LoadScene ("Game");
	}

	public void tovaisseau()
	{
		SceneManager.LoadScene ("ChoixVaisseau");
	}

	public void toprofil()
	{
		SceneManager.LoadScene ("Profil");
	}

}
