using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gancho : ObjetoDeInteracao
{

    [SerializeField] Vector3 pontoMaximo;
    [SerializeField] Vector3 pontoFinal;
    public Vector3 PontoMaximo { get { return transform.position + pontoMaximo; } }
    public Vector3 PontoFinal { get { return transform.position + pontoFinal; } }
    private void OnValidate()
    {
        actionText = "Usar Gancho";
    }
    public override void Interagir(GameObject agent)
    {
        if (InRange(agent))
        {
            agent.GetComponentInChildren<GrapplingHook>().SetFoco(this);
        }
    }
    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.DrawWireSphere(PontoMaximo, .5f);
        Gizmos.DrawWireSphere(PontoFinal, .2f);
    }
}
