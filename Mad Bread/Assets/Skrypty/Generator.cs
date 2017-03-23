using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Generator : MonoBehaviour {

	public List<GameObject> segmenty;
	public int iloscSegmentow;
	public int szansaZakretu;
	public GameObject meta;

	private Quaternion rotacja = new Quaternion (0f,0f,0f,0f);
	private float polowaSeg = 50f;
	private Vector3 pozycja = new Vector3 (0, 0, 9.5f);
	private int PoM = 1;
	private int obecnaOs = 1; // 1 to z 2 to y
	private bool zakret = false;
	private Vector3 katProsty = new Vector3 (0, 0, 0);
	private int zakrety = 0;
	private int poZakrecie1 = 0;
	private int poZakrecie2 = 1;

	void Start () 
	{
		GameObject segment = Instantiate (segmenty [Random.Range (0, segmenty.Count - 1)], pozycja, rotacja) as GameObject;

		Generuj ();

	}
	public void UstawianiePozycji()
	{
		if (obecnaOs == 1)
		{
			if (PoM == 1)
			{
				pozycja.z += polowaSeg;
			}
			else 
			{
				pozycja.z -= polowaSeg;
			}
		} 
		else
		{
			if (PoM == 1)
			{
				pozycja.x += polowaSeg;
			}
			else 
			{
				pozycja.x -= polowaSeg;
			}
		}
			
	}
	public void LosowanieZakretu()
	{
		int losowanko = Random.Range (1, 100);
		if (losowanko <= szansaZakretu && poZakrecie2 > poZakrecie1-1) 
		{
			zakret = true;
			zakrety++;
			int RoL = Random.Range (1, 2);
			if (RoL == 1) { //prawo
				if (obecnaOs == 1) {
					pozycja.z -= 17.5f;
					pozycja.x += 17.5f;

					obecnaOs = 2;
				
				} else {
					pozycja.x -= 17.5f;
					pozycja.z += 17.5f;

					obecnaOs = 1;

				}
				PoM = 1;
			} else { //lewo
				if (obecnaOs == 1) {
					pozycja.z -= 17.5f;
					pozycja.x += 17.5f;


					obecnaOs = 2;

				} else {
					pozycja.x -= 17.5f;
					pozycja.z += 17.5f;

					obecnaOs = 1;
				}
				PoM = 0;
			}
				
				
		} 
		else
		{
			zakret = false;
		}


	}

	public void Generuj()
	{
		int i = 0;
		do 
		{
			UstawianiePozycji();
			LosowanieZakretu();


			GameObject segment = Instantiate (segmenty [Random.Range (0, segmenty.Count - 1)], pozycja, rotacja) as GameObject;
			if(zakret)
			{
				katProsty = new Vector3(0,katProsty.y+90f,0);
				poZakrecie1 = 0;
			}

			segment.transform.Rotate(katProsty);
			i++;
			poZakrecie1++;
			poZakrecie2++;
			if(zakrety > 1)
			{
				poZakrecie1 = 0;
				poZakrecie2 = 1;
				zakrety = 0;
			}

		}while(i < iloscSegmentow-1);

		if (i == iloscSegmentow - 1) 
		{
			UstawianiePozycji();
			LosowanieZakretu();


			GameObject segment = Instantiate (meta, pozycja, rotacja) as GameObject;
			if(zakret)
			{
				katProsty = new Vector3(0,katProsty.y+90f,0);
				poZakrecie1 = 0;
			}

			segment.transform.Rotate(katProsty);
			Debug.Log (segment.transform.localEulerAngles.y);
			Vector3 metaY = new Vector3 (0f, 180f, 0f);
			if(segment.transform.eulerAngles.y > 179f || segment.transform.eulerAngles.y < -179f)
				segment.transform.Rotate (metaY);

		}
	}
}
