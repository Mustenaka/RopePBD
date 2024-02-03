using Unity.Jobs;

namespace PRope.Burst
{
    public struct DistanceInfo
    {
        public int l;
        public int r;
    }
    
    public struct DistanceConstraintJob : IJobFor
    {
        public void Execute(int index)
        {
            
        }
    }
}