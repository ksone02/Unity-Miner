using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
    public GameObject blockGameObject;
    public GameObject player;

    private int worldSizeX = 16;
    private int worldSizeY = 16;

    private Vector2 startPosition;

    private Hashtable blockContainer = new Hashtable();
    private List<Vector2> blockPositions = new List<Vector2>();

    void Start()
    {
        for (int x = -16; x <= 16; x += 16)
        {
            for (int y = -16; y <= 16; y += 16)
            {
                Vector3 startPos = new Vector3(x, y, 1);

                GameObject startBlock = Instantiate(blockGameObject, startPos, Quaternion.identity) as GameObject;
                blockContainer.Add(startPos, startBlock);
                blockPositions.Add(startBlock.transform.position);
                startBlock.transform.SetParent(this.transform);
            }
        }
    }

    void Update()
    {
        if (Mathf.Abs(xPlayerMove) >= 8 || Mathf.Abs(yPlayerMove) >= 8)
        {
            for (int x = -worldSizeX; x <= worldSizeX; x += 16)
            {
                for (int y = -worldSizeY; y <= worldSizeY; y += 16)
                {
                    Vector3 pos = new Vector3(x * 1 + xPlayerLocation, y * 1 + yPlayerLocation, 1);

                    if (!blockContainer.ContainsKey(pos))
                    {
                        GameObject block = Instantiate(blockGameObject, pos, Quaternion.identity) as GameObject;
                        blockContainer.Add(pos, block);
                        blockPositions.Add(block.transform.position);
                        block.transform.SetParent(this.transform);
                    }
                }
            }
        }
    }

    public int xPlayerMove
    {
        get
        {
            return (int)(player.transform.position.x - startPosition.x);
        }
    }

    public int yPlayerMove
    {
        get
        {
            return (int)(player.transform.position.y - startPosition.y);
        }
    }

    private int xPlayerLocation
    {
        get
        {
            int playerPositionX = (int)Mathf.Floor(player.transform.position.x);
            int n = 8;
            int loop = 1;
            while (true)
            {
                if (n - 16 < playerPositionX && playerPositionX < n)
                {
                    return n - 8;
                }
                else if (playerPositionX >= n)
                {
                    n += 16;
                    if (loop++ > 100)
                    {
                        return 0;
                    }
                }
                else if (playerPositionX <= n - 16)
                {
                    n -= 16;
                    if (loop++ > 100)
                    {
                        return 0;
                    }
                }
            }
        }
    }

    private int yPlayerLocation
    {
        get
        {
            int playerPositionY = (int)Mathf.Floor(player.transform.position.y);
            int n = 8;
            int loop = 0;
            while (true)
            {
                if (n - 16 < playerPositionY && playerPositionY < n)
                {
                    return n - 8;
                }
                else if (playerPositionY >= n)
                {
                    n += 16;
                    if (loop++ > 100)
                    {
                        return 0;
                    }
                }
                else if (playerPositionY <= n - 16)
                {
                    n -= 16;
                    if (loop++ > 100)
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
