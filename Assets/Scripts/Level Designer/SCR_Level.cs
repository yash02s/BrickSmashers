using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Level" , menuName = "Bricks/Create Level")]
public class SCR_Level : ScriptableObject
{
    // Start is called before the first frame update
    public Vector2Int gridSize;
    public LevelSetup[] rows;

    [System.Serializable]
    public class LevelSetup
    {
        public int[] columns;
    }
}
