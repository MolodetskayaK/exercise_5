using System;

namespace PrototypePattern
{
    public interface IMyCloneable<T>
    {
        T Clone();
    }

    public class Vehicle : IMyCloneable<Vehicle>, ICloneable
    {
        public int MaxSpeed { get; set; }
        public string Color { get; set; }

        public Vehicle(int maxSpeed, string color)
        {
            MaxSpeed = maxSpeed;
            Color = color;
        }

        protected Vehicle(Vehicle original)
        {
            MaxSpeed = original.MaxSpeed;
            Color = original.Color;
        }

        public virtual Vehicle Clone()
        {
            return new Vehicle(this);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public override string ToString()
        {
            return $"Vehicle: MaxSpeed={MaxSpeed}, Color={Color}";
        }
    }

    public class Car : Vehicle, IMyCloneable<Car>, ICloneable
    {
        public int Doors { get; set; }

        public Car(int maxSpeed, string color, int doors) : base(maxSpeed, color)
        {
            Doors = doors;
        }

        protected Car(Car original) : base(original)
        {
            Doors = original.Doors;
        }

        public new Car Clone()
        {
            return new Car(this);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public override string ToString()
        {
            return base.ToString() + $", Doors={Doors}";
        }
    }

    public class SportsCar : Car, IMyCloneable<SportsCar>, ICloneable
    {
        public bool HasTurbo { get; set; }

        public SportsCar(int maxSpeed, string color, int doors, bool hasTurbo) : base(maxSpeed, color, doors)
        {
            HasTurbo = hasTurbo;
        }

        protected SportsCar(SportsCar original) : base(original)
        {
            HasTurbo = original.HasTurbo;
        }

        public new SportsCar Clone()
        {
            return new SportsCar(this);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public override string ToString()
        {
            return base.ToString() + $", HasTurbo={HasTurbo}";
        }
    }

    public class Truck : Vehicle, IMyCloneable<Truck>, ICloneable
    {
        public double LoadCapacity { get; set; }

        public Truck(int maxSpeed, string color, double loadCapacity) : base(maxSpeed, color)
        {
            LoadCapacity = loadCapacity;
        }

        protected Truck(Truck original) : base(original)
        {
            LoadCapacity = original.LoadCapacity;
        }

        public new Truck Clone()
        {
            return new Truck(this);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public override string ToString()
        {
            return base.ToString() + $", LoadCapacity={LoadCapacity}t";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(100, "Red");
            Car car = new Car(150, "Blue", 4);
            SportsCar sportsCar = new SportsCar(250, "Black", 2, true);
            Truck truck = new Truck(80, "Green", 10.5);

            Console.WriteLine("Оригиналы:");
            Console.WriteLine(vehicle);
            Console.WriteLine(car);
            Console.WriteLine(sportsCar);
            Console.WriteLine(truck);
            Console.WriteLine();

            Vehicle vehicleClone = vehicle.Clone();
            Car carClone = car.Clone();
            SportsCar sportsCarClone = sportsCar.Clone();
            Truck truckClone = truck.Clone();

            vehicleClone.MaxSpeed = 120;
            carClone.Doors = 5;
            sportsCarClone.HasTurbo = false;
            truckClone.LoadCapacity = 15.0;

            Console.WriteLine("После клонирования и изменения клонов (IMyCloneable):");
            Console.WriteLine("Оригинал Vehicle: " + vehicle);
            Console.WriteLine("Клон Vehicle: " + vehicleClone);
            Console.WriteLine("Оригинал Car: " + car);
            Console.WriteLine("Клон Car: " + carClone);
            Console.WriteLine("Оригинал SportsCar: " + sportsCar);
            Console.WriteLine("Клон SportsCar: " + sportsCarClone);
            Console.WriteLine("Оригинал Truck: " + truck);
            Console.WriteLine("Клон Truck: " + truckClone);
            Console.WriteLine();

            object vehicleCloneObj = ((ICloneable)vehicle).Clone();
            object carCloneObj = ((ICloneable)car).Clone();

            Console.WriteLine("Пример с ICloneable (требует каста):");
            Console.WriteLine("Клон Vehicle (как object, после каста): " + (Vehicle)vehicleCloneObj);
            Console.WriteLine("Клон Car (как object, после каста): " + (Car)carCloneObj);
        }
    }
}