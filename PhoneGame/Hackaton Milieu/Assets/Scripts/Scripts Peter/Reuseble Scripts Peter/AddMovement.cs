using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMovement : MonoBehaviour 
{
    //If the object can move
    public bool canMove { get { return gsCanMove; } set { gsCanMove = value; } }
    public bool gsCanMove = true;// Get Set canMove

    // Liniair speed in units per sec.
    [SerializeField]
    private Vector3 axesSpeed;

    void Update()
    {
        if (gsCanMove)
        {
            //Count the time to the axesSpeed
            Vector3 newPosition = axesSpeed * Time.deltaTime;

            //Go to the newPosition
            transform.Translate(newPosition);
        }
    }
}

