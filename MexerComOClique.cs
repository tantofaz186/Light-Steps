using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MexerComOClique : MonoBehaviour
{

    Camera mainCamera;
    Ray ray;
    NavMeshAgent movableAgent;

    // Start is called before the first frame update
    void Start()
    {
        movableAgent = GetComponent<NavMeshAgent>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (movableAgent == null)
            Debug.LogError("Não foi possível encontrar o componente \"NavMeshAgent\" nesse objeto");
        if (mainCamera == null)
            Debug.LogError("Não foi possível encontrar um objeto com a tag \"MainCamera\"");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
             ray = mainCamera.ScreenPointToRay(Input.mousePosition);
             RaycastHit mouseDownHit;
            if (Physics.Raycast(ray, out mouseDownHit))
                movableAgent.SetDestination(mouseDownHit.point);

        }

    }
}
