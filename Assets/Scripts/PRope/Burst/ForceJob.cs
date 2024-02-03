using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace PRope.Burst
{
    /// <summary>
    /// apply force to detect next position by VARLET integral
    /// </summary>
    [BurstCompile]
    public struct ForceJob : IJobFor
    {
        // position
        [ReadOnly] public NativeArray<float3> prevPositions;
        [ReadOnly] public NativeArray<float3> nowPositions;
        [WriteOnly] public NativeArray<float3> nextPositions;

        // mass
        [ReadOnly] public NativeArray<float> mass;
        
        // force
        [ReadOnly] public NativeArray<float3> localForce;
        [ReadOnly] public float3 gravity;     
        [ReadOnly] public float3 globalForce;   
        
        // physic
        [ReadOnly] public float damping;
        [ReadOnly] public float dt;
        [ReadOnly] public int iterator;
        
        public void Execute(int index)
        {
            // final force
            var force = gravity + globalForce + localForce[index];
            nextPositions[index] = nowPositions[index] +
                                   (1 - damping) * (nowPositions[index] - prevPositions[index]) +
                                   force / mass[index] * (dt * dt) * iterator;
        }
    }
}