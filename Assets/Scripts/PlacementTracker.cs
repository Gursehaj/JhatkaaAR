using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlacementTracker : MonoBehaviour
    {
        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        GameObject tracker;
        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
        [SerializeField]
        GameObject lake;
        [SerializeField]
        GameObject city;
        Vector3 anchorPos;
        bool placed = false;

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
            tracker = Instantiate(Resources.Load<GameObject>("PlacementTracker"));
            tracker.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
            tracker.SetActive(false);
        }

        void Update()
        {
            if (isTrackerPlaced())
            {
                if (Input.touchCount > 0)
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        if (PlayerPrefs.GetInt("city") == 0)
                            Instantiate(lake, new Vector3(0, 0, anchorPos.z), Quaternion.identity);
                        else
                            Instantiate(city, new Vector3(0, 0, anchorPos.z), Quaternion.identity);
                        placed = true;
                        m_RaycastManager.subsystem.Stop();
                        Destroy(tracker);
                    }
            }
        }

        bool isTrackerPlaced()
        {
            if (!placed)
            {
                if (m_RaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), s_Hits, TrackableType.Planes))
                {
                    // Raycast hits are sorted by distance, so the first one
                    // will be the closest hit.
                    var hitPose = s_Hits[0].pose;
                    {
                        anchorPos = hitPose.position;
                        if (!tracker.activeInHierarchy)
                            tracker.SetActive(true);
                        tracker.transform.position = anchorPos;
                    }
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

    }
}