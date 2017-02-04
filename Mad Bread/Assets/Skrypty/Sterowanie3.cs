using UnityEngine;
using System.Collections;

public class Sterowanie3 : MonoBehaviour {
	public static float speed = 0.0f;
	public float MaxSpeed;
	public float MinSpeed;

	void Start () {
	}

	void Update() {
		MoveCharacter();
		RotateCharacter();

		transform.eulerAngles= new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0); //Chleb nie może się przewrócić na boki.
	}
	//Poruszanie.
	void MoveCharacter () {
		//Kiedy gracz naciśnie W.
		if (Input.GetKey (KeyCode.W))
		{
			//Przyspieszanie.
			if (speed < MaxSpeed)
			{
				speed += 0.1f;
			}
		}
		//Jeżeli gracz naciśnie S.
		if (Input.GetKey (KeyCode.S))
		{
			//Przyspieszanie do tyłu.
			if (speed > MinSpeed)
			{
				speed -= 0.1f;
			}
		}
		//Jeżeli gracz nie klika ani W ani S.
		if (!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S))
		{
			//Zwalnianie.
			if (speed > 0.0f)
			{
				speed -= 0.1f;
			}
			if (speed < 0.0f){
			 speed += 0.1f;}
		}

		//Zatrzymuje zwalnianie na 0.
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
		//Jeżeli gracz naciśnie D.
		if (Input.GetKey (KeyCode.D))
		{
			//Obracanie w prawo.
			transform.Rotate (transform.up, 100.0f * Time.deltaTime, Space.World);
		}
		//Jeżeli gracz naciśnie A.
		if (Input.GetKey(KeyCode.A))
		{
			//Obracanie w lewo.
			transform.Rotate (transform.up, -100.0f * Time.deltaTime, Space.World);
		}
	}
}
