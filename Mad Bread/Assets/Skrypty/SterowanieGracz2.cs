using UnityEngine;
using System.Collections;

public class SterowanieGracz2 : MonoBehaviour {
	public float speed = 0.0f;
	public float MaxSpeed;
	public float MinSpeed;
	public float SzybkośćObrotu = 80.0f;
	public bool start = false;
	public bool naTrasie = true;

	void Start () {
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Przeszkoda") {
			if (speed > 20.0f) {
				speed = 20f;
			}
			if (speed > 0.0f) {
				speed -= 2.0f;
			}
		}
	}

	void FixedUpdate() {
		if (start == true) {
			MoveCharacter ();
			RotateCharacter ();
			SpeedoMeter ();
		}

		transform.eulerAngles= new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0); //Chleb nie może się przewrócić na boki.
	}
	//Poruszanie.
	void MoveCharacter () {
		//Kiedy gracz naciśnie strzałkę w górę.
		if (Input.GetKey (KeyCode.UpArrow))
		{
			//Przyspieszanie.
			if (speed < MaxSpeed)
			{
				speed += 0.1f;
			}
		}
		//Jeżeli gracz naciśnie strzałkę w dół.
		if (Input.GetKey (KeyCode.DownArrow))
		{
			//Przyspieszanie do tyłu.
			if (speed > MinSpeed)
			{
				speed -= 0.1f;
			}
		}
		//Jeżeli gracz nie klika ani strzałki w górę ani strzałki w dół.
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
		transform.Translate(transform.forward * speed* Time.deltaTime, Space.World);
	}
	//Obracanie gracza.
	void RotateCharacter()
	{
		if (speed >= 0.0f) {
			//Jeżeli gracz naciśnie strzałkę w prawo.
			if (Input.GetKey (KeyCode.RightArrow)) {
				//Obracanie w prawo.
				transform.Rotate (transform.up, SzybkośćObrotu * Time.deltaTime, Space.World);
			}
			//Jeżeli gracz naciśnie strzałkę w lewo.
			if (Input.GetKey (KeyCode.LeftArrow)) {
				//Obracanie w lewo.
				transform.Rotate (transform.up, -SzybkośćObrotu * Time.deltaTime, Space.World);
			}
		} 
		else { // Warunek, żeby w trakcie cofania nie obracał się w lewo, skręcając w prawo i odwrotnie. 
			//Jeżeli gracz naciśnie strzałkę w lewo.
			if (Input.GetKey (KeyCode.LeftArrow)) {
				//Obracanie w lewo.
				transform.Rotate (transform.up, SzybkośćObrotu * Time.deltaTime, Space.World);
			}
			//Jeżeli gracz naciśnie strzałkę w prawo.
			if (Input.GetKey (KeyCode.RightArrow)) {
				//Obracanie w prawo.
				transform.Rotate (transform.up, -SzybkośćObrotu * Time.deltaTime, Space.World);
			}
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
	void SpeedoMeter()
	{
		SpeedometerGracz2.ShowSpeed (speed, 0, 30);
	}
}
