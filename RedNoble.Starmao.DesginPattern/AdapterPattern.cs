//适配器模式
//适配老的接口以适应新的接口

using System;
using NUnit.Framework;

namespace RedNoble.Starmao.DesginPattern
{
    /// <summary>
    /// 新的接口
    /// </summary>
    public interface IDuck
    {
        void GuaGua();
        void Fly();
    }

    public class Duck : IDuck
    {
        public void GuaGua()
        {
            Console.WriteLine("呱呱叫");
        }

        public void Fly()
        {
            Console.WriteLine("飞行了一段距离");
        }
    }

    /// <summary>
    /// 老的接口
    /// </summary>
    public interface ITurkey
    {
        void GuGu();
        void Fly();
    }

    /// <summary>
    /// 火鸡
    /// </summary>
    public class Turkey : ITurkey
    {
        public void GuGu()
        {
            Console.WriteLine("咕咕叫");
        }

        public void Fly()
        {
            Console.WriteLine("飞行了一小段距离");
        }
    }

    /// <summary>
    /// 适配器继承新接口，具有老接口对象的引用，实现还是有老对象去实现
    /// </summary>
    public class DuckAdapter :IDuck
    {
        private readonly ITurkey _iTurkey;

        public DuckAdapter(ITurkey iTurkey)
        {
            _iTurkey = iTurkey;
        }
        public void GuaGua()
        {
            _iTurkey.GuGu();
        }

        public void Fly()
        {
            for (int i = 0; i < 3; i++)
            {
                _iTurkey.Fly();
            }
        }
    }

    public class SenceTest
    {
        [Test]
        public void Test()
        {
            Duck duck = new Duck();
            
            Turkey turkey = new Turkey();
            //用火鸡充当鸭子
            IDuck newDuck = new DuckAdapter(turkey);
            TestDuck(duck);

            TestDuck(newDuck);

        }

        public void TestDuck(IDuck iDuck)
        {
            iDuck.GuaGua();
            iDuck.Fly();
            
        }
    }
}
