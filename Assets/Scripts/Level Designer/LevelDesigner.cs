using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Diagnostics.Tracing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    [System.Serializable]
    public class StoneSet
    {
        public GameObject brickPrefab;
        public Color32 color;

    }
    public List<StoneSet> brickList = new List<StoneSet>();
    public SCR_Level level;
    [Header("Start Position")]
   public Vector2 startPosition;
   [Header("Margin")]
    public float distanceX=2;
    public float distanceY=2;
    [Header("Odd Offset")]
    public bool offsetOddRow;
    public int counter=0;
   // public float distanceY=2;
    public float offset=1;
    
    void Start()
    {
        CreateLevel();
    }
    
    void CreateLevel()
    {
        if(level == null)
        {
            return ;
        }
        for (int i = 0; i < level.rows.Length; i++)
        {
            for (int j = 0; j < level.rows[i].columns.Length; j++)
            {
                float xDist = (i%2 == 1 && offsetOddRow) ? j*distanceX + offset: j*distanceX;
                Vector3 pos = new Vector3(startPosition.x + xDist , startPosition.y + i*-distanceY);

                if(level.rows[i].columns[j]!=0)
                {
                     int number=level.rows[i].columns[j];
                     
                     GameObject newBrick = Instantiate(brickList[number-1].brickPrefab,pos,Quaternion.identity);
                     newBrick.GetComponent<MeshRenderer>().material.color=brickList[number-1].color;
                     counter++;
                }
            }
        }
    }
    
    void OnDrawGizmos()
    {
        if(level!=null)
        {
            for (int i = 0; i < level.gridSize.y; i++)
            {
                for (int j = 0; j < level.gridSize.x; j++)
                {
                    float xDist = (i%2 == 1 && offsetOddRow) ? j*distanceX + offset: j*distanceX;
                    Vector3 pos = new Vector3(startPosition.x + xDist , startPosition.y + i*-distanceY);
                    Gizmos.DrawWireCube(pos, new Vector3(2,1,1));

                }
            }
        }
    }
}
