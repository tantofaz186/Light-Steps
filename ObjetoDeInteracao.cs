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

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pontoDeInteração, raioDeInteração);
    }
    public virtual void Interagir(GameObject agent)
    {
        float distancia = Vector3.Distance(agent.transform.position, pontoDeInteração) - raioDeInteração;
        bool inRange = distancia <= 0;
        Debug.Log("Distance to object: " + distancia);
        if (!inRange) Debug.Log("Out of Interaction range");
    }

}
