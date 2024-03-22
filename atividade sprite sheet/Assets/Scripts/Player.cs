using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rig;
    private Animator Anim;
    public int ForcaPulo;
    public bool NoChao;
    
    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!NoChao && collision.gameObject.tag == "Chao")
        {
            NoChao = true;
            Anim.SetBool("Está no chão", true);
            Anim.SetBool("Está pulando", false);
        }

        else
        {
            Anim.SetBool("Está no ar", true);
        }
    }

    void FixedUpdate()
    {

        Input.GetMouseButton(0);
        if (Input.GetKey(KeyCode.D))
        {
            Rig.velocity = Vector2.right * Speed;
            Anim.SetBool("Está correndo", true);
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        
        else if (Input.GetKey(KeyCode.A))
        {
            Rig.velocity = Vector2.left * Speed;
            Anim.SetBool("Está correndo", true);
            transform.eulerAngles = new Vector2(0f, 180f);
        }
        else
        {
            Anim.SetBool("Está correndo", false);
        }

        if (Input.GetKey(KeyCode.Space) && !Anim.GetBool("Está pulando"))
        {
            Rig.AddForce(transform.up * ForcaPulo);
            
            Anim.SetBool("Está pulando", true);
            NoChao = false;
            Anim.SetBool("Está no chão", false);
        }
       
    }
}