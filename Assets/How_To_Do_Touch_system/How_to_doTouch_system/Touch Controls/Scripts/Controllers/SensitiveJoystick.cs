﻿using UnityEngine.EventSystems;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

namespace How_To_Do
{
    
    public class SensitiveJoystick : SimpleJoystick
    {
        public CarController carmove;

        public AnimationCurve SensitivityCurve = new AnimationCurve(
            new Keyframe(0f, 0f, 1f, 1f),
            new Keyframe(1f, 1f, 1f, 1f));

        public override void OnDrag(PointerEventData eventData)
        {
            base.OnDrag(eventData);
         
            var linearHorizontalValue = HorizintalAxis.Value;
            var linearVecticalValue = VerticalAxis.Value;

            var horizontalSign = Mathf.Sign(linearHorizontalValue);
            var verticalSign = Mathf.Sign(linearVecticalValue);


            HorizintalAxis.Value = horizontalSign * SensitivityCurve.Evaluate(horizontalSign * linearHorizontalValue);
            VerticalAxis.Value = verticalSign * SensitivityCurve.Evaluate(verticalSign * linearVecticalValue);

            carmove.Move(HorizintalAxis.Value, VerticalAxis.Value, 0, 0);
        }
    }
}