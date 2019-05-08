/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class DefaultTrackableEventHandlerfirstPage : MonoBehaviour, ITrackableEventHandler
{
  
    public GameObject bar;
    public GameObject giraffe;
    float timer = 0;
    bool found = true;
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        PlayerPrefs.SetInt("effect", 0);
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }
    protected virtual void Update()
    {
        timer += Time.deltaTime * 0.1f;
        if (timer > 0.5f)
        {
            bar.SetActive(true);
            print("aaa");
        }
        if (timer > 0.8f)
        {
            giraffe.SetActive(true);

        }
    }
    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        PlayerPrefs.SetInt("effect", 1);
        //var rendererComponents = GetComponentsInChildren<Renderer>(true);
        //var colliderComponents = GetComponentsInChildren<Collider>(true);
        //var canvasComponents = GetComponentsInChildren<Canvas>(true);

        //// Enable rendering:
        //foreach (var component in rendererComponents)
        //    component.enabled = true;

        //// Enable colliders:
        //foreach (var component in colliderComponents)
        //    component.enabled = true;

        //// Enable canvas':
        //foreach (var component in canvasComponents)
        //    component.enabled = true;

        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(true);
           
            bar.SetActive(false);
            giraffe.SetActive(false);
        }

        //var rendererComponents = GetComponentsInChildren<Renderer>(true);
        //var colliderComponents = GetComponentsInChildren<Collider>(true);
        //var canvasComponents = GetComponentsInChildren<Canvas>(true);

        //// Enable rendering:
        //foreach (var component in rendererComponents)
        //    component.enabled = true;

        //// Enable colliders:
        //foreach (var component in colliderComponents)
        //    component.enabled = true;

        //// Enable canvas':
        //foreach (var component in canvasComponents)
        //    component.enabled = true;

    }


    protected virtual void OnTrackingLost()
    {
        PlayerPrefs.SetInt("effect", 0);
        //var rendererComponents = GetComponentsInChildren<Renderer>(true);
        //var colliderComponents = GetComponentsInChildren<Collider>(true);
        //var canvasComponents = GetComponentsInChildren<Canvas>(true);

        //// Disable rendering:
        //foreach (var component in rendererComponents)
        //    component.enabled = false;

        //// Disable colliders:
        //foreach (var component in colliderComponents)
        //    component.enabled = false;

        //// Disable canvas':
        //foreach (var component in canvasComponents)
        //    component.enabled = false;

        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(false);
        }

        //var rendererComponents = GetComponentsInChildren<Renderer>(true);
        //var colliderComponents = GetComponentsInChildren<Collider>(true);
        //var canvasComponents = GetComponentsInChildren<Canvas>(true);

        //// Disable rendering:
        //foreach (var component in rendererComponents)
        //    component.enabled = false;

        //// Disable colliders:
        //foreach (var component in colliderComponents)
        //    component.enabled = false;

        //// Disable canvas':
        //foreach (var component in canvasComponents)
        //    component.enabled = false;

    }

    #endregion // PROTECTED_METHODS
}
