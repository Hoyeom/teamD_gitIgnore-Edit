using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float xInput; // �¿� �Է� �޾ƿ��� ����
    private float zInput; // �յ� �Է� �޾ƿ��� ����

    private MovementCharacterController movement = null;     // MovementCharacterController ��ũ��Ʈ�� moveTo �Լ��� ����ϱ� ���� movement��� �̸����� �޾ƿ´�.
    private RotateToMouse rotateToMouse = null;              // ĳ���� �þ� ȸ�� ��ũ��Ʈ�� �޾ƿ´�. 
    private Animator animator = null;                        // �ִϸ��̼� �Ķ���� ������ ���� Animator�� �޾ƿ´�.
    private CharacterController characterCtrl = null;        // ĳ���� ��Ʈ�ѷ��� �ݶ��̴��� ������ٵ� ������ ��������Ƿ� �ҷ��´�.


    private void Awake()
    {
        Cursor.visible = true;                                       // ���콺 Ŀ���� ������ �ʰ� �Ѵ�. ���� false�� �ٲ㼭 �Ⱥ��̰� �� ����
        Cursor.lockState = CursorLockMode.Locked;                    // ���콺 Ŀ���� ���� ��ġ�� ���� ��Ų��.

        rotateToMouse = GetComponent<RotateToMouse>();               //��ũ��Ʈ�� �޾ƿ´�.
        movement = GetComponent<MovementCharacterController>();      //��ũ��Ʈ�� �޾ƿ´�.
        animator = GetComponent<Animator>();                         //��ũ��Ʈ�� �޾ƿ´�.
        characterCtrl = GetComponent<CharacterController>();         //��ũ��Ʈ�� �޾ƿ´�.
    }

    private void Update()
    {
        UpdateRotate();
        UpdateMove();
        isGrounded();
    }

    private void UpdateRotate() // ĳ���� �þ� ȸ��
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }

    private void UpdateMove() // ĳ���� ������
    {
        movement.MoveTo(new Vector3(xInput, 0, zInput));
    }

    private void Jump(InputAction.CallbackContext context)   // ��ǲ �ý��� ����
    {
        if (context.started)
        {                                                   // isJumping�� false�� ��쿡�� && ���� �������� �ִϸ��̼� State�� Jumping�϶���
            if (!animator.GetBool("isJumping") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jumping"))
            {
                movement.Jump();                            // ����
                animator.SetBool("isJumping", true);        // ������ �� isJumping = true
            }
        }
    }

    private void Move(InputAction.CallbackContext context)   // ��ǲ �ý��� ����
    {
        // �̵� �Է°� �ޱ�
        Vector2 input = context.ReadValue<Vector2>();       // �Է°��� �޾Ƽ� ȸ�� ������ �̵� ������ �޾ƿ�
        xInput = input.x;
        zInput = input.y;
        movement.MoveTo(new Vector3(xInput, 0, zInput));

        // �ִϸ��̼� ����
        if (context.started)
            animator.SetBool("isRunning", true);            // ������ �� isRunning = true
        else if (context.canceled)
            animator.SetBool("isRunning", false);           // ������ �� isRunning = false
    }

    public void Walk(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetBool("isWalking", true);
            movement.applySpeed = movement.walkSpeed;
        }

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            movement.applySpeed = movement.runSpeed;
        }
    }
    private void Sliding(InputAction.CallbackContext context)
    {

    }
    public void isGrounded()
    {
        if (characterCtrl.isGrounded)
            animator.SetBool("isJumping", false);
        #region ĳ���� ��Ʈ�ѷ� isGrounded �Ⱦ���
        //Vector3 origin = characterCtrl.bounds.center;       // ray ������ġ
        //Vector3 direction = Vector3.down;                   // ray ����
        //Ray ray = new Ray(origin, direction);               // ���ο� ray �����

        //RaycastHit rayHit;                                  // hitinfo. �浹ü ������ �޾ƿ� ���� �����
        //float radius = 0.15f;                               // ray�� ���� �߻��� Sphere(��)�� ������. ĳ���� �ݶ��̴����� ���� �� �۰� �ߴ�.(ĳ���� : 0.2)
        //Physics.SphereCast(ray, radius, out rayHit);        // ray�� ����, radius ũ���� Sphere�� �߻��ϰ�, rayHit�� �浹ü ������ �����Ѵ�.

        //if (characterCtrl.velocity.y < 0)                   // ĳ���Ͱ� �Ʒ��� �������� ���� ��
        //{
        //    if (rayHit.collider != null)                    // ray�� ���� ����� ��� 
        //    {
        //        if (rayHit.distance < 0.8f)                 // ray�� �浹ü ������ �Ÿ��� 0.8���� ª�� ��� isJumping = false
        //            animator.SetBool("isJumping", false);
        //    }
        //}
        #endregion
    }
}
