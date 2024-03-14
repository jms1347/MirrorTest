using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class TestMove : MonoBehaviour
{
    public float moveSpeed = 5f; // �÷��̾� �̵� �ӵ�

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
            float moveHorizontal = Input.GetAxis("Horizontal"); // ���� �Է� ��
            float moveVertical = Input.GetAxis("Vertical"); // ���� �Է� ��

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.velocity = movement * moveSpeed;
        }
    }
}
