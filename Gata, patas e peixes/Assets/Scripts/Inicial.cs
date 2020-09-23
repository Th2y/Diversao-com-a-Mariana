using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicial : MonoBehaviour
{
    public GameObject Iniciar;

    public void Continuar(string _continuar)
    {
        switch (_continuar)
        {
            case "Iniciar":
                SceneManager.LoadScene("Fase_01");
                break;
        }
    }
}
