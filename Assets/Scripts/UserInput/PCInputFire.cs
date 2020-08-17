using System;
using UnityEngine;

namespace MVCExample
{
    public sealed class PCInputFire : IUserInputProxy<bool>
    {
        public event Action<bool> AxisOnChange = delegate (bool t) { };

        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetButtonDown(AxisManager.FIRE1));
        }
    }
}