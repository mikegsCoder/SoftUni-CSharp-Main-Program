using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncome = 0;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink currDrink = null;

            if (type == "Tea")
            {
                currDrink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                currDrink = new Water(name, portion, brand);
            }

            this.drinks.Add(currDrink);
            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood currFood = null;

            if (type == "Bread")
            {
                currFood = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                currFood = new Cake(name, price);
            }

            this.bakedFoods.Add(currFood);
            return String.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable currTable = null;

            if (type == "InsideTable")
            {
                currTable = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                currTable = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(currTable);
            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables)
            {
                if (!table.IsReserved)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return String.Format(OutputMessages.TotalIncome, this.totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            var currTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            decimal bill = currTable.GetBill();
            this.totalIncome += bill;
            currTable.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var currTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (currTable == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var currDrink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (currDrink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            currTable.OrderDrink(currDrink);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, $"{drinkName} {drinkBrand}");
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var currTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (currTable == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var currFood = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (currFood == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            currTable.OrderFood(currFood);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var currTable = this.tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if (currTable == null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            currTable.Reserve(numberOfPeople);
            return String.Format(OutputMessages.TableReserved, currTable.TableNumber, numberOfPeople);
        }       
    }
}
