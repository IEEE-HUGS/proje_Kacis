using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class arayüzEtkileşim : MonoBehaviour
{
    public bool[] buBir = new bool[3]; // 0 -> Havalandırma; 1 -> Bilgisayar; 2 -> Şalter

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

    //bilgisayar
    public string bilgisayarınŞifresi;
    public GameObject bilgisayarEkArayüzObjesi;
    public GameObject bilgisayarObjesi; //bilgisayar ekranının objesi. bu sayede arayüze erişim, oyuncu etkileşimi sağlanacak.
    public GameObject şifreGirmeObjesi;
    public GameObject seçeneklerObjesi;

    public void ŞifreKontrol()
    {
        Debug.Log("Şifre Kontrol fonksiyonuna yönlendirme yapıldı.");
        string girdi;
        girdi = şifreGirmeObjesi.GetComponent<InputField>().text;
        if (girdi == bilgisayarınŞifresi) 
        {
            şifreGirmeObjesi.gameObject.SetActive(false);
            seçeneklerObjesi.gameObject.SetActive(true);
        }
    }

    public void HavalandırmayıKapat()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false; //en son etkileşime geçilen objenin Buton özelliklerine ulaş ve "etkileşime geçilebilir" özelliğini KAPAT
        havalandırmaÇalışıyor = false;
        Debug.Log("Havalandırma kapatıldı.");
    }


    public void ArayüzAç(bool[] kontrol) //etki alanındaki obje adı
    {
        if (kontrol[0])
        {
            havalandırmaEkArayüzObjesi.gameObject.SetActive(true); //arayüzü görünür kılar
        }
        if (kontrol[1])
        {
            bilgisayarEkArayüzObjesi.gameObject.SetActive(true); //arayüzü görünür kılar
        }
        if (kontrol[2])
        {
            şalterEkArayüzObjesi.gameObject.SetActive(true); //arayüzü görünür kılar
        }
        oyuncuHareketYazışık.hareketHızı = 0f; //arayüzü açınca karakterin hareket etmesini engeller.

    }

    public void ArayüzKapa()
    {
        havalandırmaEkArayüzObjesi.gameObject.SetActive(false); //arayüzü görünmez kılar
        bilgisayarEkArayüzObjesi.gameObject.SetActive(false); //arayüzü görünmez kılar
        şalterEkArayüzObjesi.gameObject.SetActive(false); //arayüzü görünmez kılar
        oyuncuHareketYazışık.hareketHızı = oyuncuHareketYazışık.varsayılanHareketHızı; //arayüzü kapatınca karakterin hareket etme yetisini geri kazandırır.
    }

    //Şalter
    public GameObject şalterEkArayüzObjesi;


}