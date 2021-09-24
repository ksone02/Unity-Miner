using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameObject player;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        //Lerp(현재좌표, 목표좌표, 속도) -> 부드럽게 목표 좌표로 이동
        transform.position = Vector3.Lerp(transform.position, target, speed);
    }
}
