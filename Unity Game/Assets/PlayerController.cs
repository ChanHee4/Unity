using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //**�����̴� �ӵ�
    private float Speed;

    //**�������� �����ϴ� ����
    private Vector3 Movement;

    //**�÷��̾��� animator ������Ҹ� �޾ƿ�������....
    public Animator animator;

    //**�÷��̾��� spriteRenderer ������Ҹ� �޾ƿ��� ����...
    private SpriteRenderer playerRenderer;

    //**[����üũ]
    private bool onAttack; //���ݻ���
    private bool onHit; //�ǰݻ���
    private bool onJump; 
    private bool onRoll;

    //**������ �Ѿ� ����
    public GameObject BulletPrefab;

    //**������ �Ѿ��� �������.
    private List<GameObject> Bullets = new List<GameObject>();


    //**�÷��̾ ���������� �ٶ� ����
    private float Direction;

    private void Awake()
    {
        //**player�� Animator�� �޾ƿ´�.
        animator = this.GetComponent<Animator>();

        //**player�� spriterenderer�� �޾ƿ´�
        playerRenderer = this.GetComponent<SpriteRenderer>();
    }

    //**����Ƽ �⺻ ���� �Լ�
    //**�ʱⰪ�� ������ �� ���
    void Start()
    {
        //**�ӵ��� �ʱ�ȭ
        Speed = 5.0f;

        //**�ʱⰪ ����
        onAttack = false;
        onHit = false;
        onJump = false;
        onRoll = false;
        Direction = 1.0f;        
    }

    //**����Ƽ �⺻ ���� �Լ�
    //**�����Ӹ��� �ݺ������� ����Ǵ� �Լ�
    void Update()
    {
        //**�Ǽ� ���� [IEEE754]

        //** Input.GetAxis = -1 ~ 1 ������ ���� ��ȯ��
        float Hor = Input.GetAxisRaw("Horizontal"); //-1 or 0 or 1 ���߿� �ϳ��� ��ȯ
        float Ver = Input.GetAxis("Vertical"); // -1 ~ 1 ���� �Ǽ��� ��ȯ.


        //** Hor�� 0�̶�� �����ִ� �����̹Ƿ� ���� ó��
        if (Hor != 0)
            Direction = Hor;

        //**�÷��̾ �ٶ󺸰��ִ� ���⿡ ���� �̹��� ���� ����
        if (Direction < 0)
        {
            playerRenderer.flipX = true;
        }
        else if (Direction > 0)
            playerRenderer.flipX = false;


        //**
        playerRenderer.flipX = (Hor < 0) ? true : false;

        //**�Է¹��� ������ �÷��̾ �����δ�
        Movement += new Vector3(
            Hor * Time.deltaTime * Speed,
            Ver * Time.deltaTime * Speed,
            0.0f);



        //**���� ��Ʈ��Ű�� �Է� �Ѵٸ�....
        if (Input.GetKey(KeyCode.LeftControl))
            OnAttack(); //**����

        //**���� ����ƮŰ�� �Է��Ѵٸ�.....
        if (Input.GetKey(KeyCode.LeftShift))
            OnHit(); //**�ǰ�

        //**�����̽��ٸ� �Է��Ѵٸ�.....
        if (Input.GetKey(KeyCode.Space))
            OnJump(); //**����

        if (Input.GetKey(KeyCode.CapsLock))
            OnRoll();

        //**z�� �Է��Ѵٸ�
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //**�Ѿ� ������ �����Ѵ�
            GameObject Obj = Instantiate(BulletPrefab);
            //Obj.transform.name = "";

            //**������ �Ѿ��� ��ġ�� ���� �÷��̾��� ��ġ�� �ʱ�ȭ�Ѵ�
            Obj.transform.position = transform.position;

            //**�Ѿ��� bullercontroller ��ũ��Ʈ�� �޾ƿ´�
            BullerController Controller = Obj.AddComponent<BullerController>();

            //**�Ѿ� ��ũ��Ʈ������ ���� ������ ���� �÷��̾��� ���⺯���� �����Ѵ�
            Controller.Direction = new Vector3(Hor, 0.0f, 0.0f);

            //**�Ѿ��� SpriteRenderer�� �޾ƿ´�
            SpriteRenderer bulletrenderer = Obj.GetComponent<SpriteRenderer>();

            //**�Ѿ��� �̹��� ���� ���¸� �÷��̾��� �̹��� �������·� �����Ѵ�
            bulletrenderer.flipY = playerRenderer.flipX;

            //**��� ������ ���� �Ǿ��ٸ� ����ҿ� �����Ѵ�
            Bullets.Add(Obj);
        }

        //**�÷��̾��� �����ӿ� ���� �̵� ����� �����Ѵ�
        animator.SetFloat("Speed", Hor);

        //**���� �÷��̾ �����δ�
        transform.position += Movement;
    }

    private void OnAttack()
    {
        //**�̹� ���ݸ���� �������̶��
        if (onAttack)
            //**�Լ��� �����Ų��
            return; 

        //**�Լ��� ������� �ʾҴٸ�
        //**���ݻ��¸� Ȱ��ȭ �ϰ� 
        onAttack = true;

        //**���� ����� �����Ѵ�
        animator.SetTrigger("Attack");
    }
    private void SetAttack()
    {
        //**�Լ��� ����Ǹ� ���ݸ���� ��Ȱ��ȭ �ȴ�
        //**�Լ��� �ִϸ��̼� Ŭ���� �̺�Ʈ���������� ���Ե�
        onAttack = false;
    }

    private void OnHit()
    {
        //**�̹� �ǰݸ���� �������̶��
        if (onHit)
            //**�Լ��� ����Ų��
            return;

        //**�Լ��� ������� �ʾҴٸ�
        //**�ǰݻ��¸� Ȱ��ȭ�ϰ�
        onHit = true;

        //**�ǰ� ����� �����Ѵ�
        animator.SetTrigger("Hit");

    }

    private void SetHit()
    {
        //**�Լ��� ����Ǹ� �ǰݸ���� ��Ȱ��ȭ �ȴ�
        //**�Լ��� �ִϸ��̼� Ŭ���� �̺�Ʈ���������� ���Ե�
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