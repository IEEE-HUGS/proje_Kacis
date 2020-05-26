using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class oyuncuEtkileşim : MonoBehaviour
{

    public bool tornavidaAlındı;
    public GameObject etkiAlanObje = null; //etkileşim alanındaki obje
    public objeEtkileşim objeEtkileşimYazışık = null; //etkileşim alanındaki obje [yazışığı (=script)] buradaki amaç, kod içerisinde diğer yazışıklara erişim sağlamak, NULL çünkü etki alanındaki objenin yazışığını buraya tanımlayacağız.
    public arayüzEtkileşim arayüzEtkileşimYazışık = null; //aynı şekilde etkileşim alanındaki obje şayet bir ek arayüze bağlıysa, bir üstteki ile aynı amaçla kullanılır.
    public oyuncuEnvanter oyuncuEnvanterYazışık;

    void Update()
    {
        if (Input.GetButtonDown("Etkiles") && etkiAlanObje) //etkileşim butonuna (e) basılmış ve etki alanında bir obje varsa
        {
            if (objeEtkileşimYazışık != null) //şayet etkileşilen obje bir "obje etkileşim yazışığına" sahipse
                if (objeEtkileşimYazışık.envantereAlınabilir) //ve eğer etkileşilen obje "envantere alınabilir" ise
                {
                    if (objeEtkileşimYazışık.elFeneri) //el feneri ise
                    {
                        objeEtkileşimYazışık.elFeneriYazışıkObjesi.gameObject.SetActive(true); //el feneri yazışığını aktive et
                    }
                    oyuncuEnvanterYazışık.EşyaEkle(etkiAlanObje); //etki alanındaki objeyi "envantere ekle"
                }
            if (arayüzEtkileşimYazışık != null) //şayet etkileşilen obje bir "arayüz etkileşim yazışığına" sahipse
            {
                UnityEngine.Debug.Log(arayüzEtkileşimYazışık.name);
                arayüzEtkileşimYazışık.ArayüzAç(arayüzEtkileşimYazışık.buBir); //arayüzEtkileşim yazışığında bulunan "ArayüzAç" fonksiyonunu çalıştır. (bu fonksiyon içerisinde tüm arayüz tiplerini barındırdığından ayrıyeten bir arayüz belirleme işlemi yapmamıza gerek yok.)
            }
        }
        if (Input.GetButtonDown("ESC") && arayüzEtkileşimYazışık != null) //eğer ESC butonuna (escape) basılmışsa
        {
            arayüzEtkileşimYazışık.ArayüzKapa(); //arayüzEtkileşim yazışığındaki "ArayüzKapa" fonksiyonunu çalıştır.
        }

        //açılabilir bir obje mi kontrol et
        if (Input.GetButtonDown("Etkiles") && objeEtkileşimYazışık.açılabilir)
        {
            //kilitli mi kontrol et
            if (objeEtkileşimYazışık.kilitli)
            {
                //açmak için gerekli objeye oyuncu sahip mi, kontrol et
                //aranan obje için envanteri ara, bulunursa kilidi aç
                if (oyuncuEnvanterYazışık.EşyaBul(objeEtkileşimYazışık.gerekliObje))
                {
                    //eşya bulundu, aç
                    oyuncuEnvanterYazışık.EşyaSil();
                    objeEtkileşimYazışık.kilitli = false;
                    UnityEngine.Debug.Log(objeEtkileşimYazışık.name + " kilidi açıldı.");
                    if (objeEtkileşimYazışık.aletÇantası) //kilidi açılan obje bir alet çantası idi ise içerisindeki "tornavidayı" görünür kıl
                    {
                        FindObjectOfType<SesKontrol>().Oynat("aletÇantasıAçma");
                        objeEtkileşimYazışık.TornavidayıGörünürKıl(); //alet çantası içindeki tornavidayı görünür kıl
                        objeEtkileşimYazışık.GörünmezKıl(); //kilidi açılan obje görünmez kıl (animasyon hazırlanana kadar bu şekilde kalabilir)
                    }
                }
                else
                {
                    UnityEngine.Debug.Log(objeEtkileşimYazışık.name + " hala kilitli.");
                }
            }
            else
            {
                //obje kilitli değil, açmaya geçebiliriz
                UnityEngine.Debug.Log(objeEtkileşimYazışık.name + " açıldı.");
                objeEtkileşimYazışık.Aç();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D etkileşilen)
    {
        if(etkileşilen.CompareTag("etkiObje"))  //eğer etki alanındaki obje "etkileşilebilen bir obje" ise
        {
            UnityEngine.Debug.Log(etkileşilen.name);
            etkiAlanObje = etkileşilen.gameObject; //etki alanındaki objeyi "etkileşilen obje" olarak tanımla
            objeEtkileşimYazışık = etkiAlanObje.GetComponent<objeEtkileşim>(); //etki alanındaki objenin "obje etkileşim" yazışığını, objeEtkileşimYazışık değişkenine tanımla (ki böylece üzerinde oynama yapabilelim.)
        }

        if(etkileşilen.CompareTag("etkiArayüz")) //eğer etki alanındaki obje "bir arayüz ile bağlantılı" ise
        {
            UnityEngine.Debug.Log(etkileşilen.name);
            etkiAlanObje = etkileşilen.gameObject;
            arayüzEtkileşimYazışık = etkiAlanObje.GetComponent<arayüzEtkileşim>();
        }

    }

    void OnTriggerExit2D(Collider2D etkileşilen) //etkileşim alanından çıkılırken
    {
        if(etkileşilen.CompareTag("etkiObje")) //eğer en son etki alanında bulunan obje "etkileşilebilen bir obje" ise
        {
            if(etkileşilen.gameObject == etkiAlanObje) //en son etki alanındaki obje, "etkileşilen obje" olarak tanımlanan obje ise
            {
                etkiAlanObje = null; //etkileşilen obje tanımlamasını sıfırla
                objeEtkileşimYazışık = null; //etkileşilen eşyanın yazışığıyla olan bağın tanımlamasını sıfırla (bağı kopar)
            }
        }

        if (etkileşilen.CompareTag("etkiArayüz"))
        {
            if(etkileşilen.gameObject == etkiAlanObje) //en son etki alanındaki obje, "etkileşilen obje" olarak tanımlanan obje ise
            {
                etkiAlanObje = null; //etkileşilen obje tanımlamasını sıfırla
                arayüzEtkileşimYazışık = null; //etkileşilen arayüzun yazışığıyla olan bağın tanımlamasını sıfırla (bağı kopar)
            }
        }
    }

}
