using Unity.Collections;
using Unity.Mathematics;

/// <summary>
/// Rope kinematic simulation
/// </summary>
public class PSimulator
{
    public NativeArray<float3> prevPositions;
    public NativeArray<float3> nowPositions;
    public NativeArray<float3> nextPositions;

    public float3 G = new float3(0.0f, 9.81f, 0.0f); // gravity

    public void Step(float dt)
    {
        
    }

    public void ComplateJob()
    {
        
    }
}