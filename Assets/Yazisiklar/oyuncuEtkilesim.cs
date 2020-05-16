using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class oyuncuEtkilesim : MonoBehaviour
{

    public bool tornavidaAlindi;
    public GameObject etkiAlanObje = null; //etkileşim alanındaki obje
    public objeEtkilesim objeEtkilesimYazisik = null; //etkileşim alanındaki obje [yazışığı (=script)] buradaki amaç, kod içerisinde diğer yazışıklara erişim sağlamak, NULL çünkü etki alanındaki objenin yazışığını buraya tanımlayacağız.
    public arayuzEtkilesim arayuzEtkilesimYazisik = null; //aynı şekilde etkileşim alanındaki obje şayet bir ek arayüze bağlıysa, bir üstteki ile aynı amaçla kullanılır.
    public oyuncuEnvanter oyuncuEnvanterYazisik;

    void Update()
    {
        if (Input.GetButtonDown("Etkiles") && etkiAlanObje) //etkleşim butonuna basılmış ve etki alanında bir obje varsa
        {
            if (objeEtkilesimYazisik != null)
                if (objeEtkilesimYazisik.envantereAlinabilir)
                {
                    oyuncuEnvanterYazisik.EsyaEkle(etkiAlanObje);
                }
            if (arayuzEtkilesimYazisik != null)
                if (arayuzEtkilesimYazisik.buBirArayuz)
                {
                    UnityEngine.Debug.Log(arayuzEtkilesimYazisik.name + " ile etkileşim kuruldu.");
                    arayuzEtkilesimYazisik.ArayuzAc();
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
                if (oyuncuEnvanterYazisik.EsyaBul(objeEtkilesimYazisik.gerekliObje))
                {
                    //eşya bulundu, aç
                    oyuncuEnvanterYazisik.EsyaSil();
                    objeEtkilesimYazisik.kilitli = false;
                    UnityEngine.Debug.Log(objeEtkilesimYazisik.name + " kilidi açıldı.");
                    if (objeEtkilesimYazisik.aletCantasi) //kilidi açılan obje bir alet çantası idi ise içerisindeki "tornavidayı" görünür kıl
                    {
                        objeEtkilesimYazisik.TornavidayiGorunurKil(); //alet çantası içindeki tornavidayı görünür kıl
                        objeEtkilesimYazisik.GorunmezKil(); //kilidi açılan obje görünmez kıl (animasyon hazırlanana kadar bu şekilde kalabilir)
                    }
                }
                else
                {
                    UnityEngine.Debug.Log(objeEtkilesimYazisik.name + " hala kilitli.");
                }
            }
            else
            {
                //obje kilitli değil, açmaya geçebiliriz
                UnityEngine.Debug.Log(objeEtkilesimYazisik.name + " açıldı.");
                objeEtkilesimYazisik.Ac();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D etkilesilen)
    {
        if(etkilesilen.CompareTag("etkiObje"))  //eğer etki alanındaki obje "etkileşilebilen bir obje" ise
        {
            UnityEngine.Debug.Log(etkilesilen.name);
            etkiAlanObje = etkilesilen.gameObject; //etki alanındaki objeyi "etkileşilen obje" olarak tanımla
            objeEtkilesimYazisik = etkiAlanObje.GetComponent<objeEtkilesim>(); //etki alanındaki objenin "obje etkileşim" yazışığını, objeEtkilesimYazisik değişkenine tanımla (ki böylece üzerinde oynama yapabilelim.)
        }

        if(etkilesilen.CompareTag("etkiArayuz")) //eğer etki alanındaki obje "bir arayüz ile bağlantılı" ise
        {
            UnityEngine.Debug.Log(etkilesilen.name);
            etkiAlanObje = etkilesilen.gameObject;
            arayuzEtkilesimYazisik = etkiAlanObje.GetComponent<arayuzEtkilesim>();
        }

    }

    void OnTriggerExit2D(Collider2D etkilesilen) //etkileşim alanından çıkılırken
    {
        if(etkilesilen.CompareTag("etkiObje")) //eğer en son etki alanında bulunan obje "etkileşilebilen bir obje" ise
        {
            if(etkilesilen.gameObject == etkiAlanObje) //en son etki alanındaki obje, "etkileşilen obje" olarak tanımlanan obje ise
            {
                etkiAlanObje = null; //etkileşilen obje tanımlamasını sıfırla
                objeEtkilesimYazisik = null; //etkileşilen eşyanın yazışığıyla olan bağın tanımlamasını sıfırla (bağı kopar)
            }
        }

        if (etkilesilen.CompareTag("etkiArayuz"))
        {
            if(etkilesilen.gameObject == etkiAlanObje) //en son etki alanındaki obje, "etkileşilen obje" olarak tanımlanan obje ise
            {
                etkiAlanObje = null; //etkileşilen obje tanımlamasını sıfırla
                arayuzEtkilesimYazisik = null; //etkileşilen arayuzun yazışığıyla olan bağın tanımlamasını sıfırla (bağı kopar)
            }
        }
    }

}
