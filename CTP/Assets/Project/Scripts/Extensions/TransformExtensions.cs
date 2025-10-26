using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RedPanda.Project.Scripts.Extensions
{
    public static class TransformExtensions
    {
        public static void ResetLocalZ(this Transform transorm)
        {
            var localPosition = transorm.localPosition;
            localPosition.z = 0;
            transorm.localPosition = localPosition;
        }

        public static void ResetLocalPosition(this Transform transorm)
        {
            transorm.localPosition = Vector3.zero;
        }

        public static void ResetLocalRotation(this Transform transorm)
        {
            transorm.localRotation = Quaternion.identity;
        }

        public static void ResetLocalScale(this Transform transorm)
        {
            transorm.localScale = Vector3.one;
        }
    }
}