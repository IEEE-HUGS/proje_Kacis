using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objeEtkilesim : MonoBehaviour
{
    public bool envantereAlinabilir;        //eğer "doğru" ise obje envanterde tutulabilir.
    public bool acilabilir;                 //eğer "doğru" ise obje açılabilir.
    public bool kilitli;                    //eğer "doğru" ise obje kilitlidir ve etkileşime geçilemez.
    public GameObject gerekliEsya;          //etkileşim için gerekli eşya

    public Animator anim;

    public void EtkilesimdeBulun()
    {
        gameObject.SetActive(false); //eşyayı görünmez kıl
    }

    public void Ac()
    {
        anim.SetBool("acik", true);
    }
}
