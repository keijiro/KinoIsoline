//
// KinoIsoline - Isoline effect
//
// Copyright (C) 2015 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
using UnityEngine;

namespace Kino
{
    [RequireComponent(typeof(Isoline))]
    [AddComponentMenu("Kino Image Effects/Isoline Vibrator")]
    public class IsolineVibrator : MonoBehaviour
    {
        [SerializeField]
        float _minAmplitude = 0.2f;

        public float minAmplitude {
            get { return _minAmplitude; }
            set { _minAmplitude = value; }
        }

        [SerializeField]
        float _maxAmplitude = 0.8f;

        public float maxAmplitude {
            get { return _maxAmplitude; }
            set { _maxAmplitude = value; }
        }

        [SerializeField]
        float _frequency = 0.3f;

        public float frequency {
            get { return _frequency; }
            set { _frequency = value; }
        }

        float _time;

        void Update()
        {
            _time += Time.deltaTime * _frequency * Mathf.PI * 2;
            var wave = (1.0f - Mathf.Cos(_time)) * 0.5f;
            wave *= _maxAmplitude - _minAmplitude;

            var target = GetComponent<Isoline>();
            target.noiseAmplitude = _minAmplitude + wave;
        }
    }
}
