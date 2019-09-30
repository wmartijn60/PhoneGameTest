using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDeactivate : MonoBehaviour
{
    [SerializeField]
    private GameObject screenBottom;

    // Start is called before the first frame update
    void Start()
    {
        screenBottom = GameObject.Find("ScreenBottom");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If the position is lower than the bottom of the screen. Deactivate the object
        if (gameObject.transform.position.y <= screenBottom.transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }
}
