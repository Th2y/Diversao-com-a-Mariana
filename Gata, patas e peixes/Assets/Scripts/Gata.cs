using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gata : MonoBehaviour
{
    public float velocidade;

    public float xMinimo;
    public float xMaximo;

    public bool estaOlhandoParaADireita;
    
    void Start()
    {
        estaOlhandoParaADireita = true;
    }

    void Update()
    {
        Movimento();
    }

    private void Movimento()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, xMinimo, xMaximo), transform.position.y);

        if(Input.GetAxisRaw("Horizontal") > 0.01f)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            if(estaOlhandoParaADireita == false)
                FLip();
        }

        if (Input.GetAxisRaw("Horizontal") < -0.01f)
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
            if(estaOlhandoParaADireita == true)
                FLip();
        }
    }

    void FLip()
    {
        estaOlhandoParaADireita = !estaOlhandoParaADireita;

        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}
