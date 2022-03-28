public interface IPhysicsLawHandler
{
    void OnLawsUpdate(Law[] newLaws);
    Law MyLaw { get; }
}