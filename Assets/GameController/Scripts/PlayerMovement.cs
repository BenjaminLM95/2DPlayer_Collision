using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    private Vector2 moveDirection = Vector2.zero; 
    private float moveSpeed;     
       

    public GameObject spriteObject;
    public SpriteRenderer spriteRenderer;
    public Sprite UpSprite;
    public Sprite DownSprite;
    public Sprite LeftSprite;
    public Sprite RightSprite;

    private void Awake()
    {
        moveSpeed = 2.5f; 
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
        Actions.MoveEvent += UpdateMoveVector;                
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HandlePlayerMovement();         

        if(moveDirection.y > 0) 
        {
            spriteRenderer.sprite = UpSprite;
        }
        else if(moveDirection.y < 0)
        {
            spriteRenderer.sprite = DownSprite;
        }

        if (moveDirection.x > 0)
        {
            spriteRenderer.sprite = RightSprite;
        }
        else if (moveDirection.x < 0)
        {
            spriteRenderer.sprite = LeftSprite;
        }
                
    }

    private void UpdateMoveVector(Vector2 InputVector)
    {
        moveDirection = InputVector;       
    }

    public void HandlePlayerMovement() 
    {      
        playerRigidbody.MovePosition(playerRigidbody.position + moveDirection * Time.fixedDeltaTime * moveSpeed);        
    }

    public void MoveFaster() 
    {        
       moveSpeed = 8f;          
    }

    public void ResumeSpeed() 
    {       
        moveSpeed = 2.5f;        
    }

    

    private void OnEnable()
    {
        Actions.SpaceBarAction += MoveFaster;
        Actions.ResumeSpeed += ResumeSpeed; 
    }

    private void OnDisable()
    {
        Actions.MoveEvent -= UpdateMoveVector; 
        Actions.SpaceBarAction -= MoveFaster;
        Actions.ResumeSpeed -= ResumeSpeed; 
    }

    
}
