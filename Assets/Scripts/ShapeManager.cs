using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public Color currentColor = Color.white;
    public int currentPrefabIndex = 0;

    public GameObject GetShapeAtPosition(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapPoint(position);
        return (hit != null && hit.CompareTag("Shape")) ? hit.gameObject : null;
    }

    public void MoveShape(GameObject shape, Vector3 newPosition)
    {
        shape.transform.position = newPosition;
    }

    public void CreateShape(Vector3 position)
    {
        GameObject spawned = Instantiate(prefabs[currentPrefabIndex], position, Quaternion.identity);
        spawned.tag = "Shape";
        SpriteRenderer sr = spawned.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = currentColor;
        }
    }

    public void DeleteShapeAtPosition(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapPoint(position);
        if (hit != null && hit.CompareTag("Shape"))
        {
            Destroy(hit.gameObject);
        }
    }

    public void DeleteAllShapes()
    {
        GameObject[] shapes = GameObject.FindGameObjectsWithTag("Shape");
        for (int i = 0; i < shapes.Length; i++)
        {
            Destroy(shapes[i]);
        }
    }
}