using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] GameObject block;
    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    // Update is called once per frame
    void Generation()
    {
        for (float x = 0; x < width; x++)
        {
            for (float y = 0; y < height; y++)
            {
                if (!(x < 11 && x > 4 && y < 11 && y > 4))
                {
                    Instantiate(block, new Vector2(x - 7.5f, y - 7.5f), Quaternion.identity);
                }
            }
        }
    }
}
