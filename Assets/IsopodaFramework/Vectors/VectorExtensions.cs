using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsopodaFramework.Vectors
{


    public static class VectorExtensions
    {
        public static Vector3 XYPlane(this Vector3 vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }
        
        public static Vector3 XZPlane(this Vector3 vector)
        {
            return new Vector3(vector.x, 0, vector.z);
        }
        
        public static Vector3 YZPlane(this Vector3 vector)
        {
            return new Vector3(0, vector.y, vector.z);
        }
        
        public static Vector3 XPlane(this Vector3 vector)
        {
            return new Vector3(vector.x, 0, 0);
        }
        
        public static Vector3 YPlane(this Vector3 vector)
        {
            return new Vector3(0, vector.y, 0);
        }
        
        public static Vector3 ZPlane(this Vector3 vector)
        {
            return new Vector3(0, 0, vector.z);
        }
    }
}
