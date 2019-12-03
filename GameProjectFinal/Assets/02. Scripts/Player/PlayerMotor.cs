using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;

    public float moveSpeed;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private bool isGameStart;


    ////////////////////////////////////////////////////////////////////////////////////
    // 애니메이션 관련 변수
    ////////////////////////////////////////////////////////////////////////////////////
    // 플레이어 애니메이터
    private Animator playerAnim;
    // 플레이어 애니메이터 컨트롤러에서 파라미터의 해시값 추출
    private readonly int hasStart = Animator.StringToHash("isStart");
    private readonly int hasEnd = Animator.StringToHash("isEnd");

    //플레이어 죽음알림
    public delegate void InformCharacterDieHandler();
    public static event InformCharacterDieHandler informDie;

    //플레이어 점수획득알림
    public delegate void InformCharacterUpHandler();
    public static event InformCharacterUpHandler informUp;


    new private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }



    // Start is called before the first frame update
    void Start()
    {
        IngameController.informGoal += EndRunning;

        controller = GetComponent<CharacterController>();
        moveSpeed = 3;
    }

    // Update is called once per frame

    IEnumerator CharacterMove()
    {
        if (!isGameStart)
        {
            yield break;
        }
            while (isGameStart)
            {
                    moveVector = Vector3.zero;

                    if (controller.isGrounded)
                    {
                        verticalVelocity = -0.5f;
                    }
                    else
                    {
                        verticalVelocity -= gravity * Time.deltaTime;
                    }

                    moveVector.x = Input.GetAxisRaw("Horizontal");

                    moveVector.z = moveSpeed;
                    controller.Move(moveVector * Time.deltaTime * moveSpeed);

                    yield return null;
            }
    }

    public void StartRunning()
    {
        isGameStart = true;

        playerAnim.SetBool("isStart", true);
        StartCoroutine(CharacterMove());
    }

    public void EndRunning()
    {
        isGameStart = false;
        playerAnim.SetBool("isEnd", true);
        playerAnim.SetBool("isStart", false);

        SoundManager.Instance.PlayStop();

        Main.Instance.ShowFadeOutPanel();
        StartCoroutine(IngameFadeOut_suc());
    }

    private IEnumerator IngameFadeOut_suc()
    {
        yield return StartCoroutine(ImageFadeOut.Instance.PlayFadeOut());

        Main.Instance.OnEnd_suc();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "beer" ||
            hit.gameObject.tag == "clip" ||
            hit.gameObject.tag == "phone")
        {
            isGameStart = false;

            informDie();
        }
        else if (hit.gameObject.tag == "money")
        {
            Destroy(hit.gameObject);
            informUp();
        }
    }

}
