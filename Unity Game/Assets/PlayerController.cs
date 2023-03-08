using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //**움직이는 속도
    private float Speed;

    //**움직임을 저장하는 벡터
    private Vector3 Movement;

    //**플레이어의 animator 구성요소를 받아오기위해....
    public Animator animator;

    //**플레이어의 spriteRenderer 구성요소를 받아오기 위해...
    private SpriteRenderer playerRenderer;

    //**[상태체크]
    private bool onAttack; //공격상태
    private bool onHit; //피격상태
    private bool onJump; 
    private bool onRoll;

    //**복사할 총알 원본
    public GameObject BulletPrefab;

    //**복제된 총알의 저장공간.
    private List<GameObject> Bullets = new List<GameObject>();


    //**플레이어가 마지막으로 바라본 방향
    private float Direction;

    private void Awake()
    {
        //**player의 Animator를 받아온다.
        animator = this.GetComponent<Animator>();

        //**player의 spriterenderer를 받아온다
        playerRenderer = this.GetComponent<SpriteRenderer>();
    }

    //**유니티 기본 제공 함수
    //**초기값을 설정할 때 사용
    void Start()
    {
        //**속도를 초기화
        Speed = 5.0f;

        //**초기값 셋팅
        onAttack = false;
        onHit = false;
        onJump = false;
        onRoll = false;
        Direction = 1.0f;        
    }

    //**유니티 기본 제공 함수
    //**프레임마다 반복적으로 실행되는 함수
    void Update()
    {
        //**실수 연산 [IEEE754]

        //** Input.GetAxis = -1 ~ 1 사이의 값을 반환함
        float Hor = Input.GetAxisRaw("Horizontal"); //-1 or 0 or 1 셋중에 하나를 반환
        float Ver = Input.GetAxis("Vertical"); // -1 ~ 1 까지 실수로 반환.


        //** Hor이 0이라면 멈춰있는 상태이므로 예외 처리
        if (Hor != 0)
            Direction = Hor;

        //**플레이어가 바라보고있는 방향에 따라 이미지 반전 설정
        if (Direction < 0)
        {
            playerRenderer.flipX = true;
        }
        else if (Direction > 0)
            playerRenderer.flipX = false;


        //**
        playerRenderer.flipX = (Hor < 0) ? true : false;

        //**입력받은 값으로 플레이어를 움직인다
        Movement += new Vector3(
            Hor * Time.deltaTime * Speed,
            Ver * Time.deltaTime * Speed,
            0.0f);



        //**좌측 컨트롤키를 입력 한다면....
        if (Input.GetKey(KeyCode.LeftControl))
            OnAttack(); //**공격

        //**좌측 시프트키를 입력한다면.....
        if (Input.GetKey(KeyCode.LeftShift))
            OnHit(); //**피격

        //**스페이스바를 입력한다면.....
        if (Input.GetKey(KeyCode.Space))
            OnJump(); //**점프

        if (Input.GetKey(KeyCode.CapsLock))
            OnRoll();

        //**z를 입력한다면
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //**총알 원본을 복제한다
            GameObject Obj = Instantiate(BulletPrefab);
            //Obj.transform.name = "";

            //**복제된 총알의 위치를 현재 플레이어의 위치로 초기화한다
            Obj.transform.position = transform.position;

            //**총알의 bullercontroller 스크립트를 받아온다
            BullerController Controller = Obj.AddComponent<BullerController>();

            //**총알 스크립트내부의 방향 변수를 현재 플레이어의 방향변수로 설정한다
            Controller.Direction = new Vector3(Hor, 0.0f, 0.0f);

            //**총알의 SpriteRenderer를 받아온다
            SpriteRenderer bulletrenderer = Obj.GetComponent<SpriteRenderer>();

            //**총알의 이미지 반전 상태를 플레이어의 이미지 반전상태로 설정한다
            bulletrenderer.flipY = playerRenderer.flipX;

            //**모든 설정이 종료 되었다면 저장소에 보관한다
            Bullets.Add(Obj);
        }

        //**플레이어의 움직임에 따라 이동 모션을 실행한다
        animator.SetFloat("Speed", Hor);

        //**실제 플레이어를 움직인다
        transform.position += Movement;
    }

    private void OnAttack()
    {
        //**이미 공격모션이 진행중이라면
        if (onAttack)
            //**함수를 종료시킨다
            return; 

        //**함수가 종료되지 않았다면
        //**공격상태를 활성화 하고 
        onAttack = true;

        //**공격 모션을 실행한다
        animator.SetTrigger("Attack");
    }
    private void SetAttack()
    {
        //**함수가 실행되면 공격모션이 비활성화 된다
        //**함수는 애니메이션 클립의 이벤트프레임으로 삽입됨
        onAttack = false;
    }

    private void OnHit()
    {
        //**이미 피격모션이 진행중이라면
        if (onHit)
            //**함수를 종료킨다
            return;

        //**함수가 종료되지 않았다면
        //**피격상태를 활성화하고
        onHit = true;

        //**피격 모션을 실행한다
        animator.SetTrigger("Hit");

    }

    private void SetHit()
    {
        //**함수가 실행되면 피격모션이 비활성화 된다
        //**함수는 애니메이션 클립의 이벤트프레임으로 삽입됨
        onHit = false;
    }

    private void OnJump() 
    {
        if (onJump)
            return;

        onJump = true;
        animator.SetTrigger("Jump");
    }

    private void SetJump()
    {
        onJump = false;
    }

    private void OnRoll()
    {
        if (onRoll)
            return;

        onRoll = true;
        animator.SetTrigger("Roll");
    }

    private void SetRoll()
    {
        onRoll = false;
    }


}