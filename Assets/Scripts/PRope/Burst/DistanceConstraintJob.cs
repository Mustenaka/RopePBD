using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace PRope.Burst
{
    public struct DistanceInfo
    {
        public int l;
        public int r;
        public float offset;

        public DistanceInfo(int l, int r, float offset)
        {
            this.l = l;
            this.r = r;
            this.offset = offset;
        }
    }

    /// <summary>
    /// correct nextPosition by distance constraint
    /// </summary>
    public struct DistanceConstraintJob : IJobFor
    {
        [ReadOnly] public NativeArray<DistanceInfo> infos;
        [NativeDisableUnsafePtrRestriction] public NativeArray<float3> nextPositions;

        [ReadOnly] public float restLength;
        [ReadOnly] public float stiffness;

        public void Execute(int index)
        {
            var con = infos[index];

            var delta = nextPositions[con.l] - nextPositions[con.r];
            float currentDistance = math.length(delta);
            float error = currentDistance - restLength;

            if (currentDistance > Mathf.Epsilon)
            {
                // correct offset
                float3 correction = math.normalize(delta) * (error * stiffness);

                // apply
                nextPositions[con.l] -= correction;
                nextPositions[con.r] += correction;
            }
        }
    }
}