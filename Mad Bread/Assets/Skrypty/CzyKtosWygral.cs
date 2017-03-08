using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CzyKtosWygral : MonoBehaviour {
	public bool WygralGracz1 = false;
	public bool WygralGracz2 = false;

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Gracz1") {
			WygralGracz1 = true;
		}

		if (other.gameObject.tag == "Gracz2") {
			WygralGracz2 = true;

		}
	}
}
