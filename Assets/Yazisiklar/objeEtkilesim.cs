using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objeEtkilesim : MonoBehaviour
{
    public bool envantereAlinabilir;        //eğer "doğru" ise obje envanterde tutulabilir.
    public bool acilabilir;                 //eğer "doğru" ise obje açılabilir.
    public bool kilitli;                    //eğer "doğru" ise obje kilitlidir ve etkileşime geçilemez.
    public bool aletCantasi;                //eğer "doğru" ise obje, alet çantasıdır.
    public GameObject gerekliObje;          //etkileşim için gerekli eşya
    public GameObject tornavidaObje;

    public Animator anim;  
        
    public void GorunmezKil()
    {
        gameObject.SetActive(false); //eşyayı görünmez kıl
    }

    public void Ac()
    {
        anim.SetBool("acik", true); //açılma animasyonu (şu an yok) 
    }

    public void TornavidayiGorunurKil()
    {
        tornavidaObje.gameObject.SetActive(true);
    }
}
