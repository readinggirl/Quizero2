using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameEvenntScript : MonoBehaviour
{
    // Script shows the Event markers when the player comes close

    private SpriteRenderer spriteRenderer;
    private GameObject player;

    private float distance;
    void Start()
    {
        // Find player and sprite renderer
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.enabled = false;
    }

    void Update()
    {
        // Show the marker when the player comes close
        distance = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if (distance < 1)
        {
            spriteRenderer.enabled = true;
        }
    }
}
