using UnityEngine;

public class GeneralContext : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _startContext;
    private static MonoBehaviour _context;

    private void Awake()
    {
        if (_startContext == null)
        {
            Debug.LogError("You don't have a GeneralContext (GeneralContext is null)");
        }

        _context = _startContext;
    }

    public static MonoBehaviour Context
    {
        get
        {
            return _context;
        }
    }
}
