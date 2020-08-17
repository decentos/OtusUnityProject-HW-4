namespace MVCExample
{
    public sealed class InputController : IExecute
    {
        private readonly IUserInputProxy<float> _horizontal;
        private readonly IUserInputProxy<float> _vertical;
        private readonly IUserInputProxy<bool> _fire;
        public InputController(IUserInputProxy<float> horizontal, IUserInputProxy<float> vertical, IUserInputProxy<bool> fire)
        {
            _horizontal = horizontal;
            _vertical = vertical;
            _fire = fire;
        }
        
        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _fire.GetAxis();
        }
    }
}
