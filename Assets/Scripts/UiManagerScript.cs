using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManagerScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _liveSprites;

    [SerializeField]
    private Image _livesImage;

    public void updateLives(int currentLives)
    {
        _livesImage.sprite = _liveSprites[currentLives];
    }
}
