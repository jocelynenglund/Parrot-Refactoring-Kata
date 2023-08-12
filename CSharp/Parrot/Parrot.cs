using System;

namespace Parrot
{
    public class NorwegianBlue : Parrot
    {
        public NorwegianBlue(int numberOfCoconuts, double voltage, bool isNailed) : base(ParrotTypeEnum.NORWEGIAN_BLUE, numberOfCoconuts, voltage, isNailed)
        {
        }
        public override double GetSpeed() => _isNailed ? 0 : GetBaseSpeed(_voltage);
        public override string GetCry() => _voltage > 0 ? "Bzzzzzz" : "...";
    }

    public class African : Parrot
    {
        public African(int numberOfCoconuts, double voltage, bool isNailed) : base(ParrotTypeEnum.AFRICAN, numberOfCoconuts, voltage, isNailed)
        {
        }
        public override double GetSpeed() =>Math.Max(0, GetBaseSpeed() - GetLoadFactor() * _numberOfCoconuts);
        public override string GetCry() => "Sqaark!";
    }

    public class European : Parrot
    {
        public European(int numberOfCoconuts, double voltage, bool isNailed) : base(ParrotTypeEnum.EUROPEAN, numberOfCoconuts, voltage, isNailed)
        {
        }

        public override double GetSpeed() => GetBaseSpeed();
        public override string GetCry() => "Sqoork!";
    }
    public abstract class Parrot
    {
        protected readonly bool _isNailed;
        protected readonly int _numberOfCoconuts;
        protected readonly double _voltage;
        private readonly ParrotTypeEnum _type;

        public static Parrot Create(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed) => type switch
        {
            ParrotTypeEnum.EUROPEAN => new European(numberOfCoconuts, voltage, isNailed),
            ParrotTypeEnum.AFRICAN => new African(numberOfCoconuts, voltage, isNailed),
            ParrotTypeEnum.NORWEGIAN_BLUE => new NorwegianBlue(numberOfCoconuts, voltage, isNailed),
            _ => throw new ArgumentOutOfRangeException(),
        };

        protected Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            _type = type;
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed;
        }

        protected double GetBaseSpeed(double voltage) => Math.Min(24.0, voltage * GetBaseSpeed());

        protected static double GetLoadFactor() => 9.0;

        protected static double GetBaseSpeed() => 12.0;

        public abstract string GetCry();
        public abstract double GetSpeed();
       
    }
}