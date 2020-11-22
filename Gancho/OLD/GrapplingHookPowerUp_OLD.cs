using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GrapplingHookPowerUp_OLD : MonoBehaviour
{
    bool isUsing;
    public GameObject player;
    PlayerCharScript playerScript;
    List<GameObject> GanchosEmProximidade = new List<GameObject>();
    public float velocidadeDoGancho = 0.015f;
    GameObject GanchoParaIr = null;

    KeyCode usarGancho = KeyCode.F;


    // Start is called before the first frame update
    void Start()
    {
        isUsing = false;
        playerScript = player.GetComponent<PlayerCharScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsing)
        {
            //playerScript.FisicBody.isKinematic = true;
            if (GanchoParaIr != null)
                UsarGancho(GanchoParaIr);
            if (Input.GetKeyDown(usarGancho))
            {
                SoltarGancho(GanchoParaIr.GetComponentInParent<Gancho_OLD>());
                GanchosEmProximidade.Remove(GanchoParaIr);
            }
        }
        else
        {
            //playerScript.FisicBody.isKinematic = false;
            if (Input.GetKeyDown(usarGancho))
                if (GanchosEmProximidade.Count > 0)
                {
                    GanchoParaIr = CheckClosest();
                    isUsing = true;
                    //playerScript.canMove = false;
                }
        }
    }
    GameObject CheckClosest()
    {
        GameObject Closestgancho = GanchosEmProximidade[0];
        foreach (GameObject gancho in GanchosEmProximidade)
        {
            if (Vector3.Distance(player.transform.position, Closestgancho.transform.position) >
                Vector3.Distance(player.transform.position, gancho.transform.position)
                )               
                Closestgancho = gancho;
        }
        return Closestgancho;
    }
    void UsarGancho(GameObject gancho)
    {
        if (Vector3.Distance(player.transform.position, gancho.transform.position) > 0.05f)
            player.transform.position = Vector3.Lerp(player.transform.position, gancho.transform.position, velocidadeDoGancho);
        else
            player.transform.position = gancho.transform.position;
    }
    void SoltarGancho(Gancho_OLD gancho)
    {
        gancho.Desativar();
        isUsing = false;
        //playerScript.canMove = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gancho"))
        {
            if (other.gameObject.GetComponentInParent<Gancho_OLD>().estáEnabled)
            {
                Debug.Log("Gancho foi adicionado: " + other.transform.position.ToString());
                other.gameObject.GetComponentInParent<Gancho_OLD>().Ativar();
                GanchosEmProximidade.Add(other.gameObject);
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Gancho"))
        {
            Debug.Log("Gancho foi retirado: " + other.transform.position.ToString());
            other.gameObject.GetComponentInParent<Gancho_OLD>().OutOfRange();
            GanchosEmProximidade.Remove(other.gameObject);
        }
    }

}
