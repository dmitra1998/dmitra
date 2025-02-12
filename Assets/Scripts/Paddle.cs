﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    GameSession theGameSession;
    Ball theBall;
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;//To get mouse position
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);//To get current paddle position
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);//x value of paddle position is changed according to mouse position
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        { 
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }

}
