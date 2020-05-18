using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuMankenleEtkileşim : MonoBehaviour
{
    public SpriteRenderer oyuncuİşleyici;

    void OnTriggerEnter2D(Collider2D etkileşim)
    {
        if (etkileşim.CompareTag("etkiManken"))
        {
            oyuncuİşleyici.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }

    void OnTriggerExit2D(Collider2D etkileşim)
    {
        if (etkileşim.CompareTag("etkiManken"))
        {
            oyuncuİşleyici.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
        }
    }
}