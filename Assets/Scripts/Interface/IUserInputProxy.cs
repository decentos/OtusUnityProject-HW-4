using System;

namespace MVCExample
{
    public interface IUserInputProxy<T>
    {
        event Action<T> AxisOnChange;
        void GetAxis();
    }
}
