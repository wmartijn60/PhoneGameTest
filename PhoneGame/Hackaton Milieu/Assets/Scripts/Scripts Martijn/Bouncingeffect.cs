using UnityEngine;
using System.Collections;

public class Bouncingeffect : MonoBehaviour
{

    [SerializeField]
    private float power = 20F;


    Vector3 epicentro;

    void Start()
    {

        Vector3 explosionPos = transform.position;
        epicentro = explosionPos;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject Player = collision.gameObject;
            Rigidbody2D player = Player.GetComponent<Rigidbody2D>();
            player.AddForce(transform.up * power, ForceMode2D.Impulse);
            Debug.Log("Player has collided with Bouncer");
        }
    }
}
