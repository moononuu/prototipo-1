using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Vector3 currentPosition;
    public float speed = 15f;       //Velocidade de aceleração
    public float turnSpeed = 80f;   //Velocidade de rotação
    float forwardInput;
    float horizontalInput;
    public Vector3 verticalaxis;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(nitroboost());
        movimento();
    
    }

    private void movimento()
    {
        verticalaxis = transform.localPosition * 0;

        forwardInput = Input.GetAxis("Vertical");       //recebe a tecla para andar para a frente
        horizontalInput = Input.GetAxis("Horizontal");  //recebe a tecla para virar o carro
       

        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);

        if (forwardInput < 0)
        {
            horizontalInput = -horizontalInput;
        }

        if (forwardInput != 0)
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);    //Vira o carro
            
        }

    }

    private IEnumerator nitroboost()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) )
        {
            Debug.Log("Funciona");
            speed = speed * 2;

            yield return new WaitForSeconds(2.0f) ;
            Debug.Log("Nao");
            speed = speed/2;
        }
    }
}



