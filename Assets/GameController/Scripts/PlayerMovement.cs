using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    private Vector2 moveDirection = Vector2.zero; 
    public float moveSpeed = 2f; 
    
    private void Awake()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        Actions.MoveEvent += UpdateMoveVector;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HandlePlayerMovement(); 
    }

    private void UpdateMoveVector(Vector2 InputVector)
    {
        moveDirection = InputVector;

    }

    public void HandlePlayerMovement() 
    {      
        playerRigidbody.MovePosition(playerRigidbody.position + moveDirection * Time.fixedDeltaTime * moveSpeed); 
    }

    private void OnDisable()
    {
        Actions.MoveEvent -= UpdateMoveVector; 
    }
}
