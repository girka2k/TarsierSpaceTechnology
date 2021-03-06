﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TarsierSpaceTech
{

    class Utils
    {
        public static void print(object message)
        {
#if DEBUG
            KSPLog.print("[TST]: " + message);
#endif
        }

        public static Transform FindChildRecursive(Transform parent, string name)
        {
            return parent.gameObject.GetComponentsInChildren<Transform>().FirstOrDefault(t => t.name == name);
        }

        public static double GetAvailableResource(Part part, String resourceName)
        {
            var resources = new List<PartResource>();
            part.GetConnectedResources(PartResourceLibrary.Instance.GetDefinition(resourceName).id, ResourceFlowMode.ALL_VESSEL, resources);
            double total = 0;
            foreach (PartResource pr in resources)
            {
                total += pr.amount;
            }
            return total;
        }

        public static Camera findCameraByName(string camera)
        {
            foreach (Camera cam in Camera.allCameras)
                if (cam.name == camera)
                    return cam;
            return null;
        }

        public static IEnumerator WaitForAnimation(Animation animation, string name)
        {
            do
            {
                yield return null;
            } while (animation.IsPlaying(name));
        }
    }
}