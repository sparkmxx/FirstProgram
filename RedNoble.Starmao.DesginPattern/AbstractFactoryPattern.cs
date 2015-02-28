//抽象工厂
//创建一系列相关的产品
//例子为苹果三星系列手机，平板

using System;
using NUnit.Framework;

namespace RedNoble.Starmao.DesginPattern
{
    /// <summary>
    /// 抽象苹果产品
    /// </summary>
    public abstract class Apple
    {
        public abstract void AppleStyle();
    }

    /// <summary>
    ///  苹果手机
    /// </summary>
    public class Iphone : Apple
    {
        public override void AppleStyle()
        {
            Console.WriteLine("苹果风格：Iphone4");

        }
    }

    /// <summary>
    /// 苹果平板
    /// </summary>
    public class Ipad : Apple
    {
        public override void AppleStyle()
        {
            Console.WriteLine("苹果风格：Ipad5");
        }
    }

    /// <summary>
    /// 抽象三星产品
    /// </summary>
    public abstract class Sumsung
    {
        public abstract void SumsungStyle();
    }

    /// <summary>
    /// 三星手机
    /// </summary>
    public class Note : Sumsung
    {
        public override void SumsungStyle()
        {
            Console.WriteLine("三星风格：Note2");
        }
    }

    /// <summary>
    /// 三星平板
    /// </summary>
    public class Tabs : Sumsung
    {
        public override void SumsungStyle()
        {
            Console.WriteLine("三星风格：Tabs2");
        }
    }

    /// <summary>
    /// 产品工厂，用于创建苹果产品和三星产品
    /// </summary>
    public abstract class ProductFactory
    {
        public abstract Apple GetAppleProduct();
        public abstract Sumsung GetSumsungProduct();
    }

    /// <summary>
    /// 手机工厂
    /// </summary>
    public class PhoneFactory : ProductFactory
    {
        public override Apple GetAppleProduct()
        {
            return new Iphone();
        }

        public override Sumsung GetSumsungProduct()
        {
            return new Note();
        }
    }

    /// <summary>
    /// 平板工厂
    /// </summary>
    public class PadFactory : ProductFactory
    {
        public override Apple GetAppleProduct()
        {
            return new Ipad();
        }

        public override Sumsung GetSumsungProduct()
        {
            return new Tabs();
        }
    }

    public class AbstractFactoryTest
    {
        [Test]
        public void SenceTest()
        {
            //创建一个苹果手机
            ProductFactory phoneFactory = new PhoneFactory();
            Apple appleProduct = phoneFactory.GetAppleProduct();
            appleProduct.AppleStyle();
        }
    }
}
