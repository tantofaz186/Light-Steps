using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCanvasScript : MonoBehaviour
{
    public void Cancelar()
    {
        GameObject.Find("Management/GameManager").GetComponent<GameManagerScript>().LoadHud("TeleportMenu");
    }

    public void TeleportToNovaSampaButton()
    {
        GameObject.Find("Management/GameManager").GetComponent<GameManagerScript>().StartTeleport("NovaSampa");
    }

    public void TeleportToEmpresaAlvoButton()
    {
        GameObject.Find("Management/GameManager").GetComponent<GameManagerScript>().StartTeleport("EmpresaAlvo");
    }

    public void TeleportToEmpresaChefeButton()
    {
        GameObject.Find("Management/GameManager").GetComponent<GameManagerScript>().StartTeleport("EmpresaChefe");
    }

}
