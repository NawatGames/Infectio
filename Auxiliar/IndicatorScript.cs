using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    float _positionX;
    float _positionY;
    public Vector3 _position;
    public event Action<Vector3> SpacePressed;

    void Update()
    {
        _positionX = transform.position.x;
        _positionY = transform.position.y;

        //para cima --> Y
        if (Input.GetKeyDown("w"))
        {
            if (transform.position.y != 3)
            {
                var newPosition = new Vector3(_positionX, _positionY + 1, -1f);
                transform.position = newPosition;
            }
        }
        //para baixo --> Y
        if (Input.GetKeyDown("s"))
        {
            if(transform.position.y != -2)
            {
                var newPosition = new Vector3 (_positionX, _positionY - 1, -1f);      
                transform.position = newPosition;
            }
        }

        //para a direita --> X
        if (Input.GetKeyDown("d"))
        {
            if(transform.position.x != 2)
            {
                var newPosition = new Vector3(_positionX + 1, _positionY, -1f);
                transform.position = newPosition;
            }
        }
        //para a esquerda --> X
        if (Input.GetKeyDown("a"))
        {
            if(transform.position.x != -3)
            {
                var newPosition = new Vector3 (_positionX - 1, _positionY, -1f);      
                transform.position = newPosition;
            }
        }
        // retornar a posicao quando ele apertar o espaco
        if(Input.GetKeyDown("space"))
        {
            _position = transform.position;
            SpacePressed?.Invoke(_position);
            Debug.Log("Apertei!");
        }

    }
}
