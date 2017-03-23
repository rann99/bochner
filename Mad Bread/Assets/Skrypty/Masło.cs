using UnityEngine;
using System.Collections;

public class Masło : MonoBehaviour {
	public float wait = 3.0f;


	void Update () 
	{
		transform.Rotate (new Vector3 (15, 30, 0.0f) * Time.deltaTime);
	}
		
	IEnumerator Boost(){
		GameObject Gracz1 = GameObject.Find ("Gracz1");
		SterowanieGracz1 sterowanie1 = Gracz1.GetComponent<SterowanieGracz1> ();
		sterowanie1.MaxSpeed = 45.0f;
		sterowanie1.speed = 45.0f;
		yield return new WaitForSeconds (wait);
		sterowanie1.MaxSpeed = 30.0f;
		if (sterowanie1.speed > sterowanie1.MaxSpeed) {
			sterowanie1.speed = sterowanie1.MaxSpeed;
		}
	}

	IEnumerator Boost2(){
		GameObject Gracz2 = GameObject.Find ("Gracz2");
		SterowanieGracz2 sterowanie2 = Gracz2.GetComponent<SterowanieGracz2> ();
		sterowanie2.MaxSpeed = 45.0f;
		sterowanie2.speed = 45.0f;
		yield return new WaitForSeconds (wait);
		sterowanie2.MaxSpeed = 30.0f;
		if (sterowanie2.speed > sterowanie2.MaxSpeed) {
			sterowanie2.speed = sterowanie2.MaxSpeed;
		}
	}
		
	IEnumerator OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Gracz1")
		{
			StartCoroutine (Boost ());
			gameObject.transform.localPosition = new Vector3 (transform.position.x, -100, transform.position.z);
			gameObject.transform.localScale = new Vector3 (0, 0, 0);
			yield return new WaitForSeconds (wait);
			Destroy (gameObject);
		}

		if (other.gameObject.tag == "Gracz2")
		{
			StartCoroutine (Boost2 ());
			gameObject.transform.localPosition = new Vector3 (transform.position.x, -100, transform.position.z);
			gameObject.transform.localScale = new Vector3 (0, 0, 0);
			yield return new WaitForSeconds (wait);
			Destroy (gameObject);
		}
	}
}

