using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuEtkilesim : MonoBehaviour
{

    public GameObject etkiAlanObje = null; //etkileşim alanındaki obje
    public objeEtkilesim objeEtkilesimYazisik = null; //etkileşim alanındaki obje [yazışığı (=script)] buradaki amaç, kod içerisinde diğer yazışıklara erişim sağlamak
    public oyuncuEnvanter oyuncuEnvanterYazisik;
    public GameObject tornavidaGorunurlugu;

    void Start()
    {
        tornavidaGorunurlugu.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Etkiles") && etkiAlanObje) //etkleşim butonuna basılmış ve etki alanında bir obje varsa
        {
            if (objeEtkilesimYazisik.envantereAlinabilir)
            {
                oyuncuEnvanterYazisik.EsyaEkle(etkiAlanObje);
            }
        }
        //açılabilir bir obje mi kontrol et
        if (Input.GetButtonDown("Etkiles") && objeEtkilesimYazisik.acilabilir)
        {
            //kilitli mi kontrol et
            if (objeEtkilesimYazisik.kilitli)
            {
                //açmak için gerekli objeye oyuncu sahip mi, kontrol et
                //aranan obje için envanteri ara, bulunursa kilidi aç
                if (oyuncuEnvanterYazisik.EsyaBul(objeEtkilesimYazisik.gerekliEsya))
                {
                    //eşya bulundu, aç
                    oyuncuEnvanterYazisik.EsyaSil();
                    objeEtkilesimYazisik.kilitli = false;
                    Debug.Log(objeEtkilesimYazisik.name + " kilidi açıldı.");
                    tornavidaGorunurlugu.gameObject.SetActive(true);

                }
                else
                {
                    Debug.Log(objeEtkilesimYazisik.name + " hala kilitli.");
                }
            }
            else
            {
                //obje kilitli değil, açmaya geçebiliriz
                Debug.Log(objeEtkilesimYazisik.name + " açıldı.");
                objeEtkilesimYazisik.Ac();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D etkilesilen)
    {
        if(etkilesilen.CompareTag("etkiObje"))  //eğer etki alanındaki obje "etkileşilebilen bir obje" ise
        {
            Debug.Log(etkilesilen.name);
            etkiAlanObje = etkilesilen.gameObject; //etkileşilen objeyi "etki alanındaki obje" olarak tanımla
            objeEtkilesimYazisik = etkiAlanObje.GetComponent<objeEtkilesim>();
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
