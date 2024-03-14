using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class TestMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어 이동 속도

    private Rigidbody2D rb;
    private NetworkIdentity a;
    
    void Start()
    {
        a = GetComponent<NetworkIdentity>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (a.isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal"); // 수평 입력 값
            float moveVertical = Input.GetAxis("Vertical"); // 수직 입력 값

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.velocity = movement * moveSpeed;
        }
    }
}
