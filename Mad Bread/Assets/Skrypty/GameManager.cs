using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GUIText WyścigStart;
	public GUIText Meta;


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
		gracz1 = GameObject.Find (gracz1p.name);
		gracz2 = GameObject.Find (gracz2p.name);
	}

	void Start(){
		StartCoroutine (Odliczanie ());

	}

	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene ("Generator");
		}
		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene ("Menu");
		}

		if(GameObject.Find ("LiniaMety").GetComponent<CzyKtosWygral> ().WygralGracz1 == true){
			Meta.text = "Wygrał gracz 1!";
			gracz1.GetComponent<SterowanieGracz1> ().start = false;
			gracz2.GetComponent<SterowanieGracz2> ().start = false;
		}
		if(GameObject.Find ("LiniaMety").GetComponent<CzyKtosWygral> ().WygralGracz2 == true){
			Meta.text = "Wygrał gracz 2!";
			gracz1.GetComponent<SterowanieGracz1> ().start = false;
			gracz2.GetComponent<SterowanieGracz2> ().start = false;
		}

		StartCoroutine (UstawPozycje ());

		if (gracz1.transform.position.y < -3f)
			Resp (gracz1,1);
		if (gracz2.transform.position.y < -3f)
			Resp (gracz2,2);
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
		WyścigStart.text = "";
		gracz1.GetComponent<SterowanieGracz1> ().start = true;
		gracz2.GetComponent<SterowanieGracz2> ().start = true;

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
