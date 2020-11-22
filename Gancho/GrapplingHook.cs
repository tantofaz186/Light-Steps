using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

[RequireComponent(typeof(LineRenderer))]
public class GrapplingHook : MonoBehaviour
{
    public float velocidade = 5f;
    [SerializeField] Gancho foco;
    PlayerCharScript player;
    LineRenderer corda;

    // Start is called before the first frame update
    void Awake()
    {
        corda = GetComponent<LineRenderer>();
        player = GetComponentInParent<PlayerCharScript>();
    }
    #region raycast UNUSED
    //// Update is called once per frame
    //void Update()
    //{     
    //float range = 100;
    //Ray ray = player.cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
    //RaycastHit hit;
    //if (Physics.Raycast(ray, out hit, range))
    //{
    //    Gancho gancho = hit.collider.GetComponent<Gancho>();
    //    if (gancho != null)
    //    {
    //        foco = gancho;
    //        foco.Highlight();
    //    }
    //}       
    //}
    #endregion
    void Update()
    {
        if (foco != null)
            Debug.DrawLine(gameObject.transform.position, foco.transform.position, Color.red);
    }
    void LateUpdate()
    {
        DesenharCorda();
    }
    public void SetFoco(Gancho gancho)
    {
        RaycastHit hit;
        if (Physics.Linecast(gameObject.transform.position, gancho.transform.position, out hit))
        {
            if (hit.collider.gameObject == gancho.gameObject && !insideCoroutine)
            {
                foco = gancho;
                StartCoroutine("UsandoGrapplingHook", gancho);
            }
        }
    }
    void DesenharCorda()
    {
        if (foco != null)
        {
            corda.enabled = true;
            corda.SetPosition(0, transform.position);
            corda.SetPosition(1, foco.transform.position);
        }
        else
        {
            corda.enabled = false;
        }
    }
    //IEnumerator CameraToHook()
    //{
    //    Debug.Log("Eu");
    //    float time = 0;
    //    Transform aux = GameObject.Find("ThirdPersonCamera").GetComponent<CinemachineFreeLook>().LookAt;
    //    while (time <= 2)
    //    {
    //        GameObject.Find("ThirdPersonCamera").GetComponent<CinemachineFreeLook>().LookAt = foco.transform;
    //        time += Time.deltaTime;
    //        yield return null;
    //    }
    //    Debug.Log("Eu Acabei");
    //    GameObject.Find("ThirdPersonCamera").GetComponent<CinemachineFreeLook>().LookAt = aux;
    //}
    bool insideCoroutine = false;
    IEnumerator UsandoGrapplingHook(Gancho gancho)
    {
        insideCoroutine = true;
        bool primeiraParte = true;
        player.canMove = false;//para a os movimentos para usar o gancho
        Vector3 offset = gancho.PontoMaximo - player.transform.position;
        while (Vector3.Distance(player.controller.transform.position, gancho.PontoFinal) > 0.2f)
        {
            if (primeiraParte)
            {

                player.controller.Move(offset * velocidade * Time.deltaTime);
                //player.controller.Move(gancho.PontoMaximo.normalized * velocidade * Time.deltaTime);
                //Vector3.Slerp(player.gameObject.transform.position, foco.PontoMaximo, time / tempo);
            }
            else
            {
                offset = gancho.PontoFinal - gancho.PontoMaximo;
                player.controller.Move(offset * (velocidade / 2f) * Time.deltaTime);
                foco = null;
                //player.controller.Move(gancho.PontoFinal.normalized * velocidade * Time.deltaTime);
                //Vector3.Lerp(player.gameObject.transform.position, foco.PontoFinal, time / tempo);
            }
            if (Vector3.Distance(player.controller.transform.position, gancho.PontoMaximo) < 0.2f)
                primeiraParte = false;
            yield return null;
        }
        player.canMove = true;//retorna os movimentos
        insideCoroutine = false;
    }
}