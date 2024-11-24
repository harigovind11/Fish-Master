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
    
    bool canMove ;

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

    public void StartFishing()
    {
        length = -50;
        strength = 3;
        fishCount = 0;

        float time = (-length) * .1f;

        cameraTween = mainCamera.transform.DOMoveY(length, 1 + time, false).OnUpdate(delegate
        {
            if(mainCamera.transform.position.y <= -11)
            {
                transform.SetParent(mainCamera.transform);
            }
        }).OnComplete(delegate
        {
            coll.enabled = true;
            cameraTween = mainCamera.transform.DOMoveY(0, time * 5, false).OnUpdate(delegate
            {
                if (mainCamera.transform.position.y >= -25f)
                {
                    StopFishing();
                }
            });
        });
        coll.enabled = false;
        canMove = true;
    }
    void StopFishing()
    {
        canMove = false;
        cameraTween.Kill(false);
        cameraTween = mainCamera.transform.DOMoveY(0, 2, false).OnUpdate(delegate
        {
            if (mainCamera.transform.position.y >= -11)
            {
                transform.SetParent(null);
                transform.position = new Vector2(transform.position.x, -6);

            }
        }).OnComplete(delegate
        {
            transform.position = Vector2.down * 6;
            coll.enabled = true;
            int num = 0;
        });
    
    }
}
