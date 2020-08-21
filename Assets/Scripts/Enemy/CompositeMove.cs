using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public sealed class CompositeMove : IMove
    {
        private readonly List<IMove> _moves = new List<IMove>();
        public bool IsEmpty => _moves.Count == 0;

        public void AddUnit(IMove unit)
        {
            _moves.Add(unit);
        }

        public void RemoveUnit(IMove unit)
        {
            _moves.Remove(unit);
        }


        public void Move(Vector3 point)
        {
            foreach (var t in _moves)
            {
                t.Move(point);
            }
        }
    }
}
