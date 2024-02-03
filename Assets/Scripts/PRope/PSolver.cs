using System.Collections.Generic;
using PRope;
using UnityEngine;

/// <summary>
/// PBD solver
/// </summary>
public class PSolver : MonoBehaviour
{
    // particle 
    public List<GameObject> particles;

    // rope generate
    public int particleCount = 128;
    private RopeGenerate _generate;

    // simlator param
    private PSimulator _ropeSimulator;
    public float dt = 0.001f;
    public float accTime = 0.0f;
    public int iterator = 10;

    private void Awake()
    {
        _generate = new RopeGenerate(this.transform, particleCount);
        _ropeSimulator = new PSimulator();
    }

    private void Start()
    {
        particles = _generate.Generate();
        _ropeSimulator.nowPositions = _generate.GetPositions();
    }

    private void Update()
    {
        accTime += Time.deltaTime;
        int cnt = (int)(accTime / dt);

        for (int i = 0; i < cnt; i++)
        {
            if (_ropeSimulator != null)
            {
                _ropeSimulator.Step(dt);

                // prepare for next 
                if (i < cnt - 1)
                {
                    _ropeSimulator.ComplateJob();
                }
            }
        }

        accTime %= dt;
    }

    private void LateUpdate()
    {
        // last frame
        if (_ropeSimulator != null)
        {
            _ropeSimulator.ComplateJob();
            // TODO: Render
        }
    }
}