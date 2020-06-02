using System;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{
    //interface IPerson
    //{
    //    string name { get; set; }

    //    int age { get; set; }

    //    int Run();
    //}

    //interface IChild
    //{
    //    string FavoriteToy();
    //}


    //class Student : IPerson, IChild
    //{
    //    public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public int age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //    public string FavoriteToy()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int Run()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //Create an interface for cars
    //Create an interface for tire
    //Create an interface for engine

    //Create two car classes
    //Porsche
    //Yeet
    interface ICar
    {
        bool drive();
    }
    interface ITire
    {
        int pressure();
    }
    interface IEngine
    {
        int rpm();
    }

    class Porshe : ICar, IEngine, ITire
    {
        public bool drive()
        {
            return true;
        }
        public int pressure()
        {
            return 30;
        }
        public int rpm()
        {
            return 5000;
        }
    }

    class Yeet : IEngine, ITire
    {
        public bool drive()
        {
            return true;
        }
        public int pressure()
        {
            return 30;
        }
        public int rpm()
        {
            return int.MaxValue;
        }
    }
    class Yeet21 : ITire
    {
        public bool drive()
        {
            return true;
        }
        public int pressure()
        {
            return 30;
        }
        public int rpm()
        {
            return int.MaxValue;
        }
    }
}