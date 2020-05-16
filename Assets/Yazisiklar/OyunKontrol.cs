using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public bool oyunBitti = false;

    //oyunun bitme sebepleri
    public bool soguktanOldun = false;
    public bool yakalandin = false;
    public bool kactin = false;

    public void OyunuBitir()
    {
        if (soguktanOldun == true || yakalandin == true);
        {
            SceneManager.LoadScene("oyunBitti_oldun");
        }
    }
}
