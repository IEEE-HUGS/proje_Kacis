using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public bool oyunBitti = false;

    //oyunun bitme sebepleri
    public bool soğuktanÖldün = false;
    public bool yakalandın = false;
    public bool kaçtın = false;
    public bool süreBitti = false;

    public void OyunuBitir()
    {
        if (soğuktanÖldün || yakalandın || süreBitti)
        {
            SceneManager.LoadScene("oyunBitti_öldün");
        }
    }
}
