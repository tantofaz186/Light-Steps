using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class ObjetoDeInteracao : MonoBehaviour
{

    [SerializeField] protected float raioDeInteração = 3;
    [SerializeField] Vector3 PontoDeInteração;
    public Vector3 pontoDeInteração { get { return gameObject.transform.position + PontoDeInteração; } }

    public string actionText = "interagir";
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pontoDeInteração, raioDeInteração);
    }
    public virtual void Interagir(GameObject agent)
    {
        if (!InRange(agent)) Debug.Log("Out of Interaction range");
    }
    public bool InRange(GameObject agent)
    {
        float distancia = Vector3.Distance(agent.transform.position, pontoDeInteração) - raioDeInteração;
        Debug.Log("Distance to object: " + distancia);
        return distancia <= 0;
    }

}
