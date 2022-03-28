using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LawsController : MonoBehaviour
{
    public static LawsController instance;

    public List<Law> inScene;
    public List<Law> enabledLaws;

    public UnityEvent<Law[]> lawsUpdated;

    public bool CanContinue { get => enabledLaws.Count == 3; }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lawsUpdated.Invoke(enabledLaws.ToArray());
    }

    public void EnableLaw(Law law)
    {
        if (!enabledLaws.Contains(law))
        {
            enabledLaws.Add(law);
        }
        lawsUpdated.Invoke(enabledLaws.ToArray());
    }
    public void DisableLaw(Law law)
    {
        if (enabledLaws.Contains(law))
        {
            enabledLaws.Remove(law);
        }
        lawsUpdated.Invoke(enabledLaws.ToArray());
    }
}
