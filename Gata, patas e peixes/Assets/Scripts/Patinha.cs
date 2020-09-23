using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patinha : MonoBehaviour
{
    public bool jogoIniciou;
    public float direcaoX;
    public float direcaoY;
    public Rigidbody2D patinhaRB;
    public AudioSource somDaPata;

    void Start()
    {
        jogoIniciou = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            LancarPatinha();
    }

    private void LancarPatinha()
    {
        if(jogoIniciou == false)
        {
            jogoIniciou = true;
            patinhaRB.velocity = new Vector2(direcaoX, direcaoY);
        }
    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        somDaPata.Play();
    }
}
