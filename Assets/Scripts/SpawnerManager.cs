using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] prefabs = new GameObject[4];     // 4 prefabs
    public Button[] colorButtons = new Button[4];        // 4 botones de color
    public Button[] spriteButtons = new Button[4];       // 4 botones para elegir sprite

    private Color currentColor = Color.white;
    private int currentPrefabIndex = 0;

    private Vector2 startPos;
    private Vector2 direction;
    private bool directionChosen;

    void Start()
    {
        // Asignar listeners a cada botón de color
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i;
            colorButtons[i].onClick.AddListener(() =>
            {
                currentColor = colorButtons[index].GetComponent<Image>().color;
            });
        }

        // Asignar listeners a cada botón de sprite
        for (int i = 0; i < spriteButtons.Length; i++)
        {
            int index = i;
            spriteButtons[i].onClick.AddListener(() =>
            {
                currentPrefabIndex = index;
            });
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                case TouchPhase.Ended:
                    directionChosen = true;
                    if (direction.magnitude < 10f)
                    {
                        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                        worldPos.z = 0f;

                        GameObject spawned = Instantiate(prefabs[currentPrefabIndex], worldPos, Quaternion.identity);
                        SpriteRenderer sr = spawned.GetComponent<SpriteRenderer>();
                        if (sr != null)
                        {
                            sr.color = currentColor;
                        }
                    }
                    break;
            }
        }
    }
}