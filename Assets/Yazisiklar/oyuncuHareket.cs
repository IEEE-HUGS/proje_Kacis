using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuHareket : MonoBehaviour
{

    public float hareketHizi = 5f;

    public Rigidbody2D kc;

    public Animator animator;


    Vector2 hareket;
  
    void Update() //Girdiler
    {

        hareket.x = Input.GetAxisRaw("Horizontal");
        hareket.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Yatay", hareket.x);
        animator.SetFloat("Dikey", hareket.y);
        animator.SetFloat("Hız", hareket.sqrMagnitude);

    }

    void FixedUpdate() //Hareket kodları 
    {

        kc.MovePosition(kc.position + hareket * hareketHizi * Time.fixedDeltaTime);
        

    }
}
