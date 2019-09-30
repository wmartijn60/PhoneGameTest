using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMargin2D : MonoBehaviour
{
    [SerializeField]
    private Vector2 addMarging;

    //
    void Start()
    {
        AddMargin(addMarging);
    }

    /// <summary>
    /// Add a margin position the object for boundary triggers (Like outside a camera)
    /// </summary>
    /// <param name="_margin"></param>
    public void AddMargin(Vector2 _margin)
    {
        transform.Translate(_margin);
    }
}
