using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public GameObject gracz1p;
	public GameObject gracz2p;

	private GameObject gracz1;
	private GameObject gracz2;
	private Vector3 pozycja1 = new Vector3 (16f,1.3f,-21f);
	private Vector3 pozycja2 = new Vector3 (25f,1.3f,-21f);
	private Quaternion rotacja1 = new Quaternion (0, 0, 0, 0);
	private Quaternion rotacja2 = new Quaternion (0, 0, 0, 0);
	// Use this for initialization
	void Start () {
		gracz1 = GameObject.Find ("Gracz1");
		gracz2 = GameObject.Find ("Gracz2");
	}
	
	// Update is called once per frame
	void Update () {
		
		StartCoroutine (UstawPozycje ());

		if (gracz1.transform.position.y < -3f)
			Resp (gracz1,1);
		if (gracz2.transform.position.y < -3f)
			Resp (gracz2,2);
	
	}


	IEnumerator UstawPozycje()
	{
		if (gracz1.GetComponent<SterowanieGracz1>().naTrasie) 
		{
			pozycja1 = new Vector3 (gracz1.transform.position.x,2f,gracz1.transform.position.z);

			rotacja1 = gracz1.transform.rotation;
		}
		if (gracz2.GetComponent<SterowanieGracz2>().naTrasie) 
		{
			pozycja2 = new Vector3 (gracz2.transform.position.x,2f,gracz2.transform.position.z);

			rotacja2 = gracz2.transform.rotation;
		}

		yield return new WaitForSeconds (2);

	}


	void Resp(GameObject gracz, int n)
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



