﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GUIText WyścigStart;
	public GameObject gracz1p;
	public GameObject gracz2p;

	private GameObject gracz1;
	private GameObject gracz2;
	private Vector3 pozycja1 = new Vector3 (16f,1.3f,-21f);
	private Vector3 pozycja2 = new Vector3 (25f,1.3f,-21f);
	private Quaternion rotacja1 = new Quaternion (0, 0, 0, 0);
	private Quaternion rotacja2 = new Quaternion (0, 0, 0, 0);

	void Awake()
	{
		gracz1 = GameObject.Find ("Gracz1");
		gracz2 = GameObject.Find ("Gracz2");
	}
	void Start(){
		StartCoroutine (Odliczanie ());
	}

	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}

		StartCoroutine (UstawPozycje ());

		if (gracz1.transform.position.y < -3f)
			Respawn (gracz1,1);
		if (gracz2.transform.position.y < -3f)
			Respawn (gracz2,2);

	}

	IEnumerator Odliczanie(){
		yield return new WaitForSeconds(1);
		WyścigStart.text = "3";
		yield return new WaitForSeconds(1);
		WyścigStart.text = "2";
		yield return new WaitForSeconds(1);
		WyścigStart.text = "1";
		yield return new WaitForSeconds(1);
		WyścigStart.text = "START!";
		yield return new WaitForSeconds(0.5f);
		GameObject.Find ("Gracz1").GetComponent<SterowanieGracz1> ().start = true;
		GameObject.Find ("Gracz2").GetComponent<SterowanieGracz2> ().start = true;
		WyścigStart.text = "";
	}
		

	IEnumerator UstawPozycje()
	{
		if (gracz1.transform.position.y > 1.2f && gracz1.GetComponent<SterowanieGracz1>().naTrasie) 
		{
			pozycja1 = new Vector3 (gracz1.transform.position.x,1.4f,gracz1.transform.position.z);

			rotacja1 = gracz1.transform.rotation;
		}
		if (gracz2.transform.position.y > 1.2f && gracz2.GetComponent<SterowanieGracz2>().naTrasie) 
		{
			pozycja2 = new Vector3 (gracz2.transform.position.x,1.4f,gracz2.transform.position.z);

			rotacja2 = gracz2.transform.rotation;
		}



		yield return new WaitForSeconds (2);

	}

	void Respawn(GameObject gracz, int n)
	{
		Destroy (gracz);
		if (n == 1) 
		{
			gracz1 = Instantiate (gracz1p, pozycja1, rotacja1);
			gracz1.GetComponent<SterowanieGracz1> ().start = true;

		}
		if (n == 2)
		{
			gracz2 = Instantiate (gracz2p, pozycja2, rotacja2);
			gracz2.GetComponent<SterowanieGracz2> ().start = true;
		}

	}
		

}
