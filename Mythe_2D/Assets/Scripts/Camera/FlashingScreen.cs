using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashingScreen : MonoBehaviour
{
    //shows a bloody screen when the player is hit
    [SerializeField]private float _fadeSpeed = 5;
    [SerializeField]private float _fadeDuration = 1.5f;
    private Color _startingColor;
    private bool _fade = false;
    [SerializeField]private Image _flashingImage;
    private Color _red;

    private void OnEnable()
    {
        Player.OnPlayerHit += StartFade;
        _red = _flashingImage.color;
        _startingColor = Color.clear;
        _flashingImage.color = _startingColor;
    }

    private void Update()
    {
        FadeToClear();
    }

    private void FadeToClear()
    {
        if (_fade == true && _flashingImage.color != _startingColor)
        {
            StartCoroutine(FadeCoroutine());
        }
    }

    public void StartFade()
    {
        _flashingImage.color = _red;
        _fade = true;
    }

    private IEnumerator FadeCoroutine()
    {
        _flashingImage.color = Color.Lerp(_flashingImage.color, Color.clear, _fadeSpeed * Time.deltaTime);
        yield return new WaitForSeconds(_fadeDuration);
        _fade = false;
    }

    private void OnDisable()
    {
        Player.OnPlayerHit -= StartFade;
    }
}
