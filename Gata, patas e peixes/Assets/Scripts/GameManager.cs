using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int quantidadeDeBlocos;
    public static int acabou;

    public void AumentarQuantidadeDeBlocos()
    {
        quantidadeDeBlocos += 1;
        acabou = quantidadeDeBlocos;
    }

    public void DiminuirQuantidadeDeBlocos()
    {
        quantidadeDeBlocos -= 1;
    }
}
