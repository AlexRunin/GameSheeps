using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TractorState { Move, Stop };


public class TraktorMovement : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;

    [SerializeField] private float speed;
    [SerializeField] private GameObject seno;
    [SerializeField] private float fireRate; 
    private float nextFire;
    private float unnextFire;

    [SerializeField] private Transform senoManager;
    private Transform spawnPoint;
    
    //private bool isMove;
    private float direction;
    private TractorState tractorState = TractorState.Stop;


    private void Awake()
    {
        spawnPoint = transform.GetChild(1);
    }


    void Update()
    {

        MoveTractor();
        // nextFire -= Time.deltaTime;
    }

    private void MoveTractor()
    {
        if (tractorState == TractorState.Move)
        {
            if (((transform.position.x <= 22) && (direction == 1f)) || ((transform.position.x >= -22) && (direction == -1f)))
            {
                transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
                soundManager.PlayMotor();
            }
        }
    }

    public void MoveRight() //обработка событий
    {
        direction = 1f;
        //isMove = true;
        tractorState = TractorState.Move;
        soundManager.PlayArrow();
    }
    public void MoveLeft()
    {
        direction = -1f;
        //isMove = true;
        tractorState = TractorState.Move;
        soundManager.PlayArrow();
    }
    public void StopeMove()
    {
        //direction = 0f;
        //isMove = false;
        tractorState = TractorState.Stop;
    }

    // Делаем кнопку FIRE
    //public void Fire(string message)
    //{
    //    //Debug.Log("Fire");
    //    Debug.Log(message);
    //}
    public void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject seno = Instantiate(this.seno, spawnPoint.position, this.seno.transform.rotation); // Объект создался
            seno.transform.SetParent(senoManager);
            Destroy(seno, 10f);
            soundManager.PlayShootClip();
            //nextFire = fireRate;
        }

        //else if (nextFire > 1)
        //{
        //    GameObject seno = Instantiate(this.seno, spawnPoint.position, this.seno.transform.rotation); // Объект создался
        //    seno.transform.SetParent(senoManager);
        //    Destroy(seno, 10f);
        //    nextFire = fireRate;
        //}
    }

}
