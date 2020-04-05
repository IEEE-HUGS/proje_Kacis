using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuEnvanter : MonoBehaviour
{

    public GameObject[] envanter = new GameObject[1];

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

    public void EsyaSil()
    {
        envanter = new GameObject[1];
        Debug.Log("Eşya silindi");
    }

    public bool EsyaBul(GameObject esya)
    {
        for (int i = 0; i < envanter.Length; i++)
        {
            if(envanter[i] == esya)
            {
                //eşya bulundu
                return true;
            }
        }
        //eşya bulunamadı  
        return false;
    }
}
