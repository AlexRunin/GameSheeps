using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraktorMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    private float direction;

    private bool isMove;
   
    void Start()
    {
        
    }


    void Update()
    {
        // Двигаем наш объект
        //if ((transform.position.x <= 22) && (direction == 1f))
        //{
        //    transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
        //}
        //else if ((transform.position.x >= -22) && (direction == -1f))
        //{
        //    transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
        //}

        if (isMove == true) 
        {
            if (((transform.position.x <= 22) && (direction == 1f)) || ((transform.position.x >= -22) && (direction == -1f)))
            { 
                transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
            }          
        } 
    }

    public void MoveRight() //обработка событий
    {
        direction = 1f;
        isMove = true;
    }
    public void MoveLeft()
    {
        direction = -1f;
        isMove = true;
    }
    public void StopeMove()
    {
        //direction = 0f;
        isMove = false;
    }

}
