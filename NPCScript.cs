using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{

    public NPCData npc;
    public InventoryManager inventario;
    public float raioDeInteração = 3.5f;
    // Start is called before the first frame update

    void Awake()
    {
        npc = new NPCData();
        inventario.inventarioBolsa.listaDeItens = npc.itensNaBolsa;
        inventario.inventarioEquipado.listaDeEquipados = npc.itensEquipados;
        //inventario.inventarioInimigo = FindObjectOfType<PlayerCharScript>().inventario;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gizmos.DrawSphere(transform.position, raioDeInteração);
    }
}
