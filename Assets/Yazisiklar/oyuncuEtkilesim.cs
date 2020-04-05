using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuEtkilesim : MonoBehaviour
{

    public GameObject etkiAlanObje = null; //etkileşim alanındaki obje
    public objeEtkilesim oyuncuEtkilesimYazisik = null; //etkileşim alanındaki obje [yazışığı (=script)] buradaki amaç, kod içerisinde diğer yazışıklara erişim sağlamak
    public oyuncuEnvanter oyuncuEnvanterYazisik;

    void Update()
    {
        if (Input.GetButtonDown("Etkiles") && etkiAlanObje) //etkleşim butonuna basılmış ve etki alanında bir obje varsa
        {
            if (oyuncuEtkilesimYazisik.envantereAlinabilir)
            {
                oyuncuEnvanterYazisik.EsyaEkle(etkiAlanObje);
            }
        }
        //açılabilir bir obje mi kontrol et
        if (Input.GetButtonDown("Etkiles") && oyuncuEtkilesimYazisik.acilabilir)
        {
            //kilitli mi kontrol et
            if (oyuncuEtkilesimYazisik.kilitli)
            {
                //açmak için gerekli objeye oyuncu sahip mi, kontrol et
                //aranan obje için envanteri ara, bulunursa kilidi aç
                if (oyuncuEnvanterYazisik.EsyaBul(oyuncuEtkilesimYazisik.gerekliEsya))
                {
                    //eşya bulundu, aç
                    oyuncuEnvanterYazisik.EsyaSil();
                    oyuncuEtkilesimYazisik.kilitli = false;
                    Debug.Log(oyuncuEtkilesimYazisik.name + " kilidi açıldı.");
                }
                else
                {
                    Debug.Log(oyuncuEtkilesimYazisik.name + " hala kilitli.");
                }
            }
            else
            {
                //obje kilitli değil, açmaya geçebiliriz
                Debug.Log(oyuncuEtkilesimYazisik.name + " açıldı.");
                oyuncuEtkilesimYazisik.Ac();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D etkilesilen)
    {
        if(etkilesilen.CompareTag("etkiObje"))  //eğer etki alanındaki obje "etkileşilebilen bir obje" ise
        {
            Debug.Log(etkilesilen.name);
            etkiAlanObje = etkilesilen.gameObject; //etkileşilen objeyi "etki alanındaki obje" olarak tanımla
            oyuncuEtkilesimYazisik = etkiAlanObje.GetComponent<objeEtkilesim>();
        }
    }

    void OnTriggerExit2D(Collider2D etkilesilen) //etkileşim alanından çıkılırken
    {
        if(etkilesilen.CompareTag("etkiObje")) //eğer en son etki alanında bulunan obje "etkileşilebilen bir obje" ise
        {
            if(etkilesilen.gameObject == etkiAlanObje) //en son etki alanındaki obje, "etkileşilen obje" olarak tanımlanan obje ise
            {
                etkiAlanObje = null; //etkileşilen eşya tanımlamasını sıfırla
            }
        }
    }

}
