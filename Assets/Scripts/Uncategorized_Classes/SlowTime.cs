using UnityEngine;
using System.Collections;

public class SlowTime : MonoBehaviour
{

    private float _slowAmount = 0.5f;
    private float _slowDuration = .25f;
    private float _originalTime = 1.0f;

    private void OnEnable()
    {
        Player.OnPlayerHit += SlowTheTime;
    }

    private void SlowTheTime()
    {
        StartCoroutine(SlowTimeDuration());
    }

    private IEnumerator SlowTimeDuration()
    {
        Time.timeScale = _slowAmount;
        yield return new WaitForSeconds(_slowDuration);
        Time.timeScale = _originalTime;
    }

    private void OnDisable()
    {
        Player.OnPlayerHit -= SlowTheTime;
    }
}
