using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sesler {
    

    public string isim;

    public AudioClip klip;

    [Range(0f,1f)]
    public float sesSeviyesi;
    [Range(.1f,3f)]
    public float perde = 1f;

    public bool döngü;

    [HideInInspector]
    public AudioSource sesKaynağı;
}
