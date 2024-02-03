﻿using Unity.Collections;
using Unity.Mathematics;

namespace PRope
{
    /// <summary>
    /// Rope kinematic simulation
    /// </summary>
    public class PSimulator
    {
        public NativeArray<float3> originPositions;
        public NativeArray<float3> prevPositions;
        public NativeArray<float3> nowPositions;
        public NativeArray<float3> nextPositions;

        public float3 gravity = new float3(0.0f, 9.81f, 0.0f);
        public float3 globalForce = new float3(0, 0, 0);
        public NativeArray<float3> localForce;
    
        public NativeArray<float> mass;

        public int iterator;
        public float damping;
        public float stiffness;
    
        public void Step(float dt)
        {
        
        }   

        public void ComplateJob()
        {
        
        }
    }
}