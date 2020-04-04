using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuEtkilesim : MonoBehaviour
{

    public GameObject etkiAlanObje = null; //etkileşim alanındaki obje
    public esyaEtkilesim etkiAlanObjeYazisik = null; //etkileşim alanındaki obje [yazışığı (=script)]
    public oyuncuEnvanter envanterYazisik;

    void Update()
    {
        if (Input.GetButtonDown("Etkiles") && etkiAlanObje) //etkleşim butonuna basılmış ve etki alanında bir obje varsa
        {
            if (etkiAlanObjeYazisik.envantereAlinabilir)
            {
                envanterYazisik.EsyaEkle(etkiAlanObje);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D etkilesilen)
    {
        if(etkilesilen.CompareTag("etkiObje"))  //eğer etki alanındaki obje "etkileşilebilen bir obje" ise
        {
            Debug.Log(etkilesilen.name);
            etkiAlanObje = etkilesilen.gameObject; //etki alanındaki objeyi "etkileşilen obje" olarak tanımla
            etkiAlanObjeYazisik = etkiAlanObje.GetComponent<esyaEtkilesim>();
        }
    }

    void OnTriggerExit2D(Collider2D etkilesilen) //etkileşim alanından çıkılırken
    {
        if(etkilesilen.CompareTag("etkiObje")) //eğer en son etki alanında bulunan obje "etkileşilebilen bir obje" ise
        {
            if(etkilesilen.gameObject == etkiAlanObje) //en son etki alanındaki obje, "etkileşilen obje" olarak tanımlanan obje ise
            {
                etkiAlanObje = null; //etkileşilen obje tanımlamasını sıfırla
            }
        }
    }

}
