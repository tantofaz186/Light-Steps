using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemDeColetaNoCenario : ObjetoDeInteracao
{
    public List<Item> itens;
    Inventory loot;

    bool destruir = false;
    private void OnValidate()
    {
        actionText = "Saquear";
    }

    bool MenuSceneLoaded
    {
        get { return SceneManager.GetSceneByName("PlayerMenu").isLoaded; }
    }
    void Update()
    {
        if (loot != null)
        {
            itens = loot.listaDeItens;
            if (loot.listaDeItens.Count <= 0)
                destruir = true;
            else
                destruir = false;
        }
        if (destruir == true && !MenuSceneLoaded)        
            Destroy(gameObject);
                
    }

    public override void Interagir(GameObject agent)
    {
        if (InRange(agent))
        {
            if (!MenuSceneLoaded)
                FindObjectOfType<GameManagerScript>().LoadHud("PlayerMenu");
            if (!MenuSceneLoaded)
            {
                StartCoroutine("EsperarCarregar");
            }
        }
    }
    IEnumerator EsperarCarregar()
    {
        while (!MenuSceneLoaded)
        {
            yield return null;
        }
        if (MenuSceneLoaded)
        {
            InventoryManager manager = FindObjectOfType<InventoryManager>();
            loot = manager.bolsaInimiga;
            for (int i = 0; i < itens.Count; i++)
            {
                manager.bolsaInimiga.AdicionarItem(itens[i]);
            }
        }
    }
}
