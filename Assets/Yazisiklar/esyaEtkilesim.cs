using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esyaEtkilesim : MonoBehaviour
{

    public bool envantereAlinabilir;       //eğer "doğru" ise obje envanterde tutulabilir.

    public void EtkilesimdeBulun()
    {
        gameObject.SetActive(false); //eşyayı görünmez kıl
    }

}
