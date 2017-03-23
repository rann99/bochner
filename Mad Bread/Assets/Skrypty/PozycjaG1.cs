using UnityEngine;

public class PozycjaG1 : MonoBehaviour
{
    private float stara, dystans, RóżnicaIloraz, różnica, DystansStart,pochodna;
    private int i;
    private GameObject gracz1;
    void Start()
    {
        i = 1;
    }

    void Update()
    {
		if(i==1) DystansStart = Vector3.Distance(GameObject.FindGameObjectWithTag("Gracz1").transform.position, GameObject.Find("LiniaMety").transform.position);
        i = 2;
        gracz1 = GameObject.FindGameObjectWithTag("Gracz1");
		dystans = Vector3.Distance(GameObject.Find(gracz1.name).transform.position, GameObject.FindGameObjectWithTag("Finish").transform.position);
        różnica = 498 * (1 - dystans / DystansStart);
        pochodna = (float)różnica - (float)stara;
        stara = różnica;
        transform.Translate(pochodna, 0, 0);
    }
    
}