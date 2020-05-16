using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arayuzEtkilesim : MonoBehaviour
{

    public bool buBirArayuz = true;
    public bool havalandirma;
    public GameObject havalandirmaArayuzObjesi;


    public void ArayuzAc()
    {
        if (havalandirma)
        {
            havalandirmaArayuzObjesi.gameObject.SetActive(true);
        }
    }

}
