using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : DialogItem
{
    public string nome = "placeholder";
    public ItemDeColetaNoCenario lootObject;
    public NPCData npc;
    public List<Item> inventario;
    public List<Item> equipados;


    public int persuasao = 10; // 0 - 5: violento; 6 - 14:  neutro; 15 - 20: amigo;
    // Escolha da ação (atacar, comportamento padrão, conversar)

    public float atencao = 10; // Valor de 0 a 10 que afeta o stealth do player;
                               // lista de itens que possam ser roubados

    private void OnValidate()
    {
        actionText = "Conversar com " + nome;
    }
    void Awake()
    {
        npc = new NPCData();
        npc.afinidade = persuasao;
        npc.atencao = atencao;
        npc.itensEquipados = equipados;
        npc.itensNaBolsa = inventario;
        npc.position = gameObject.transform.position;
        lootObject.itens = equipados;
        for (int i = 0; i < inventario.Count; i++)
        {
            lootObject.itens.Add(inventario[i]);
        }
    }

    void Start()
    {
        persuasao =  npc.afinidade;
        atencao = npc.atencao;
        equipados = npc.itensEquipados;
        inventario = npc.itensNaBolsa;
        gameObject.transform.position = npc.position;
    }
    void Update()
    {
        // Aqui ficam os comandos que pausam com o jogo.
        if (!GameManagerScript.gameIsPaused)
        {

        }
    }

    private void OnDestroy()
    {
        Instantiate(lootObject);
    }
    // Update is called once per frame
}
