using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biscoito : MonoBehaviour
{
    public GameObject somDaPata;

    void Start()
    {
        FindObjectOfType<GameManager>().AumentarQuantidadeDeBlocos();
    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("Patinha"))
        {
            FindObjectOfType<GameManager>().DiminuirQuantidadeDeBlocos();

            Instantiate(somDaPata, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
