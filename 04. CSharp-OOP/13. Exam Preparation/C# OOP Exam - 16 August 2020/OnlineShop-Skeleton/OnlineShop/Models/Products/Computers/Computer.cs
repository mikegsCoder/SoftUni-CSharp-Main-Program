using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public override double OverallPerformance 
            => CalculateOveralPerformance();

        public override decimal Price 
            => this.Peripherals.Sum(p => p.Price) + this.Components.Sum(c => c.Price) + base.Price;
      
        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType() == component.GetType()))
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.ExistingComponent, 
                    component.GetType().Name, 
                    this.GetType().Name, 
                    this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(p => p.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name,
                    this.GetType().Name,
                    this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {            
            if (!this.components.Any(c => c.GetType().Name == componentType))
            {               
                throw new ArgumentException(string.Format
                    (ExceptionMessages.NotExistingComponent, 
                    componentType, 
                    this.GetType().Name, 
                    this.Id));
            }

            IComponent componentToRemove = this.components.FirstOrDefault
                (c => c.GetType().Name == componentType);
            this.components.Remove(componentToRemove);
            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.peripherals.Any(p => p.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.NotExistingPeripheral,
                    peripheralType,
                    this.GetType().Name,
                    this.Id));
            }

            IPeripheral peripheralToRemove = this.peripherals.FirstOrDefault
               (c => c.GetType().Name == peripheralType);

            this.peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }

        private double CalculateOveralPerformance()
        {
            if (this.Components.Count == 0)
            {
                return base.OverallPerformance;
            }

            return base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);
        }

        public override string ToString()
        {
            //"Overall Performance: {overall performance}. Price: {price} - {product type}: {manufacturer} {model} (Id: {id})"
            //" Components ({components count}):"
            //"  {component one}"
            //"  {component two}"
            //"  {component n}"
            //" Peripherals ({peripherals count}); Average Overall Performance ({average overall performance peripherals}):"
            //"  {peripheral one}"
            //"  {peripheral two}"

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (IComponent component in components)
            {
                //sb.AppendLine($"  {component.ToString()}");
                sb.AppendLine($"  {component.ToString()}");
            }

            string averageResult = this.Peripherals.Count == 0 ? "0.00" : this.peripherals.Average(p => p.OverallPerformance).ToString("f2");

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({averageResult}):");

            foreach (IPeripheral peripherial in this.peripherals)
            {
                //sb.AppendLine($"  {peripherial.ToString()}");
                sb.AppendLine($"  {peripherial.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
