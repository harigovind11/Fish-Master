using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Hook : MonoBehaviour
{
    public Transform hookedTransform;

    Camera mainCamera;
    Collider2D coll;

    int length;
    int strength;
    int fishCount;

    bool canMove = true;

    //List<fish>

    Tweener cameraTween;


    void Awake()
    {
        mainCamera = Camera.main;
        coll = GetComponent<Collider2D>();
        //List<fish>
    }

    void Update()
    {
        if (canMove && Input.GetMouseButton(0))
        {
            Vector3 vector=mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 position = transform.position;
            position.x = vector.x;
            transform.position = position;
        }
    }
}
