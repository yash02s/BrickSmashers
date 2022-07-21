using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(SCR_Level))]
public class SCR_LevelEditor : Editor
{
    // GRID
    int cellWidth = 32;
    int cellHeight = 16;
    int margin = 5;
    Rect rect;

    SerializedObject level;
    SerializedProperty gridSize;
    SerializedProperty rows;
  
    Vector2Int newGridSize ;
    Vector2 cellSize;

    bool wrongSize;
    bool gridChanged;
    
    void OnEnable()
    {
        level = new SerializedObject(target);
        gridSize = level.FindProperty("gridSize");
        rows = level.FindProperty("rows");

        newGridSize = gridSize.vector2IntValue;
        cellSize = new Vector2(cellWidth,cellHeight);
    }
    public override void OnInspectorGUI()
    {
   
    level.Update();
    
    EditorGUILayout.BeginHorizontal();
    {
      EditorGUI.BeginChangeCheck();
      newGridSize = EditorGUILayout.Vector2IntField("Grid Size",newGridSize);

      wrongSize = (newGridSize.x<=0 || newGridSize.y<=0);
      gridChanged = (newGridSize!=gridSize.vector2IntValue);

      GUI.enabled = gridChanged && !wrongSize;
      if(GUILayout.Button("Apply",EditorStyles.miniButton))
      {
           CreateGridCells(newGridSize);
      }
      GUI.enabled= true;
    }
    EditorGUILayout.EndHorizontal();

    if(wrongSize)
    {
        EditorGUILayout.HelpBox("Values have to be higher than 0",MessageType.Error);
    }
    EditorGUILayout.Space();
    if(Event.current.type == EventType.Repaint)
    {
        rect=GUILayoutUtility.GetLastRect();
    }
    DisplayGrid(rect);
    level.ApplyModifiedProperties();
    
   // DrawDefaultInspector();
    
    }

    void CreateGridCells(Vector2Int newSize)
    {
            rows.ClearArray();
            for(int i=0;i<newSize.y;i++)
            {
                rows.InsertArrayElementAtIndex(i);
                SerializedProperty col = GetRowAt(i);
                col.arraySize = 0;
                for(int j=0;j<newSize.x;j++)
                {
                   col.InsertArrayElementAtIndex(j);
                }
            }
            gridSize.vector2IntValue = newGridSize;
    }
/* SerializedProperty GetRowAt(int index)
    {
        return rows.GetArrayElementAtIndex(index).FindPropertyRelative("columns");
    }*/
    void DisplayGrid(Rect start){
        Rect cellPos = start;
        cellPos.y += 10;
        cellPos.size = cellSize;
        float startX= cellPos.x;
        for (int i = 0; i < gridSize.vector2IntValue.y; i++)
        {
            SerializedProperty col =GetRowAt(i);
            cellPos.x=startX;
            for (int j = 0; j < gridSize.vector2IntValue.x; j++)
            {
                EditorGUI.PropertyField(cellPos,col.GetArrayElementAtIndex(j),GUIContent.none);
                cellPos.x +=cellSize.x + margin;
            }
            cellPos.y+=cellSize.y + margin;
            GUILayout.Space(cellSize.y + margin);
        }
    }
    SerializedProperty GetRowAt(int index)
    {
        return rows.GetArrayElementAtIndex(index).FindPropertyRelative("columns");
    }

}
