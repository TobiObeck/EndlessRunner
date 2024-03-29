﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

	// Use this for initialization
	void Start ()
    {
        this.groundCollider = GetComponent<BoxCollider2D>();
        this.groundHorizontalLength = groundCollider.size.x;
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -this.groundHorizontalLength)
        {
            this.RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(this.groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
