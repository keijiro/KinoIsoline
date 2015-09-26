//
// KinoIsoline - Isoline effect
//
// Copyright (C) 2015 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using UnityEngine;
using UnityEditor;

namespace Kino
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Isoline))]
    public class IsolineEditor : Editor
    {
        SerializedProperty _lineColor;
        SerializedProperty _luminanceBlending;
        SerializedProperty _backgroundColor;

        SerializedProperty _axis;
        SerializedProperty _interval;
        SerializedProperty _offset;

        SerializedProperty _noiseFrequency;
        SerializedProperty _noiseAmplitude;

        SerializedProperty _fallOffDepth;

        void OnEnable()
        {
            _lineColor         = serializedObject.FindProperty("_lineColor");
            _luminanceBlending = serializedObject.FindProperty("_luminanceBlending");
            _backgroundColor   = serializedObject.FindProperty("_backgroundColor");

            _axis     = serializedObject.FindProperty("_axis");
            _interval = serializedObject.FindProperty("_interval");
            _offset   = serializedObject.FindProperty("_offset");

            _noiseFrequency = serializedObject.FindProperty("_noiseFrequency");
            _noiseAmplitude = serializedObject.FindProperty("_noiseAmplitude");

            _fallOffDepth = serializedObject.FindProperty("_fallOffDepth");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_lineColor);
            EditorGUILayout.PropertyField(_luminanceBlending);
            EditorGUILayout.PropertyField(_backgroundColor);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_axis);
            EditorGUILayout.PropertyField(_interval);
            EditorGUILayout.PropertyField(_offset);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_noiseFrequency);
            EditorGUILayout.PropertyField(_noiseAmplitude);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_fallOffDepth);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
