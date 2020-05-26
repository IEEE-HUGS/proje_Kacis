using UnityEngine;
using UnityEngine.Audio;
using System;
//FindObjectOfType<SesKontrol>().Oynat("sesDosyaAdı");  <- komutu ile bu yazışık dışında ses oynatılabilir.
public class SesKontrol : MonoBehaviour
{

    public Sesler[] seslerYazışık;

    public static SesKontrol örnek;

    // Start is called before the first frame update
    void Awake()
    {
        if (örnek == null){
            örnek = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad (gameObject);

        foreach(Sesler s in seslerYazışık) {
            s.sesKaynağı = gameObject.AddComponent<AudioSource>();
            s.sesKaynağı.clip = s.klip;

            s.sesKaynağı.volume = s.sesSeviyesi;
            s.sesKaynağı.pitch = s.perde;
            s.sesKaynağı.loop = s.döngü;
        }
    }

    public void Oynat (string isim) {
        Sesler s = Array.Find(seslerYazışık, ses => ses.isim == isim);
        s.sesKaynağı.Play();
        if (s == null){
            Debug.LogWarning(isim + " adlı ses bulunamadı!");
            return;
        }
    }

    public void Start(){
        //oyun başladığı gibi çalmasını istediğimiz müzik (bkz: arka plan müziği)
        //Oynat("aletÇantasıAçma");
    }
}
