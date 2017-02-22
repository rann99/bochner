using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GUIText WyścigStart;

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
}
