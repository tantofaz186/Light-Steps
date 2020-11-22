using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogItem : ObjetoDeInteracao
{
    public string[] dialog;
    [NonSerialized]public int index = 0;
    public bool repeatAllDialog = false;//se verdadeiro repete todas as falas, caso contrário apenas a última
    void OnValidate()
    {
        actionText = "Conversar com " + gameObject.name;
    }
    public override void Interagir(GameObject agent)
    {
        float distancia = Vector3.Distance(agent.transform.position, pontoDeInteração) - raioDeInteração;
        bool inRange = distancia <= 0;
        if (inRange)
            DialogController.instance.SetDialog(this);
    }
}
