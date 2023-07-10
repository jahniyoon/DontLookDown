using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigid;
    public float speed = 5f;
    public float rotationSpeed = 5f;

    bool wDown;

    // animator 선언
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

        // 주어진 축에 입력값을 반환. ex. Horizontal 축의 입력값을 받아와 xInput 함수에 할당
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        wDown = Input.GetButton("Walk");


        // Left Shift를 누르면 walk
        float playerSpeed = speed;
        if (wDown) { playerSpeed = speed * 0.4f; }

        // xInput에 저장된 입력값 * 속도로 xSpeed 변수에 할당
       
            float xSpeed = xInput * playerSpeed;
            float zSpeed = zInput * playerSpeed;
        


        //new Vector3을 활용하여 플레이어의 이동속도를 나타내는 벡터를 생성
        //xSpeed값을 x축으로 zSpeed값을 z축으로, y는 0으로 설정
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        // playerRigid는  Rigidbody 컴포넌트를 가진 플레이어 오브젝트를 가르키는 변수.
        //playerRigid.velocity는 플레이어의 현재 속도를 나타내는 속성.
        //속성에 위에서 만든 벡터를 할당함으로써 플레이어를 움직이게 한다.
        playerRigid.velocity = newVelocity;


        // 플레이어 회전하는 함수.
        //Vector3 direction = new Vector3(xInput, 0f, zSpeed);
        //if (direction.magnitude > 0.1f)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        //}

        transform.LookAt(transform.position + newVelocity);

       

        // 애니메이션 발동 함수
        animation.SetBool("isRun", newVelocity != Vector3.zero);
        animation.SetBool("isWalk", wDown);

    }
}
