using System;
using UnityEngine;

namespace MVCExample
{
    public sealed class PCInputHorizontal : IUserInputProxy<float>
    {
        public event Action<float> AxisOnChange = delegate(float t) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(AxisManager.HORIZONTAL));
        }
        }
}
