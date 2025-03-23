using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public ShapeManager shapeManager;
    public TrailManager trailManager;

    private Vector2 startPos;
    private Vector2 direction;
    private GameObject draggedObject = null;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
            worldPos.z = 0f;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    draggedObject = shapeManager.GetShapeAtPosition(worldPos);
                    if (draggedObject == null)
                    {
                        trailManager.StartTrail(worldPos);
                    }
                    break;

                case TouchPhase.Moved:
                    if (draggedObject != null)
                    {
                        shapeManager.MoveShape(draggedObject, worldPos);
                    }
                    else
                    {
                        trailManager.UpdateTrail(worldPos);
                    }
                    direction = touch.position - startPos;
                    break;

                case TouchPhase.Ended:
                    if (draggedObject == null && direction.magnitude > 150f)
                    {
                        shapeManager.DeleteAllShapes();
                    }
                    else if (touch.tapCount == 2)
                    {
                        shapeManager.DeleteShapeAtPosition(worldPos);
                    }
                    else if (direction.magnitude < 10f && draggedObject == null)
                    {
                        shapeManager.CreateShape(worldPos);
                    }

                    trailManager.EndTrail();
                    draggedObject = null;
                    direction = Vector2.zero;
                    break;
            }
        }
    }
}