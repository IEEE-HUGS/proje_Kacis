using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arayüzEtkileşim : MonoBehaviour
{
    public bool buBirHavalandırma;

    public OyunKontrol OyunKontrolYazışık;
    public oyuncuHareket oyuncuHareketYazışık;
    public oyuncuEtkileşim oyuncuEtkileşimYazisik;

    //havalandırma
    public bool havalandırmaÇalışıyor = true;
    public GameObject havalandırmaEkArayüzObjesi;
    public GameObject havalandırmaKanalıObjesi;
    public GameObject[] vidaObjeleri = new GameObject[4];
    bool[] vidaSöküldü = new bool[4];
    bool havalandırmaAçıldı = false;
    short vidaSökülmeSayacı = 0;

    public void VidaSokme(int butonSıra)
    {
        int vidaSıra = 0;
        if (oyuncuEtkileşimYazisik.tornavidaAlındı) //eğer oyuncu tornavidaya sahipse
        {
            while (vidaSıra != butonSıra) //vida sırası ve buton sırası eşitlenene kadar
            {
                vidaSıra += 1; //vidaSırasi değişkeninin değerini 1 artır.
            }
            vidaSöküldü[vidaSıra] = true; //vidaların sökülüp sökülmediği bilgisini taşıyan listedeki vidaSıra'ıncı vidanın bilgisini SÖKÜLDÜ olarak işaretle.
            UnityEngine.Debug.Log(vidaSıra + ". vida söküldü:" + vidaSöküldü[vidaSıra]);
            vidaObjeleri[vidaSıra].gameObject.SetActive(false); //sökülen vidayı görünmez kıl.
            UnityEngine.Debug.Log(vidaSıra + ". vida gizlendi.");

            vidaSökülmeSayacı += 1;
            UnityEngine.Debug.Log("Sökülen toplam vida sayısı: " + vidaSökülmeSayacı);

            if (vidaSökülmeSayacı == 4) //eğer sökülebilir 4 vida da söküldü ise
            {
                havalandırmaAçıldı = true; //havalandırmanın açıldığı bilgisini tanımla.
                UnityEngine.Debug.Log("Tüm vidalar söküldü: " + vidaSökülmeSayacı + "\nHavalandırma açıldı.");
                havalandırmaKanalıObjesi.gameObject.SetActive(true); //havalandırma kanalını görünür kıl.
            }
        }
    }

    public void HavalandırmayaGir()
    {
        if (havalandırmaÇalışıyor)
        {
            UnityEngine.Debug.Log("Soğuktan öldün.");
            OyunKontrolYazışık.soğuktanÖldün = true;
            OyunKontrolYazışık.OyunuBitir();
        }
    }

    public void ArayüzAç()
    {
        if (buBirHavalandırma)
        {
            havalandırmaEkArayüzObjesi.gameObject.SetActive(true); //arayüzü görünür kılar
            oyuncuHareketYazışık.enabled = false; //arayüzü açınca karakterin hareket etmesini engeller.
        }
    }

    public void ArayüzKapa()
    {
        if (buBirHavalandırma)
        {
            havalandırmaEkArayüzObjesi.gameObject.SetActive(false); //arayüzü görünmez kılar
            oyuncuHareketYazışık.enabled = true; //arayüzü kapatınca karakterin hareket etme yetisini geri kazandırır.
        }
    }
}