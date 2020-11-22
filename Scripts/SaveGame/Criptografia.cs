using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criptografia
{
    public string Criptografar(string fraseOriginal, string senha)
    {
        char[] auxFrase = fraseOriginal.ToCharArray();
        string cripto = "";
        for (int i = 0; i < fraseOriginal.Length; i++)
        {
            auxFrase[i] += senha[i % senha.Length];
            cripto += auxFrase[i];
        }

        //Debug.Log(fraseOriginal);
        //Debug.Log(cripto);
        return cripto;
    }
    public string DesCriptografar(string fraseCripto, string senha)
    {
        char[] auxFrase = fraseCripto.ToCharArray();
        string original = "";
        for (int i = 0; i < fraseCripto.Length; i++)
        {
            auxFrase[i] -= senha[i % senha.Length];
            original += auxFrase[i];
        }

        //Debug.Log(fraseCripto);
        //Debug.Log(original);
        return original;
    }
}
