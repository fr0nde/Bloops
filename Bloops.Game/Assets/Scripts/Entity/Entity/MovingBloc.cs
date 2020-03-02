using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBloc : MonoBehaviour
{
    private BoxCollider2D movingBloc;
    private int sens = 0;

    // Start is called before the first frame update
    void Start()
    {
        movingBloc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = movingBloc.transform.position.x;
        if (sens == 0)
        {
            x = x + 0.1f;
            if (x > 12)
            {
                sens = 1;
            }
        } else
        {
            x = x - 0.1f;
            if (x < -12)
            {
                sens = 0;
            }
        }

        movingBloc.transform.position = new Vector3(x, movingBloc.transform.position.y);
    }
}
