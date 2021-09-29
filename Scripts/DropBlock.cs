using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlock : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private GameObject player;

    private bool isDrop;

    private float time = 0.5f;
    private float timeSpan = 0;

    private float dir1;
    private float dir2;

    [SerializeField]
    private Inventory theInventory;  // 📜Inventory.cs

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        isDrop = true;

        dir1 = gameObject.transform.position.x + Random.Range(-0.4f, 0.4f);
        dir2 = gameObject.transform.position.y + Random.Range(-0.4f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        moveRandom();
        if (isDrop == false)
        {
            moveToPlayer();
        }
    }

    void moveRandom()
    {
        timeSpan += Time.deltaTime;
        if (isDrop == true)
        {
            Vector3 randPos = new Vector3(dir1, dir2, 0.5f);

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, randPos, 0.1f);
        }

        if (timeSpan > time)
        {
            isDrop = false;
        }

    }

    void moveToPlayer()
    {
        var dis = Vector2.Distance(gameObject.transform.position, player.transform.position);
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, 0.5f);
        if (dis <= 1.5 && dis > 0.5)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, playerPosition, 0.1f);
        }
        else if (dis <= 0.5)
        {
            CanPickUp();
            Destroy(this.gameObject);
        }
    }

    private void CanPickUp()
    {
        if (gameObject.transform)
        {
            theInventory = GameObject.FindObjectOfType<Inventory>();
            Debug.Log(gameObject.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 했습니다.");
            theInventory.AcquireItem(gameObject.transform.GetComponent<ItemPickUp>().item);
        }
    }
}
