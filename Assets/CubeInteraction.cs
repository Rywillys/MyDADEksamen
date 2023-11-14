using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FollowPlayerOnKeyPress : MonoBehaviour
{
    public float followSpeed = 5f;
    private Transform player;
    private bool isFollowing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isFollowing)
        {
            isFollowing = true;
        }

        if (isFollowing)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);

            // You can also look at the player if needed
            // transform.LookAt(player);
        }
        else
        {
            Debug.LogWarning("Player not found. Make sure the player has the appropriate tag.");
        }
    }
}