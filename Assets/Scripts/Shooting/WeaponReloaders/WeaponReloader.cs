using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class WeaponReloader 
{
    protected Coroutine _reloadCoroutine;
    protected Button _fireButton;
    protected float _timeToReload;
    protected float _remainingTime;

    public WeaponReloader(Button fireButton, float timeToReload = 3f)
    {
        _fireButton = fireButton;
        _timeToReload = timeToReload;
    }

    public bool Reload()
    {
        if(_reloadCoroutine == null)
        {
            StartReload();
            return true;
        }
        else 
        {
            return false;
        }
    }

    protected bool NeedToUpdateTime()
    {
        _remainingTime -= Time.deltaTime;
        return _remainingTime > 0f;
    }

    protected void StartReload()
    {
        _remainingTime = _timeToReload;
        GeneralContext.Context.StartCoroutine(Reloading());
    }

    protected abstract IEnumerator Reloading();
}
