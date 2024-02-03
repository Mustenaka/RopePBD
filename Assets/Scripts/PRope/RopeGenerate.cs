using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace PRope
{
    public class RopeGenerate
    {
        // input
        public GameObject node;
        public int cnt;
        public Vector3 dir;
        public float step;

        // output
        public NativeArray<float3> positions;
        public List<GameObject> nodes;
        
        /// <summary>
        /// generate particle for rope
        /// </summary>
        public RopeGenerate()
        {
            positions = new NativeArray<float3>(cnt, Allocator.Persistent);
            nodes = new List<GameObject>();
        }
        
        /// <summary>
        /// generate particle for rope
        /// </summary>
        /// <param name="cnt">the count of particle</param>
        public RopeGenerate(int cnt)
        {
            positions = new NativeArray<float3>(cnt, Allocator.Persistent);
            nodes = new List<GameObject>();
            this.cnt = cnt;
            this.dir = new Vector3(1.0f, 0.0f, 0.0f);
            this.step = 1.2f;
        }

        /// <summary>
        /// generate particle for rope
        /// </summary>
        /// <param name="cnt">the count of particle</param>
        /// <param name="dir">the generate way</param>
        public RopeGenerate(int cnt, Vector3 dir)
        {
            positions = new NativeArray<float3>(cnt, Allocator.Persistent);
            nodes = new List<GameObject>();
            this.cnt = cnt;
            this.dir = dir;
            this.step = 1.2f;
        }

        /// <summary>
        /// generate particle for rope
        /// </summary>
        /// <param name="cnt">the count of particle</param>
        /// <param name="dir">the generate way</param>
        /// <param name="step">the generate step</param>
        public RopeGenerate(int cnt, Vector3 dir, float step)
        {
            positions = new NativeArray<float3>(cnt, Allocator.Persistent);
            nodes = new List<GameObject>();
            this.cnt = cnt;
            this.dir = dir;
            this.step = step;
        }

        public void Generate()
        {
            
        }
    }
}