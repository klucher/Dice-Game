using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public class Dice
    {
        private Random rand = new Random(); // One random generator object for all dice

        private int _sides;

        public int RollCounter;

        public int Value { get; set; }

        public bool _isSelectedForReroll { get; set; }

        public Dice(int sides)
        {
            _sides = sides;
        }

        public int Counter()
        {
            return RollCounter;
        }

        // Sets the value to a random value based on the number of sides.
        public void Roll()
        {
            Value = rand.Next(0, _sides) + 1;
            RollCounter = 0;
        }

        // Sets the value to a random value based on the number of sides,
        // if die is chosen to be rerolled.
        public void Reroll()
        {
            if (_isSelectedForReroll)
            {
                Value = rand.Next(0, _sides) + 1;
                _isSelectedForReroll = false;
                RollCounter++;
            }
        }

        public override string ToString()
        {
            return $"[{Value}]";
        }
    }
}