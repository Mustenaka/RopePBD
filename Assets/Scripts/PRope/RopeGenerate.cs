using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace PRope
{
    public class RopeGenerate
    {
        // input
        private readonly Transform _origin;
        private readonly int _cnt;
        private readonly Vector3 _dir;
        private readonly float _step;

        // output
        private NativeArray<float3> _positions;
        private readonly List<GameObject> _nodes;

        /// <summary>
        /// generate particle for rope
        /// </summary>
        /// <param name="origin">origin position</param>
        /// <param name="cnt">the count of particle</param>
        public RopeGenerate(Transform origin, int cnt)
        {
            _positions = new NativeArray<float3>(cnt, Allocator.Persistent);
            _nodes = new List<GameObject>();
            this._origin = origin;
            this._cnt = cnt;
            this._dir = new Vector3(1.0f, 0.0f, 0.0f);
            this._step = 1.2f;
        }

        /// <summary>
        /// generate particle for rope
        /// </summary>
        /// <param name="origin">origin position</param>
        /// <param name="cnt">the count of particle</param>
        /// <param name="dir">the generate way</param>
        public RopeGenerate(Transform origin, int cnt, Vector3 dir)
        {
            _positions = new NativeArray<float3>(cnt, Allocator.Persistent);
            _nodes = new List<GameObject>();
            this._origin = origin;
            this._cnt = cnt;
            this._dir = dir;
            this._step = 1.2f;
        }

        /// <summary>
        /// generate particle for rope
        /// </summary>
        /// <param name="origin">origin position</param>
        /// <param name="cnt">the count of particle</param>
        /// <param name="dir">the generate way</param>
        /// <param name="step">the generate step</param>
        public RopeGenerate(Transform origin, int cnt, Vector3 dir, float step)
        {
            _positions = new NativeArray<float3>(cnt, Allocator.Persistent);
            _nodes = new List<GameObject>();
            this._origin = origin;
            this._cnt = cnt;
            this._dir = dir;
            this._step = step;
        }

        // public static unsafe void CopyToFast<T>(NativeSlice<T> nativeSlice,
        //     T[] array)
        //     where T : struct
        // {        
        //     if (array == null)
        //     {
        //         throw new NullReferenceException(nameof(array) + " is null");
        //     }          
        //     int nativeArrayLength = nativeSlice.Length;
        //     if (array.Length < nativeArrayLength)
        //     {
        //         throw new IndexOutOfRangeException(
        //             nameof(array) + " is shorter than " + nameof(nativeSlice));
        //     }
        //     int byteLength = nativeSlice.Length * UnsafeUtility.SizeOf<T>();
        //     void* managedBuffer = UnsafeUtility.AddressOf(ref array[0]);
        //     void* nativeBuffer = nativeSlice.GetUnsafePtr();
        //     UnsafeUtility.MemCpy(managedBuffer, nativeBuffer, byteLength);
        // }

        /// <summary>
        /// Get Native Position
        /// </summary>
        /// <returns></returns>
        public NativeArray<float3> GetPositions()
        {
            return new NativeArray<float3>(_positions, Allocator.Persistent);
        }

        /// <summary>
        /// Generate rope particles
        /// </summary>
        /// <returns></returns>
        public List<GameObject> Generate()
        {
            for (int i = 0; i < _cnt; i++)
            {
                var position = _origin.position + i * _step * _dir;
                var go = CreateGameObject(_origin, i.ToString(), position);

                _nodes.Add(go);
                _positions[i] = position;
            }

            return _nodes;
        }

        /// <summary>
        /// one particle object
        /// </summary>
        /// <returns></returns>
        private GameObject CreateGameObject(Transform father, string name, Vector3 position)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            go.transform.position = position;
            go.name = name;
            go.transform.parent = father;

            return go;
        }
    }
}