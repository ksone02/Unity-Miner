using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameObject player;
    public GameObject mainCamera;
    public float MoveSpeed = 0.1f;
    public float ZoomSpeed = 2.0f;

    private Camera thisCamera;

    void Start()
    {
        mainCamera.transform.position = new Vector3(0, 0, -10);
        thisCamera = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);

        Vector3 cameraPosition = mainCamera.transform.position;
        //Lerp(현재좌표, 목표좌표, 속도) -> 부드럽게 목표 좌표로 이동
        cameraPosition.x = Mathf.Lerp(transform.position.x, target.x, MoveSpeed);
        cameraPosition.y = Mathf.Lerp(transform.position.y, target.y, MoveSpeed);
        mainCamera.transform.position = cameraPosition;
    }
    void Update()
    {
        float scroll = -Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
        if (thisCamera.fieldOfView >= 120 && scroll > 0)
        {
            thisCamera.fieldOfView = 120;
        }
        else if (thisCamera.fieldOfView <= 40 && scroll < 0)
        {
            thisCamera.fieldOfView = 40;
        }
        else
        {
            thisCamera.fieldOfView += scroll;
        }
    }
}