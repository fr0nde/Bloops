using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private BoxCollider2D bc2d;

    // Start is called before the first frame update
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
    }

    //public void setPosition(int x, int y)
    //{
    //    bc2d.transform.Translate(x, y, 1);
    //}

}
