using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    private Collider2D col2D;

    private GameObject player;

    private float colHeight;

    // Start is called before the first frame update
    void Start()
    {
        col2D = gameObject.GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If there was no player found. Dont run the code.
        if (player == null)
            return;

        colHeight = col2D.bounds.size.y;


        //If the Player is higher than the X + Collider height / 2
        if (player.transform.position.y > (gameObject.transform.position.y + (colHeight / 2)))
        {
            col2D.enabled = true;
        }
        else
        {
            col2D.enabled = false;
        }
    }

    void OnGizmosDraw()
    {
        Gizmos.DrawLine(new Vector2(-col2D.bounds.size.x / 2, gameObject.transform.position.y + (colHeight / 2)), new Vector2(col2D.bounds.size.x / 2, gameObject.transform.position.y + (colHeight / 2)));
    }
}
