using System.Linq;
using UnityEngine;

public abstract class PhysicsLawHandler : MonoBehaviour, IPhysicsLawHandler 
{
    public virtual Law MyLaw => Law.None;

    private bool? enabledNow = null;

    public void OnLawsUpdate(Law[] newLaws)
    {
        if (newLaws.ToList().Contains(MyLaw) && (!enabledNow.HasValue || !enabledNow.Value))
        {
            enabledNow = true;
            EnableLaw();
        }
        if (!newLaws.ToList().Contains(MyLaw) && (!enabledNow.HasValue || enabledNow.Value))
        {
            enabledNow = false;
            DisableLaw();
        }
    }
    protected virtual void EnableLaw()
    {

    }
    protected virtual void DisableLaw()
    {

    }
    protected void Start()
    {
        LawsController.instance.lawsUpdated.AddListener(OnLawsUpdate);
    }
}
