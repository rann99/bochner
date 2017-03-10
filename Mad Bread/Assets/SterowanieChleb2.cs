using UnityEngine;
using System.Collections;

public class SterowanieChleb2 : MonoBehaviour {
	public float speed = 0.0f;
	public float MaxSpeed;
	public float MinSpeed;
	public float SzybkośćObrotu = 80.0f;
	public bool start = false;
	public bool naTrasie = true;

	void Start () {

	}

	void Update() {
		if (start == true) {
			MoveCharacter ();
			RotateCharacter ();
		}

		transform.eulerAngles= new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0); //Chleb nie może się przewrócić na boki.
	}

	void MoveCharacter () {
		
		if (Input.GetKey (KeyCode.UpArrow))
		{
			//Przyspieszanie.
			if (speed < MaxSpeed)
			{
				speed += 0.1f;
			}
		}

		if (Input.GetKey (KeyCode.DownArrow))
		{
			//Przyspieszanie do tyłu.
			if (speed > MinSpeed)
			{
				speed -= 0.1f;
			}
		}

		if (!Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow))
		{
			//Zwalnianie.
			if (speed > 0.0f)
			{
				speed -= 0.1f;
			}
			if (speed < 0.0f){
				speed += 0.1f;}
		}

		//Zatrzymuje prędkość na 0 przy zwalnianiu.
		if (speed > -0.05f && speed < 0.05f)
		{
			speed = 0.0f;
		}
		//Porusza gracza do przodu.
		transform.Translate(transform.up * -speed* Time.deltaTime, Space.World);
	}
	//Obracanie gracza.
	void RotateCharacter()
	{

		if (Input.GetKey (KeyCode.RightArrow))
		{
			//Obracanie w prawo.
			transform.Rotate (transform.forward, SzybkośćObrotu * Time.deltaTime, Space.World);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			//Obracanie w lewo.
			transform.Rotate (transform.forward, -SzybkośćObrotu * Time.deltaTime, Space.World);
		}
	}

	void OnTriggerExit(Collider other)
	{

		if (other.tag == "Trasa")
			naTrasie = false;
	}

	void OnTriggerStay(Collider other)
	{

		if (other.tag == "Trasa")
			naTrasie = true;
	}
}