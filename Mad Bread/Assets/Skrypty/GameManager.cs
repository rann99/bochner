using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public GameObject chleb;

	private Vector3 offset;

	private GameObject chleb_n;
	private Quaternion rotacja_start = new Quaternion (0f, 0f, 0f, 0f);
	private Quaternion rotacja = new Quaternion (0f, 0f, 0f, 0f);
	private Vector3 pozycja_start = new Vector3 (32f, 1.31f, -21f);
	private Vector3 pozycja = new Vector3 ();
	//Quaternion rotacjaKamery = new Quaternion ();





	private int i = 0;
	void Start ()
	{
		
		pozycja = pozycja_start;
		chleb = Instantiate (chleb, pozycja_start, rotacja) as GameObject;
		Camera.target = chleb.transform;

	
	//	Destroy (camera);
	//	offset = pozycja - camera.transform.position;
	//	rotacjaKamery = chleb.transform.rotation;

	//	offset = camera.transform.position - chleb.transform.position;

	}
	

	void Update ()
	{

		GetPosition ();

		if (chleb.transform.position.y < -3)
		{			
			ResetChleba ();
		}	
			
		if(Input.GetKey (KeyCode.R))
		{
			pozycja = pozycja_start;
			rotacja = rotacja_start;
			ResetChleba();
		}
				
	}
		
	void ResetChleba()
	{
		chleb_n = Instantiate (chleb, pozycja, rotacja) as GameObject;
		Sterowanie3.speed = 0f;
		Destroy (chleb);
		chleb = chleb_n;
		Camera.target = chleb.transform;
		i = 0;
	}
		
	public void GetPosition ()
	{
		i++;
		if (i > 200 && chleb.transform.position.y > 1f) 
		{
			pozycja = new Vector3 (chleb.transform.position.x, 1.3f, chleb.transform.position.z);
			rotacja = new Quaternion (0f, chleb.transform.rotation.y, 0f, 0f);
			i = 0;
		}

	}
}
