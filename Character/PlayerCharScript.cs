using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharScript : MonoBehaviour
{
    /*
        The main player character script.
        Contains all methods for performing basic player character functions.
    */
    /// <summary>
    /// The main player character script.
    /// Contains all methods for performing basic player character functions.
    /// </summary>
    public PlayerData player;
    public CharacterController controller;
    public Transform cam;

    public float speed = 20f;
    float runSpeed = 0f;
    public float gravity = 10f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public bool canMove = true;
    void Awake()
    {
        player = new PlayerData();
    }


    void Update()
    {
        if (!GameManagerScript.gameIsPaused) // Pausa o player quando o GameManager pausar o jogo
        {

            #region Third Person Movement

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            runSpeed = (float)(speed * Math.Abs(Math.Sqrt(Math.Pow(Input.GetAxisRaw("Horizontal"), 2) + Math.Pow(Input.GetAxisRaw("Vertical"), 2))));
            if (canMove)
            {
                if (direction.magnitude > 0.1f)
                {
                    Vector3 move = MoveAndRotate(direction);
                    controller.Move(move.normalized * runSpeed * Time.deltaTime);
                }
                // gravity  
                controller.Move(Vector3.down * gravity * Time.deltaTime);
            }
            #endregion

            #region Interagir
            Collider[] hits = Physics.OverlapSphere(transform.position, 20);
            if (hits.Length > 0)
            {
                Collider hit = null;

                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].TryGetComponent<ObjetoDeInteracao>(out _))
                    {
                        if (hit == null) hit = hits[i];
                        float oldDist = Vector3.Distance(transform.position, hit.transform.position);
                        float newDist = Vector3.Distance(transform.position, hits[i].transform.position);
                        if (newDist < oldDist)
                        {
                            hit = hits[i];
                        }
                    }
                    if (hit != null)
                    {
                        ObjetoDeInteracao objeto = hit.GetComponent<ObjetoDeInteracao>();
                        if (Input.GetButtonDown("Interact"))
                        {
                            Interagir(objeto);
                        }/*
                        if (objeto.InRange(gameObject))
                        {
                            DialogController.instance.SetAction(objeto);
                        }
                        else
                        {
                            DialogController.instance.HidePanel();
                        }*/

                    }
                }
            }

            #endregion
        }
    }
    public Vector3 MoveAndRotate(Vector3 direction)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        transform.rotation = Quaternion.Euler(.0f, angle, .0f);
        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        return moveDirection;
    }

    void Interagir(ObjetoDeInteracao item)
    {
        item.Interagir(gameObject);
    }
}
