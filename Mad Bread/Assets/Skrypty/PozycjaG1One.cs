using UnityEngine;

public class PozycjaG1One : MonoBehaviour
{
    private float stara, dystans, RóżnicaIloraz, różnica, DystansStart, pochodna;
    private int i;
    private GameObject gracz1;
    void Start()
    {
        i = 1;
    }

    void Update()
    {
        if (i == 1) DystansStart = Vector3.Distance(GameObject.Find("Chleb1One").transform.position, GameObject.Find("LiniaMety").transform.position);
        i = 2;
        gracz1 = GameObject.FindGameObjectWithTag("Gracz1");
        dystans = Vector3.Distance(GameObject.Find(gracz1.name).transform.position, GameObject.Find("LiniaMety").transform.position);
        różnica = 373 * (1 - dystans / DystansStart);
        pochodna = różnica - stara;
        stara = różnica;
        transform.Translate(0, pochodna, 0);
    }

}