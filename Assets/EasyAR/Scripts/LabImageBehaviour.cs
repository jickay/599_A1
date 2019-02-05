using UnityEngine;
using EasyAR;

namespace LabApp
{
    public class LabImageBehaviour : ImageTargetBehaviour
    {


        // The target (cylinder) position.
        public GameObject target;
        public GameObject target2;
        public GameObject target3;

        public GameObject currentTarget;


        protected override void Awake()
        {
            base.Awake();
            TargetFound += OnTargetFound;
            TargetLost += OnTargetLost;
            TargetLoad += OnTargetLoad;
            TargetUnload += OnTargetUnload;
        }

        void OnTargetFound(TargetAbstractBehaviour behaviour)
        {
            Debug.Log("Found: " + Target.Id);

            target = GameObject.Find("Wall1");
            target2 = GameObject.Find("Wall2");
            target3 = GameObject.Find("Wall3");

            currentTarget = target;

            Debug.Log("Target position: " + currentTarget.transform.position);
        }

        void OnTargetLost(TargetAbstractBehaviour behaviour)
        {
            Debug.Log("Lost: " + Target.Id);
        }

        void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
            Debug.Log("Load target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
        }

        void OnTargetUnload(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
            Debug.Log("Unload target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
        }
    }
}