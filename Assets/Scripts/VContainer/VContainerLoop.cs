
using UnityEngine;
using VContainer.Unity;

public class VContainerLoop : IInitializable, IPostInitializable,
    IFixedTickable, IPostFixedTickable,
    ITickable, IPostTickable,
    ILateTickable, IPostLateTickable
{

    public void Initialize()
    {
   
    }
    public void PostInitialize()
    {
        
    }
    public void FixedTick()
    {
        
    }

    public void Tick()
    {
       
    }

    public void PostTick()
    {
      
    }
    public void PostFixedTick()
    {
       
    }

    public void LateTick()
    {
       
    }

    public void PostLateTick()
    {
       
    }
}
