using UnityEngine;
using Vuforia;

public class DefaultObserverEventHandler : MonoBehaviour
{
    protected ObserverBehaviour mObserverBehaviour;

    protected virtual void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnObserverStatusChanged;
        }
    }

    protected virtual void OnDestroy()
    {
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged -= OnObserverStatusChanged;
        }
    }

    protected virtual void OnObserverStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (targetStatus.Status == Status.TRACKED ||
            targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    protected virtual void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        foreach (var component in rendererComponents)
            component.enabled = true;

        foreach (var component in colliderComponents)
            component.enabled = true;

        Debug.Log(" OnTrackingFound triggered!");

        //  This is the missing connection
        GetComponent<CustomImageTargetResponse>()?.OnImageFound();
    }

    protected virtual void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        foreach (var component in rendererComponents)
            component.enabled = false;

        foreach (var component in colliderComponents)
            component.enabled = false;

        Debug.Log(" OnTrackingLost");
    }
}
