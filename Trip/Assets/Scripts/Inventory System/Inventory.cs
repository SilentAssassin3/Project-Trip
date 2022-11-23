using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        if (parent)
        {
            transform.SetParent(parent, false);
        }
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }


    public Inventory(int width, int height, float cellSize, Vector2 centerSystemAt)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        Vector2 orgin = centerSystemAt;
        orgin.x -= width * cellSize / 2;
        
        orgin.y -= height * cellSize / 2;
        gridArray = new int[width, height];
        Debug.Log(orgin);
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                CreateWorldText(null,gridArray[x, y].ToString(), new Vector2(orgin.x + ((x+.5f)*cellSize),orgin.y + ((y + .5f) * cellSize)), 20, Color.white, TextAnchor.MiddleCenter, 0, 5000);
            }
        }
    }

}