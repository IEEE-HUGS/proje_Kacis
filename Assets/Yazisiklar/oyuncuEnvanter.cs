using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuEnvanter : MonoBehaviour
{

    public GameObject[] envanter = new GameObject[0];

    public void EsyaEkle(GameObject esya)
    {

        bool esyaEklendi = false;

        for (int i=0; i < envanter.Length; i++) //envanterdeki ilk boş slotu bul
        {
            if(envanter[i] == null)
            {
                envanter[i] = esya;
                Debug.Log(esya.name + " eklendi.");
                esyaEklendi = true;
                esya.SendMessage("EtkilesimdeBulun");
                break;
            }
        }

        if (!esyaEklendi) //envanter dolu
        {
            Debug.Log("Envanter dolu. Eşya eklenemedi.");

        }

    }

}
