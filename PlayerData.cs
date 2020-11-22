using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : CharacterData
{
    public int dinheiro;

    public PlayerData()
    {
        dinheiro = 0;
    }
    public override void PrintStats()
    {
        base.PrintStats();
        Debug.Log("Dinheiro: " + dinheiro);
    }
}
public class NPCData : CharacterData
{
    public int afinidade;// 0 - 5: violento; 6 - 14:  neutro; 15 - 20: amigo;
    // Escolha da ação (atacar, comportamento padrão, conversar)
    public float atencao;
    public NPCData()
    {

    }
    public override void PrintStats()
    {
        base.PrintStats();
        Debug.Log("Afinidade com o personagem principal: " + afinidade);
    }
}
public class CharacterData
{
    public Vector3 position;
    public List<Item> itensNaBolsa;
    public List<Item> itensEquipados;
    public float vida;

    public CharacterData()
    {
        itensEquipados = new List<Item>();
        itensNaBolsa = new List<Item>();
        position = new Vector3(0, 0, 0);
        vida = 100;
    }
    public virtual void PrintStats()
    {
        Debug.Log("Posição " + position.ToString());
        Debug.Log("Vida " + vida);
        for (int i = 0; i < itensEquipados.Count; i++)
        {
            Debug.Log("Item Equipado " + itensEquipados[i]);
        }
        for (int i = 0; i < itensNaBolsa.Count; i++)
        {
            Debug.Log("Item na bolsa " + itensNaBolsa[i]);
        }        
    }
}
