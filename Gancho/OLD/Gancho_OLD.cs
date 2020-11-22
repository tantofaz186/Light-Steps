using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Gancho_OLD : MonoBehaviour
{
    Color disabledColor = Color.red;
    Color outOfRangeColor = Color.yellow;
    Color enabledColor = Color.green;
    bool ativado;
    public bool estáEnabled { get { return ativado; } private set { } }

    public GameObject hookPoint;
    public Collider HookCollider
    {
        get { return hookPoint.GetComponent<SphereCollider>(); }
        private set { }
    }

    public void Ativar()
    {
        hookPoint.GetComponent<Light>().enabled = true;
        hookPoint.GetComponent<Light>().color = enabledColor;
    }
    public void Desativar()
    {
        hookPoint.GetComponent<Light>().color = disabledColor;
        ativado = false;
    }
    public void OutOfRange()
    {
        if (ativado)
            hookPoint.GetComponent<Light>().color = outOfRangeColor;
    }
    // Start is called before the first frame update
    void Start()
    {
        hookPoint.GetComponent<Light>().enabled = false;
        ativado = true;
    }


}
