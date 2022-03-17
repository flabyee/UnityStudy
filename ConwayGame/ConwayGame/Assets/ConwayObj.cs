using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConwayObj : MonoBehaviour
{
    public bool isNowAlive = false;
    public bool isChecking = false;
    public bool isWillAlive = false;

    public bool isDebug = false;


    public SpriteRenderer sr;
    public BoxCollider2D myCollider;

    Color hideColor = new Color(0, 0, 0, 0);
    Color showColor = new Color(1, 1, 1, 1);
    int count = 0;

    public void Check()
    {
        //Debug.Log("check");

        Collider2D[] collider2DArray = Physics2D.OverlapBoxAll(transform.position + (Vector3)myCollider.offset, myCollider.size, 0);

        count = 0;

        foreach(Collider2D item in collider2DArray)
        {
            if(item.GetComponent<ConwayObj>().isNowAlive)
            {
                count++;
            }
        }

        if(isNowAlive)
        {
            count--;    // 자기자신은 빼준다
        }

        if(isDebug)
        {
            Debug.Log("인접한 갯수 : " + count.ToString());
        }

        if(isNowAlive)
        {
            if(count == 2 || count == 3)
            {
                isWillAlive = true;
            }
            else
            {
                isWillAlive = false;
            }
        }
        else
        {
            if(count == 3)
            {
                isWillAlive = true;
            }
            else
            {
                isWillAlive = false;
            }
        }

        isChecking = true;
    }

    public void Change()
    {
        if(isChecking)
        {
            if(isWillAlive)
            {
                isNowAlive = true;

                sr.color = showColor;
            }
            else
            {
                isNowAlive = false;

                sr.color = hideColor;
            }
        }
        else
        {
            Debug.LogError("not checking");
        }

        isChecking = false;
    }

    private void OnMouseDown()
    {
        if(isNowAlive)
        {
            sr.color = hideColor;
        }
        else
        {
            sr.color = showColor;
        }

        isNowAlive = !isNowAlive;
    }
}
