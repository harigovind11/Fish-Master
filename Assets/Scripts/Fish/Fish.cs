using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [Serializable]
    public class FishType
    {
        public int price;
        public float minLength;
        public float maxLength;
        public float colliderRadius;
        public Sprite sprite;
    }

    FishType type;
    CircleCollider2D collider2D;
    float screenLeft;
    Tweener tweener;
    SpriteRenderer rend;

    public Fish.FishType Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
            collider2D.radius = type.colliderRadius;
            rend.sprite = type.sprite;
            
        }
    }
     void Awake()
    {
        collider2D= GetComponent<CircleCollider2D>();
        rend= GetComponent<SpriteRenderer>();
        screenLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;

    }


    void ResetFish()
    {
        if (tweener != null)
        {
            tweener.Kill(false);
        } 
        float num = UnityEngine.Random.Range(type.minLength,type.maxLength);
        collider2D.enabled = true;
        Vector3 poistion = transform.position;
        poistion.y = num;
        poistion.x = screenLeft;
        transform.position = poistion;

        float num2 = 1;
        float y = UnityEngine.Random.Range(num - num2 , num+num2);
        Vector2 v = new Vector2(-poistion.x,y);

        float num3 = 3;
        float delay = UnityEngine.Random.Range(0, 2 * num3);
        tweener = transform.DOMove(v, num3, false).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear).SetDelay(delay).OnStepComplete(delegate
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -localScale.x;
            transform.localScale = localScale;

        });
    }

}
