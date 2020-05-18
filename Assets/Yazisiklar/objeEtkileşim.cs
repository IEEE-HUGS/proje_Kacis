using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objeEtkileşim : MonoBehaviour
{
    public bool envantereAlınabilir;        //eğer "doğru" ise obje envanterde tutulabilir.
    public bool açılabilir;                 //eğer "doğru" ise obje açılabilir.
    public bool kilitli;                    //eğer "doğru" ise obje kilitlidir ve etkileşime geçilemez.
    public bool aletÇantası;                //eğer "doğru" ise obje, alet çantasıdır.
    public GameObject gerekliObje;          //etkileşim için gerekli eşya
    public GameObject tornavidaObje;

    public Animator anim;  
        
    public void GörünmezKıl()
    {
        gameObject.SetActive(false); //eşyayı görünmez kıl
    }

    public void Aç()
    {
        anim.SetBool("acik", true); //açılma animasyonu (şu an yok) 
    }

    public void TornavidayıGörünürKıl()
    {
        tornavidaObje.gameObject.SetActive(true);
    }
}
