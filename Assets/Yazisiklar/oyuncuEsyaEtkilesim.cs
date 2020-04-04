using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuEsyaEtkilesim : MonoBehaviour
{

    public GameObject etkiAlanEsya = null; //etkileşim alanındaki eşya
    public esyaEtkilesim etkiAlanEsyaYazisik = null; //etkileşim alanındaki eşya [yazışığı (=script)]
    public oyuncuEnvanter envanterYazisik;

    void Update()
    {
        if (Input.GetButtonDown("Etkiles") && etkiAlanEsya) //etkleşim butonuna basılmış ve etki alanında bir obje varsa
        {
            if (etkiAlanEsyaYazisik.envantereAlinabilir)
            {
                envanterYazisik.EsyaEkle(etkiAlanEsya);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D etkilesilen)
    {
        if(etkilesilen.CompareTag("etkiEsya"))  //eğer etki alanındaki obje "etkileşilebilen bir obje" ise
        {
            Debug.Log(etkilesilen.name);
            etkiAlanEsya = etkilesilen.gameObject; //etki alanındaki objeyi "etkileşilen obje" olarak tanımla
            etkiAlanEsyaYazisik = etkiAlanEsya.GetComponent<esyaEtkilesim>();
        }
    }

    void OnTriggerExit2D(Collider2D etkilesilen) //etkileşim alanından çıkılırken
    {
        if(etkilesilen.CompareTag("etkiEsya")) //eğer en son etki alanında bulunan obje "etkileşilebilen bir obje" ise
        {
            if(etkilesilen.gameObject == etkiAlanEsya) //en son etki alanındaki obje, "etkileşilen obje" olarak tanımlanan obje ise
            {
                etkiAlanEsya = null; //etkileşilen eşya tanımlamasını sıfırla
            }
        }
    }

}
