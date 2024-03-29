﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoplay;
    private Ball ball;

    void Start() {
        ball = GameObject.FindObjectOfType<Ball>();
    }

	// Update is called once per frame
	void Update () {
        if(autoplay) {
            AutoPlay();
        }
        else {
            MoveWithMouse();
        }
	}

    void AutoPlay() {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y , 0f);
        Vector3 ballPos = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);

        this.transform.position = paddlePos;
    }

    void MoveWithMouse() {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y , 0f);

	    float pos = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(pos, 0.5f, 15.5f);

        this.transform.position = paddlePos;
    }
}
