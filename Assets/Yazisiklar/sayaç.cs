using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sayaç : MonoBehaviour
{
    public int SayaçBaşlangıç = 120; //Sayacın başlangıç değerini belirleme saniye bazında
    public OyunKontrol OyunKontrolYazışık; //süreBitti değişkenini buradan değiştirecek ve oyunun bitmesini sağlayacağız
    public Text SayaçUI; 


    void Start()
    {
        Sayaç(); //Sayaç fonksiyonunu oyunun başlangıcında çağırdık
    }

    //Sayacı çağıran bir fonksiyon yapalım
    void Sayaç()
    {
        if (SayaçBaşlangıç > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(SayaçBaşlangıç);
            SayaçUI.text = "Kalan Süre " + spanTime.Minutes + " : " + spanTime.Seconds; //Texte kalan süreyi yazar
            Debug.Log("Kalan Süre" + SayaçBaşlangıç); //Konsola kalan süreyi yazar
            SayaçBaşlangıç--; //Her döngüde sayacı 1 azaltır
            Invoke("Sayaç", 1.0f); //Döngüyü saniye olarak sınırlar böylece saniye bazında işlem yapılır 
        }
        else
        {
            SayaçUI.text = "Oyun Bitti\nKaçmayı Başaramadınız (Duruma göre-Dikkatli ol Hoca geliyor-)"; //Texte yazdırır
            Debug.Log("Oyun Bitti\nKaçmayı Başaramadınız (Duruma göre-Dikkatli ol Hoca geliyor-)"); //Sayaç 0 olduğu durumda konsola yazdırır
            OyunKontrolYazışık.süreBitti = true;
        }
    }
}