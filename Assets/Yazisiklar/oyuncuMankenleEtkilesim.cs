using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuMankenleEtkilesim : MonoBehaviour
{
    public SpriteRenderer oyuncuIsleyici;

    void OnTriggerEnter2D(Collider2D etkilesim)
    {
        if (etkilesim.CompareTag("etkiManken"))
        {
            oyuncuIsleyici.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }

    void OnTriggerExit2D(Collider2D etkilesim)
    {
        if (etkilesim.CompareTag("etkiManken"))
        {
            oyuncuIsleyici.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
        }
    }
}