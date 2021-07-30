using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TractorState { Move, Stop };


public class TraktorMovement : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;

    [SerializeField] private float speed;
    [SerializeField] private GameObject senoPrefab;
    [SerializeField] private float fireRate; 
    private float nextFire;
    private float unnextFire;

    [SerializeField] private Transform senoManager;
    private Transform spawnPoint;
    
    //private bool isMove;
    private float direction;
    private TractorState tractorState = TractorState.Stop;

    // ������� ������� UnityEvent
    [SerializeField] public UnityEvent shootEvent;

    [SerializeField] private Animator animator; // ������� ������ �� ��������� ��������

    // pool 
    [SerializeField] private int senoPoolSize; // ������ ��������(�����) ���������� � ������� ������ ������ �������(spawn object)
    private List<GameObject> senos; //������ ������� ��������
    private int currentSenoIndex;  // ������� �������� ����


    private void Awake()
    {
        spawnPoint = transform.GetChild(1);

        if (animator == null)
        {
            animator = transform.GetChild(0).GetComponent<Animator>();
        }

        // �������������� ������
        senos = new List<GameObject>(senoPoolSize);
    }


    void Update()
    {
        MoveTractor();
        // nextFire -= Time.deltaTime;
    }

    private void Start()
    {
        for (int i = 0; i < senoPoolSize; i++)
        {
            // ��������� � ������ �������
            senos.Add(Instantiate(senoPrefab)); // Instantiate() ������� ������� ������ ��������
            senos[i].transform.SetParent(senoManager); // �������� � ���������
            senos[i].SetActive(false); // ���������
        }
    }

    private void MoveTractor()
    {
        if (tractorState == TractorState.Move)
        {
            if (((transform.position.x <= 22) && (direction == 1f)) || ((transform.position.x >= -22) && (direction == -1f)))
            {
                transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
                soundManager.PlayMotor();
                animator.SetInteger("Direction", (int)direction);
                animator.SetBool("IsMove", true);


                // �� �������� �� �������� ��� �� ������� ���������� ��������, �� �������� ������������ IdelAnimation
            }
        }
    }

    public void MoveRight() //��������� �������
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
        animator.SetBool("IsMove", false);
    }

    // ������ ������ FIRE
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
            //GameObject seno = Instantiate(this.senoPrefab, spawnPoint.position, this.senoPrefab.transform.rotation); // ������ ��������
            //seno.transform.SetParent(senoManager);
            //Destroy(seno, 10f);

            senos[currentSenoIndex].transform.position = spawnPoint.position; // ������� ������(pool) �������
            senos[currentSenoIndex].SetActive(true); // ����������

            currentSenoIndex++;
            if(currentSenoIndex >= senoPoolSize)
            {
                currentSenoIndex = 0;
            }

            soundManager.PlayShootClip();
            shootEvent.Invoke();
            animator.SetTrigger("Fire");
        }

        //else if (nextFire > 1)
        //{
        //    GameObject seno = Instantiate(this.seno, spawnPoint.position, this.seno.transform.rotation); // ������ ��������
        //    seno.transform.SetParent(senoManager);
        //    Destroy(seno, 10f);
        //    nextFire = fireRate;
        //}
    }

}
