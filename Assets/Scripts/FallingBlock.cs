﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedminMax;
    private float speed;

    private float visibleHeightThreshold;

    void Start()
    {
        speed = Mathf.Lerp(speedminMax.x, speedminMax.y, Difficulty.GetDifficultyPercent());

        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);

        if(transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }

        
    }
}
