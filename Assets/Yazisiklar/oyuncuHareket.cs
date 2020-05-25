using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuHareket : MonoBehaviour
{
    public float varsayılanHareketHızı;
    public float hareketHızı;

    public Rigidbody2D kc;

    public Animator animatör;


    Vector2 hareket;

    void Start() 
    {
        hareketHızı = varsayılanHareketHızı;
    }

    void Update() //Girdiler
    {
        hareket.x = Input.GetAxisRaw("Horizontal");
        hareket.y = Input.GetAxisRaw("Vertical");

        animatör.SetFloat("Yatay", hareket.x);
        animatör.SetFloat("Dikey", hareket.y);
        animatör.SetFloat("Hız", hareket.sqrMagnitude);
    }

    void FixedUpdate() //Hareket kodları 
    {
        kc.MovePosition(kc.position + hareket * hareketHızı * Time.fixedDeltaTime);
    }
}
