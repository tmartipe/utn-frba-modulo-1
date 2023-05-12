using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum HeartState
{
    Empty,
    Half,
    Full
}

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    public List<Sprite> heartSprites;
    public List<Image> heartIcons;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateHeartIcons(int playerLife)
    {
        switch (playerLife)
        {
            case 6:
                heartIcons.ForEach(icon => icon.sprite = heartSprites[(int)HeartState.Full]);
                break;
            case 5:
                heartIcons[0].sprite = heartSprites[(int)HeartState.Full];
                heartIcons[1].sprite = heartSprites[(int)HeartState.Full];
                heartIcons[2].sprite = heartSprites[(int)HeartState.Half];
                break;
            case 4:
                heartIcons[0].sprite = heartSprites[(int)HeartState.Full];
                heartIcons[1].sprite = heartSprites[(int)HeartState.Full];
                heartIcons[2].sprite = heartSprites[(int)HeartState.Empty];
                break;
            case 3:
                heartIcons[0].sprite = heartSprites[(int)HeartState.Full];
                heartIcons[1].sprite = heartSprites[(int)HeartState.Half];
                heartIcons[2].sprite = heartSprites[(int)HeartState.Empty];
                break;
            case 2:
                heartIcons[0].sprite = heartSprites[(int)HeartState.Full];
                heartIcons[1].sprite = heartSprites[(int)HeartState.Empty];
                heartIcons[2].sprite = heartSprites[(int)HeartState.Empty];
                break;
            case 1:
                heartIcons[0].sprite = heartSprites[(int)HeartState.Half];
                heartIcons[1].sprite = heartSprites[(int)HeartState.Empty];
                heartIcons[2].sprite = heartSprites[(int)HeartState.Empty];
                break;
            case 0:
                heartIcons.ForEach(icon => icon.sprite = heartSprites[(int)HeartState.Empty]);
                break;
        }
    }
}