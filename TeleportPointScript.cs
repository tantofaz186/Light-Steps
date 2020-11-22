using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPointScript : MonoBehaviour
{
    public float Distance = 1.0f;
    bool inside = true;

    // GameObject.Find("Management/GameManager").GetComponent<GameManagerScript>().StartTeleport("EmpresaAlvo");
    GameObject PlayerChar;


    void Awake()
    {
        StartCoroutine("EsperarCarregar");
    }

    private void Update()
    {
        if (PlayerChar != null)
        {
            if (!inside)
            {
                if (Vector3.Distance(PlayerChar.transform.position, this.transform.position) <= Distance)
                {
                    inside = true;
                    GameObject.Find("Management/GameManager").GetComponent<GameManagerScript>().LoadHud("TeleportMenu");
                }
            }
            if(Vector3.Distance(PlayerChar.transform.position, this.transform.position) > Distance)
            {
                inside = false;
            }
        }
    }
    bool thisSceneLoaded
    {
        get { return SceneManager.GetSceneByName(GameObject.Find("Management/GameManager").GetComponent<GameManagerScript>().CurrentScenario).isLoaded; }
    }
    IEnumerator EsperarCarregar()
    {
        while (!thisSceneLoaded)
        {
            yield return null;
        }
        if (thisSceneLoaded)
        {
            Debug.Log(GameObject.Find("Management/GameManager").GetComponent<GameManagerScript>().CurrentScenario);
            GameObject.Find("Management/GameManager").GetComponent<GameManagerScript>().EndTeleport();
            yield return new WaitForSeconds(1);
            PlayerChar = GameObject.Find("PlayerChar");
        }
    }
}
