using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arayuzEtkilesim : MonoBehaviour
{
    public OyunKontrol OyunKontrolYazisik;
    public oyuncuHareket oyuncuHareketYazisik;
    public oyuncuEtkilesim oyuncuEtkilesimYazisik;

    //havalandırma
    public GameObject havalandirmaEkArayuzObjesi;
    public GameObject havalandirmaKanaliObjesi;
    public GameObject[] vidaObjeleri = new GameObject[4];
    bool[] vidaSokuldu = new bool[4];
    bool havalandirmaAcildi = false;
    short vidaSokulmeSayaci = 0;
    public bool havalandirma;
    public bool havalandirmaCalisiyor = true;


    public void VidaSokme(int butonSira)
    {
        int vidaSira = 0;
        if (oyuncuEtkilesimYazisik.tornavidaAlindi) //eğer oyuncu tornavidaya sahipse
        {
            while (vidaSira != butonSira) //vida sırası ve buton sırası eşitlenene kadar
            {
                vidaSira += 1; //vidaSirasi değişkeninin değerini 1 artır.
            }
            vidaSokuldu[vidaSira] = true; //vidaların sökülüp sökülmediği bilgisini taşıyan listedeki vidaSira'ıncı vidanın bilgisini SÖKÜLDÜ olarak işaretle.
            UnityEngine.Debug.Log(vidaSira + ". vida söküldü:" + vidaSokuldu[vidaSira]);
            vidaObjeleri[vidaSira].gameObject.SetActive(false); //sökülen vidayı görünmez kıl.
            UnityEngine.Debug.Log(vidaSira + ". vida gizlendi.");

            vidaSokulmeSayaci += 1;
            UnityEngine.Debug.Log("Sökülen toplam vida sayısı: " + vidaSokulmeSayaci);

            if (vidaSokulmeSayaci == 4) //eğer sökülebilir 4 vida da söküldü ise
            {
                havalandirmaAcildi = true; //havalandırmanın açıldığı bilgisini tanımla.
                UnityEngine.Debug.Log("Tüm vidalar söküldü: " + vidaSokulmeSayaci + "\nHavalandırma açıldı.");
                havalandirmaKanaliObjesi.gameObject.SetActive(true); //havalandırma kanalını görünür kıl.
            }
        }
    }

    public void HavalandirmayaGir()
    {
        if (havalandirmaCalisiyor)
        {
            UnityEngine.Debug.Log("Soğuktan öldün.");
            OyunKontrolYazisik.soguktanOldun = true;
            OyunKontrolYazisik.OyunuBitir();
        }
    }

    public void ArayuzAc()
    {
        if (havalandirma)
        {
            havalandirmaEkArayuzObjesi.gameObject.SetActive(true); //arayüzü görünür kılar
            oyuncuHareketYazisik.enabled = false; //arayüzü açınca karakterin hareket etmesini engeller.
        }
    }

    public void ArayuzKapa()
    {
        if (havalandirma)
        {
            havalandirmaEkArayuzObjesi.gameObject.SetActive(false); //arayüzü görünmez kılar
            oyuncuHareketYazisik.enabled = true; //arayüzü kapatınca karakterin hareket etme yetisini geri kazandırır.
        }
    }


}