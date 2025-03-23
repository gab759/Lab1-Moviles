using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public ShapeManager shapeManager;
    public TrailManager trailManager;

    public Button[] colorButtons;
    public Button[] spriteButtons;

    void Start()
    {
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i;
            colorButtons[i].onClick.AddListener(() =>
            {
                shapeManager.currentColor = colorButtons[index].GetComponent<Image>().color;
                trailManager.currentColor = colorButtons[index].GetComponent<Image>().color;
            });
        }

        for (int i = 0; i < spriteButtons.Length; i++)
        {
            int index = i;
            spriteButtons[i].onClick.AddListener(() =>
            {
                shapeManager.currentPrefabIndex = index;
            });
        }
    }
}