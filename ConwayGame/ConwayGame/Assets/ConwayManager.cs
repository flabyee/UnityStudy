using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConwayManager : MonoBehaviour
{
    public List<ConwayObj> conwayObjList = new List<ConwayObj>();
    public GameObject conwayObjPrefab;

    public int width;
    public int height;

    private bool isRoof = false;

    private void Start()
    {
        CreateConwayObj();

        StartCoroutine(Roof());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isRoof = !isRoof;
        }

    }

    IEnumerator Roof()
    {
        while(true)
        {
            if(isRoof)
            {
                foreach (ConwayObj item in conwayObjList)
                {
                    item.Check();
                }

                foreach (ConwayObj item in conwayObjList)
                {
                    item.Change();
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void CreateConwayObj()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                conwayObjList.Add(Instantiate(conwayObjPrefab, new Vector2(i * 1f, j * 1f), Quaternion.identity).GetComponent<ConwayObj>());
            }
        }
    }
}
