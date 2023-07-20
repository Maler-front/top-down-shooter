using System.Collections;

public class StandartReload : WeaponReloader
{
    public StandartReload(UnityEngine.UI.Button fireButton, float timeToReload = 3f) : base(fireButton, timeToReload) { }

    protected override IEnumerator Reloading()
    {
        _fireButton.interactable = false;

        while(NeedToUpdateTime())
        {
            _fireButton.image.fillAmount = 1 - _remainingTime / _timeToReload;
            yield return null;
        }

        _fireButton.interactable = true;
        _reloadCoroutine = null;
    }
}
