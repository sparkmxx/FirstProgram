using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace RedNoble.Starmao.DesginPattern
{
    /// <summary>
    /// 抽象新闻组件
    /// </summary>
    public abstract class NewsComponet
    {
        public abstract List<Article> GetList();
    }

    /// <summary>
    /// 当前处理新闻的组件
    /// </summary>
    public class ConcreteNewsComponet : NewsComponet
    {

        public override List<Article> GetList()
        {
            List<Article> articles = new List<Article>();
            Console.WriteLine("返回文章列表");
            return articles;
        }
    }

    /// <summary>
    /// 新闻组件的抽象装饰类
    /// </summary>
    public abstract class NewsDecorator : NewsComponet
    {

        private readonly NewsComponet _componet;

        protected NewsDecorator(NewsComponet componet)
        {
            _componet = componet;
        }

        public override List<Article> GetList()
        {
            return _componet.GetList();
        }
    }

    /// <summary>
    /// 置顶的装饰类
    /// </summary>
    public class TopNewsDecorator : NewsDecorator
    {
        public TopNewsDecorator(NewsComponet componet)
            : base(componet)
        {
        }

        public override List<Article> GetList()
        {
            TopMethod();
            return base.GetList();
        }

        public void TopMethod()
        {
            Console.WriteLine("置顶处理……");
        }
    }

    /// <summary>
    /// 新闻着色的装饰类
    /// </summary>
    public class ColorNewsDecorator : NewsDecorator
    {
        protected ColorNewsDecorator(NewsComponet componet)
            : base(componet)
        {
        }

        public override List<Article> GetList()
        {
            ColorMethod();
            return base.GetList();
        }

        public void ColorMethod()
        {
            Console.WriteLine("着色处理……");
        }


        public class DecoratorPatternTest
        {
            /// <summary>
            /// 测试方法，注意装饰是有顺序的
            /// </summary>
            [Test]
            public void SceneTest()
            {
                NewsComponet concreteNewsComponet = new ConcreteNewsComponet();

                concreteNewsComponet = new TopNewsDecorator(concreteNewsComponet);

                concreteNewsComponet = new ColorNewsDecorator(concreteNewsComponet);

                concreteNewsComponet.GetList();
            }
        }
    }
}
