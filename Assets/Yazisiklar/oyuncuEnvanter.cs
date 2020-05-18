using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuEnvanter : MonoBehaviour
{
    public oyuncuEtkileşim oyuncuEtkileşimYazışık;
    public GameObject tornavidaObje;
    public GameObject[] envanter = new GameObject[1];

    public void EşyaEkle(GameObject eşya)
    {
        bool eşyaEklendi = false;

        for (int i=0; i < envanter.Length; i++) //envanterdeki ilk boş slotu bul
        {
            if(envanter[i] == null)
            {
                envanter[i] = eşya;
                Debug.Log(eşya.name + " eklendi.");
                eşyaEklendi = true;
                if (eşya.name == tornavidaObje.name)
                {
                    oyuncuEtkileşimYazışık.tornavidaAlındı = true;
                    UnityEngine.Debug.Log("TORNAVİDA ALINDI!");
                }
                eşya.SendMessage("GörünmezKıl");
                break;
            }
        }

        if (!eşyaEklendi) //envanter dolu
        {
            Debug.Log("Envanter dolu. Eşya eklenemedi.");
        }
    }

    public void EşyaSil()
    {
        envanter = new GameObject[1];
        Debug.Log("Eşya silindi");
    }

    public bool EşyaBul(GameObject eşya)
    {
        for (int i = 0; i < envanter.Length; i++)
        {
            if(envanter[i] == eşya)
            {
                //eşya bulundu
                return true;
            }
        }
        //eşya bulunamadı  
        return false;
    }
}
