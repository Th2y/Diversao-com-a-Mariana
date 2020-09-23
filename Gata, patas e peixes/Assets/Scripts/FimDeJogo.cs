using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FimDeJogo : MonoBehaviour
{
    Thread thread;
    public int pontos;
    public Text pontuacao;

    public GameObject[] Patas;
    public GameObject[] Gatas;
    public GameObject Proximo;
    public GameObject ProximaFase;
    public GameObject FinalDoJogo;

    public static int vidas = 3;

    public Text vidasRestantes;

    void Start()
    {
        Patas[0].SetActive(true);
        Patas[1].SetActive(false);
        Patas[2].SetActive(false);

        Gatas[0].SetActive(true);
        Gatas[1].SetActive(false);
        Gatas[2].SetActive(false);

        Proximo.SetActive(false);
        ProximaFase.SetActive(false);
        FinalDoJogo.SetActive(false);

        pontuacao.enabled = false;
        thread = new Thread(Pontuar);
        thread.Start();

        vidasRestantes.text = "Vidas: " + vidas.ToString();
    }

    private void Update()
    {
        if (GameManager.quantidadeDeBlocos == 0)
        {
            pontuacao.enabled = true;
            pontuacao.text = "Pontos: " + pontos.ToString();
            ProximaFase.SetActive(true);
            Proximo.SetActive(true);
        }

        vidasRestantes.text = "Vidas: " + vidas.ToString();
        Pontuar();
        if(pontuacao.enabled == true)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;

        if (Input.GetKeyDown(KeyCode.Escape))
            SairDoJogo();
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Patinha"))
        { 
            if(vidas >= 3)
            {
                vidas = 2;

                Destroy(Patas[0]);
                Patas[1].SetActive(true);

                Destroy(Gatas[0]);
                Gatas[1].SetActive(true);

                pontos = vidas + GameManager.acabou;
                Pontuar();
            }

            else if (vidas == 2)
            {
                vidas = 1;

                Destroy(Patas[1]);
                Patas[2].SetActive(true);

                Destroy(Gatas[1]);
                Gatas[2].SetActive(true);

                pontos = vidas + GameManager.acabou;
                Pontuar();
            }

            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                vidas = 3;
            }
        }
    }

    private void Pontuar()
    {
        if (GameManager.quantidadeDeBlocos == 0)
        {
            pontos = vidas + GameManager.acabou;
        }
    }

    public void Continuar(string _continuar)
    {
        switch (_continuar)
        {
            case "Proximo":
                vidas = 3;
                if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                else
                    FinalDoJogo.SetActive(true);
                break;
        }
    }

    private void SairDoJogo()
    {
        Application.Quit();
    }
}
