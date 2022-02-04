using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public int _averageFPS { get; private set; }
    public int _highestFPS { get; private set; }
    public int _lowestFPS { get; private set; }
    public int _frameRange = 60;
    private int[] _fpsBuffer;
    private int _fpsBufferIndex;

    // Update is called once per frame
    void Update()
    {
        if (_fpsBuffer == null || _fpsBuffer.Length != _frameRange)
        {
            InitializeBuffer();
        }
        UpdateBuffer();
        CalculateFPS();
    }

    void InitializeBuffer()
    {
        if (_frameRange <= 0)
        {
            _frameRange = 1;
        }
        _fpsBuffer = new int[_frameRange];
        _fpsBufferIndex = 0;
    }

    void UpdateBuffer()
    {
        _fpsBuffer[_fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
        if (_fpsBufferIndex >= _frameRange)
        {
            _fpsBufferIndex = 0;
        }
    }

    void CalculateFPS()
    {
        int _sum = 0;
        int _highest = 0;
        int _lowest = int.MaxValue;
        for (int i = 0; i < _frameRange; i++)
        {
            int _fps = _fpsBuffer[i];
            _sum += _fps;
            if(_fps > _highest)
            {
                _highest = _fps;
            }
            if(_fps < _lowest)
            {
                _lowest = _fps;
            }
        }
        _averageFPS = _sum / _frameRange;
        _highestFPS = _highest;
        _lowestFPS = _lowest;
    }

}
