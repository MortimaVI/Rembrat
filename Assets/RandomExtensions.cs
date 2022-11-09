using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public static class Toolbox
    {
        public static Vector3 Range(Vector3 minInclusive, Vector3 maxInclusive)
        {
            float x, y, z;
            x = UnityEngine.Random.Range(minInclusive.x, maxInclusive.x);
            y = UnityEngine.Random.Range(minInclusive.y, maxInclusive.y);
            z = UnityEngine.Random.Range(minInclusive.z, maxInclusive.z);
            return new Vector3(x, y, z);
        }
    }

