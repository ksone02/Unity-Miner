using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed = 1;

    private Rigidbody2D rigidBody;
    private Vector2 vector;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // 벽 충돌 시 떨림현상 방지를 위해 이동은 FixedUpdate에서 처리.
    void FixedUpdate()
    {
        PlayerMoveWASD();
        RotateMouseAngle();
    }

    void PlayerMoveWASD()
    {
        vector.x = Input.GetAxisRaw("Horizontal");
        vector.y = Input.GetAxisRaw("Vertical");

        rigidBody.velocity = vector * speed;
    }

    void RotateMouseAngle()
    {
        Vector3 mPosition = Input.mousePosition;
        Vector3 oPosition = transform.position;

        mPosition.z = oPosition.z - Camera.main.transform.position.z;

        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;

        float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
    }

}
