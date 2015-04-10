using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample
{
    public abstract class Beverage
    {
        public abstract string GetDescription();
        public abstract double Cost();
    }

    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage beverage;
        private string description = "Unknown Description";
        private double cost = 0.00;

        protected CondimentDecorator(Beverage beverage)
        {
            this.beverage = beverage;
        }


        public override string GetDescription()
        {
            return string.Format("{0}, {1}", beverage.GetDescription(), description);
        }

        public override double Cost()
        {
            return cost + beverage.Cost();
        }
    }

    public class Espresso : Beverage
    {
        private string description = "Espresso";
         
        public override double Cost()
        {
            return 1.99;
        }

        public override string GetDescription()
        {
            return description;
        }
    }

    public class HouseBlend : Beverage
    {
        private string description = "House Blend Coffee";

        public override double Cost()
        {
            return .89;
        }

        public override string GetDescription()
        {
            return description;
        }
    }


    public class Mocha : CondimentDecorator
    {

        public Mocha(Beverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return this.beverage.GetDescription() + ", Mocha";
        }

        public override double Cost()
        {
            return beverage.Cost() + .20;
        }
    }

    public class Whip : CondimentDecorator
    {
        public Whip(Beverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return this.beverage.GetDescription() + ", Whip";
        }

        public override double Cost()
        {
            return beverage.Cost() + .50;
        }
    }
}
