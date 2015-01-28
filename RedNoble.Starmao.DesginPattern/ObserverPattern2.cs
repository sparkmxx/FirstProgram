//自定义主题，观察者

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RedNoble.Starmao.DesginPattern
{
    /// <summary>
    /// 主题接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISubject<out T> where T : class
    {
        /// <summary>
        /// 添加观察者，订阅者
        /// </summary>
        /// <param name="displayObserver"></param>
        void AddObserver(IDisplayObserver<T> displayObserver);

        /// <summary>
        /// 取消观察者，订阅者
        /// </summary>
        /// <param name="displayObserver"></param>
        void RemoveObserver(IDisplayObserver<T> displayObserver);

        /// <summary>
        /// 通知观察者，订阅者关注的东西
        /// </summary>
        void Notify();
    }

    /// <summary>
    /// 观察者，订阅者接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDisplayObserver<in T> where T : class
    {
        /// <summary>
        /// 观察者，订阅者更新关注的东西
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }

    /// <summary>
    /// 关注的数据
    /// </summary>
    public class WeatherData
    {
        public decimal 温度 { get; set; }
        public decimal 湿度 { get; set; }
        public decimal 气压 { get; set; }
    }

    /// <summary>
    /// 天气主题
    /// </summary>
    public class WeatherSubject : ISubject<WeatherData>
    {
        private readonly IList<IDisplayObserver<WeatherData>> observers = new List<IDisplayObserver<WeatherData>>();
        private WeatherData _weatherData;

        public void AddObserver(IDisplayObserver<WeatherData> displayObserver)
        {
            if (displayObserver != null)
            {
                observers.Add(displayObserver);
            }
        }

        public void RemoveObserver(IDisplayObserver<WeatherData> displayObserver)
        {
            if (displayObserver != null && observers.Contains(displayObserver))
            {
                observers.Remove(displayObserver);
            }
        }

        /// <summary>
        /// 设置观察者，订阅者关注的东西，并通知观察者，订阅者
        /// </summary>
        /// <param name="webWeatherData"></param>
        public void SetWeatherData(WeatherData webWeatherData)
        {
            _weatherData = webWeatherData;
            Notify();
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(_weatherData);
            }
        }
    }


    public class Display1DisplayObserver : IDisplayObserver<WeatherData>
    {

        /// <summary>
        /// 实例化的时候，将其添加到主题
        /// </summary>
        /// <param name="subject"></param>
        public Display1DisplayObserver(ISubject<WeatherData> subject)
        {
            subject.AddObserver(this);
        }


        public void Update(WeatherData entity)
        {
            Console.WriteLine("Display1--->温度：{0}", entity.温度);
        }
    }


    public class Display2DisplayObserver : IDisplayObserver<WeatherData>
    {
        /// <summary>
        /// 实例化的时候，将其添加到主题
        /// </summary>
        /// <param name="subject"></param>
        public Display2DisplayObserver(ISubject<WeatherData> subject)
        {
            subject.AddObserver(this);
        }


        public void Update(WeatherData entity)
        {
            Console.WriteLine("Display2--->湿度：{0}", entity.湿度);
        }
    }


    public class Display3DisplayObserver : IDisplayObserver<WeatherData>
    {
        /// <summary>
        /// 实例化的时候，将其添加到主题
        /// </summary>
        /// <param name="subject"></param>
        public Display3DisplayObserver(ISubject<WeatherData> subject)
        {
            subject.AddObserver(this);
        }


        public void Update(WeatherData entity)
        {
            Console.WriteLine("Display3--->气压：{0}", entity.气压);
        }
    }


    public class WeatherDesignTest
    {
        [Test]
        public void TestWeatherDesign()
        {
            WeatherSubject subject = new WeatherSubject();

            Display1DisplayObserver observer1 = new Display1DisplayObserver(subject);
            Display2DisplayObserver observer2 = new Display2DisplayObserver(subject);
            Display3DisplayObserver observer3 = new Display3DisplayObserver(subject);


            WeatherData weatherData = new WeatherData {气压 = 1.1m, 湿度 = 2.2m, 温度 = 3.3m};

            subject.SetWeatherData(weatherData);
        }
    }
}