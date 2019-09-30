using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneInput : MonoBehaviour
{
    public Rigidbody player;
    public float deadZoneMin;
    public float deadZoneMax;
    public float clampXMin;
    public float clampXMax;
    public Text accel;

    void Update()
    {
        accel.text = Input.acceleration.x.ToString();
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, clampXMin, clampXMax), transform.position.y);
        if(transform.position.x == clampXMax || transform.position.x == clampXMin){
            player.AddForce(new Vector2(0,0), ForceMode.Impulse);
        }

        if(Input.acceleration.x < deadZoneMax && Input.acceleration.x > deadZoneMin){
            player.AddForce(new Vector2(0, 0), ForceMode.Impulse);
        }
        else{
            player.AddForce(transform.right * Input.acceleration.x, ForceMode.Impulse);
        }
    }

}
