using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    private Entity entity;
    float moveSpeed;
    private void Awake()
    {
        entity = GetComponent<Entity>();
    }
    void Start()
    {
        moveSpeed = entity.GetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -1 * moveSpeed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}
