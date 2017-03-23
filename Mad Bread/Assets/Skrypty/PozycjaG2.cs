using UnityEngine;
public class PozycjaG2 : MonoBehaviour
{
    private float stara, dystans, RóżnicaIloraz, różnica, DystansStart,pochodna;
    private int i;
    private GameObject gracz2;
    void Start()
    {
        i = 1;
    }

    void Update()
    {
		if (i == 1) DystansStart = Vector3.Distance(GameObject.FindGameObjectWithTag("Gracz2").transform.position, GameObject.Find("LiniaMety").transform.position);
        i = 2;
        gracz2 = GameObject.FindGameObjectWithTag("Gracz2");
        dystans = Vector3.Distance(GameObject.Find(gracz2.name).transform.position, GameObject.Find("LiniaMety").transform.position);
        różnica = 498 * (1 - dystans / DystansStart);
        pochodna = różnica - stara;
        stara = różnica;
        transform.Translate(pochodna, 0, 0);
    }

}
