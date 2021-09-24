using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int speed = 1;

    void Start()
    {

    }

    // 벽 충돌 시 떨림현상 방지를 위해 이동은 FixedUpdate에서 처리.
    void FixedUpdate()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.smoothDeltaTime;
        float yMove = Input.GetAxis("Vertical") * speed * Time.smoothDeltaTime;
        transform.Translate(xMove, yMove, 0);
    }
}
