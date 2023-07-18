using System.Collections;
using UnityEngine;

public class LaserAnimation
{
    private float _timeToFadeAway;

    [SerializeField] private LineRenderer _lineRenderer;

    public LaserAnimation(GameObject laserPrefab, Vector2 startPoint, Vector2 endPoint, float timeTofade = 0.5f)
    {
        if (!laserPrefab.TryGetComponent<LineRenderer>(out _lineRenderer))
            Debug.LogError("There is no LineRenderer in laserPrefab");
        _lineRenderer.SetPositions(new Vector3[] { startPoint, endPoint });

        _timeToFadeAway = timeTofade;

        GeneralContext.Context.StartCoroutine(FadeAway());
    }

    private IEnumerator FadeAway()
    {
        float timeRemaining = _timeToFadeAway;
        while(timeRemaining > 0f)
        {
            _lineRenderer.widthMultiplier = timeRemaining / _timeToFadeAway;
            timeRemaining -= Time.fixedDeltaTime;
            yield return null;
        }

        _lineRenderer.widthMultiplier = 0f;
        GameObject.Destroy(_lineRenderer.gameObject, 3f);
    }
}
