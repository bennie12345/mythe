using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashingScreen : MonoBehaviour {

    [SerializeField]private float fadeSpeed;
    private Color startingColor;
    private bool fade = false;
    [SerializeField]private Image flashingImage;
    private Color red;

    void Start () {
        red = flashingImage.color;
        startingColor = Color.clear;
        flashingImage.color = startingColor;
    }
	
	void Update () {
        FadeToClear();
	}

    void FadeToClear()
    {
        if (fade == true && flashingImage.color != startingColor)
        {
            flashingImage.color = Color.Lerp(flashingImage.color, Color.clear, fadeSpeed * Time.deltaTime);
        }

        if(flashingImage.color == startingColor)
        {
            fade = false;
        }
    }

    public void StartFade()
    {
        flashingImage.color = red;
        fade = true;
    }
}
