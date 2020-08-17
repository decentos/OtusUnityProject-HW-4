using UnityEngine;

namespace MVCExample
{
    public sealed class MoveController : IExecute, ICleanup
    {
        private readonly Transform _unit;
        private readonly IUnit _unitData;
        private float _horizontal;
        private float _vertical;
        private Vector3 _move;
        private readonly IUserInputProxy<float> _horizontalInputProxy;
        private readonly IUserInputProxy<float> _verticalInputProxy;

        public MoveController(IUserInputProxy<float> horizontal, IUserInputProxy<float> vertical, Transform unit, IUnit unitData)
        {
            _unit = unit;
            _unitData = unitData;
            _horizontalInputProxy = horizontal;
            _verticalInputProxy = vertical;

            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        public void Execute(float deltaTime)
        {
            var speed = deltaTime * _unitData.Speed;
            _move.Set(_horizontal * speed, _vertical * speed, 0.0f);
            _unit.localPosition -= _move;
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}
