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
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Kino Image Effects/Isoline")]
    public class Isoline : MonoBehaviour
    {
        #region Public Properties

        // Line color
        [SerializeField, ColorUsage(true, true, 0, 8, 0.125f, 3)]
        Color _lineColor = Color.white;

        public Color lineColor {
            get { return _lineColor; }
            set { _lineColor = value; }
        }

        // Luminance blending ratio
        [SerializeField, Range(0, 1)]
        float _luminanceBlending = 1;

        public float luminanceBlending {
            get { return _luminanceBlending; }
            set { _luminanceBlending = value; }
        }

        // Background color
        [SerializeField]
        Color _backgroundColor = Color.black;

        public Color backgroundColor {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        // Slicing axis
        [SerializeField]
        Vector3 _axis = Vector3.one * 0.577f;

        public Vector3 axis {
            get { return _axis; }
            set { _axis = value; }
        }

        // Contour interval
        [SerializeField]
        float _interval = 0.25f;

        public float interval {
            get { return _interval; }
            set { _interval = value; }
        }

        // Offset
        [SerializeField]
        Vector3 _offset;

        public Vector3 offset {
            get { return _offset; }
            set { _offset = value; }
        }

        // Noise frequency
        [SerializeField]
        float _noiseFrequency = 1;

        public float noiseFrequency {
            get { return _noiseFrequency; }
            set { _noiseFrequency = value; }
        }

        // Noise amplitude
        [SerializeField]
        float _noiseAmplitude = 0;

        public float noiseAmplitude {
            get { return _noiseAmplitude; }
            set { _noiseAmplitude = value; }
        }

        // Depth fall-off
        [SerializeField]
        float _fallOffDepth = 40;

        public float fallOffDepth {
            get { return _fallOffDepth; }
            set { _fallOffDepth = value; }
        }

        #endregion

        #region Private Properties

        [SerializeField]
        Shader _shader;

        Material _material;

        #endregion

        #region MonoBehaviour Functions

        void OnEnable()
        {
            GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
        }

        void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (_material == null) {
                _material = new Material(_shader);
                _material.hideFlags = HideFlags.DontSave;
            }

            var matrix = GetComponent<Camera>().cameraToWorldMatrix;
            _material.SetMatrix("_InverseView", matrix);

            _material.SetColor("_Color", _lineColor);
            _material.SetColor("_BgColor", _backgroundColor);
            _material.SetFloat("_Blend", _luminanceBlending);

            _material.SetVector("_Axis", _axis.normalized);
            _material.SetFloat("_Density", 1.0f / _interval);
            _material.SetVector("_Offset", _offset);

            _material.SetFloat("_NoiseFreq", _noiseFrequency);
            _material.SetFloat("_NoiseAmp", _noiseAmplitude);

            if (_noiseAmplitude > 0)
                _material.EnableKeyword("NOISE_ON");
            else
                _material.DisableKeyword("NOISE_ON");

            _material.SetFloat("_FallOffDepth", _fallOffDepth);

            Graphics.Blit(source, destination, _material);
        }

        #endregion
    }
}
