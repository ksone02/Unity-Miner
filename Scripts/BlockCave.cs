using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCave : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    private RaycastHit2D rayHit;
    private GameObject target;
    private SpriteRenderer sr;

    public float time = 3f;
    private float timeSpan;

    public GameObject pointer;
    private GameObject newPoint;

    private bool distanceOk;

    Animator anim;

    public GameObject dropBlock;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        distanceOk = false;
    }

    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= 1.5)
        {
            distanceOk = true;
            if (Input.GetMouseButton(0))
            {
                Vector2 touchPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                rayHit = Physics2D.Raycast(touchPos, mainCamera.transform.forward);
                CastRay();

                if (target == this.gameObject)
                {
                    timeSpan += Time.deltaTime;
                    anim.SetBool("isClick", true);

                    if (timeSpan > time)
                    {
                        timeSpan = 0;
                        DropBlock();
                        if (newPoint)
                        {
                            Destroy(newPoint);
                        }
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    timeSpan = 0;
                    anim.SetBool("isClick", false);
                }
            }
            else
            {
                timeSpan = 0;
                anim.SetBool("isClick", false);
            }

        }
        else
        {
            distanceOk = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            timeSpan = 0;
            anim.SetBool("isClick", false);
        }
    }

    void CastRay()
    {
        if (rayHit.collider != null)
        {
            target = rayHit.collider.gameObject;
        }
    }

    void OnMouseEnter()
    {
        if (distanceOk)
        {
            Vector3 pointerPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
            newPoint = Instantiate(pointer, pointerPosition, Quaternion.identity) as GameObject;
        }
    }

    void OnMouseExit()
    {
        Destroy(newPoint);
    }

    void DropBlock()
    {
        int random = Random.Range(0, 360);
        var r = Quaternion.Euler(0f, 0f, random);
        GameObject drBlock = Instantiate(dropBlock, this.gameObject.transform.position, r) as GameObject;
    }
}
