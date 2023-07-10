using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigid;
    public float speed = 5f;
    public float rotationSpeed = 5f;

    bool wDown;

    // animator ����
    Animator animation;



    // Start is called before the first frame update
    void Awake()
    {

        playerRigid = GetComponent<Rigidbody>();
        animation = GetComponentInChildren<Animator>();

    }



    // Update is called once per frame
    void Update()
    {

        // �־��� �࿡ �Է°��� ��ȯ. ex. Horizontal ���� �Է°��� �޾ƿ� xInput �Լ��� �Ҵ�
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        wDown = Input.GetButton("Walk");


        // Left Shift�� ������ walk
        float playerSpeed = speed;
        if (wDown) { playerSpeed = speed * 0.4f; }

        // xInput�� ����� �Է°� * �ӵ��� xSpeed ������ �Ҵ�
       
            float xSpeed = xInput * playerSpeed;
            float zSpeed = zInput * playerSpeed;
        


        //new Vector3�� Ȱ���Ͽ� �÷��̾��� �̵��ӵ��� ��Ÿ���� ���͸� ����
        //xSpeed���� x������ zSpeed���� z������, y�� 0���� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        // playerRigid��  Rigidbody ������Ʈ�� ���� �÷��̾� ������Ʈ�� ����Ű�� ����.
        //playerRigid.velocity�� �÷��̾��� ���� �ӵ��� ��Ÿ���� �Ӽ�.
        //�Ӽ��� ������ ���� ���͸� �Ҵ������ν� �÷��̾ �����̰� �Ѵ�.
        playerRigid.velocity = newVelocity;


        // �÷��̾� ȸ���ϴ� �Լ�.
        //Vector3 direction = new Vector3(xInput, 0f, zSpeed);
        //if (direction.magnitude > 0.1f)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        //}

        transform.LookAt(transform.position + newVelocity);

       

        // �ִϸ��̼� �ߵ� �Լ�
        animation.SetBool("isRun", newVelocity != Vector3.zero);
        animation.SetBool("isWalk", wDown);

    }
}
