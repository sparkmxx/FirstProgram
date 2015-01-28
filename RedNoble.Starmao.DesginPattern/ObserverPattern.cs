//观察者模式
//这里使用.net源码中内置的接口

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RedNoble.Starmao.DesginPattern
{
    public class Article
    {
        public string Title { get; set; }
        public DateTime CreteDate { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }


    public class SinaNews : IObservable<Article>
    {
        readonly IList<IObserver<Article>> _observers = new List<IObserver<Article>>();
        readonly IList<Article> _articles = new List<Article>();
        public IDisposable Subscribe(IObserver<Article> observer)
        {
            _observers.Add(observer);
            return new UnSubscribeSinaNews(_observers, observer);
        }

        public IDisposable UnSubscribe(IObserver<Article> observer)
        {
            if (observer != null && _observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
            return new UnSubscribeSinaNews(_observers, observer);
        }

        #region 释放，取消订阅
        public class UnSubscribeSinaNews : IDisposable
        {
            private readonly IList<IObserver<Article>> _observers;
            private readonly IObserver<Article> _observer;

            public UnSubscribeSinaNews(IList<IObserver<Article>> observers, IObserver<Article> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }
        #endregion

        /// <summary>
        /// 通知订阅者新文章
        /// </summary>
        /// <param name="article">文章</param>
        public void Notify(Article article)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(article);
            }
        }

        /// <summary>
        /// 添加文章，通知订阅者
        /// </summary>
        /// <param name="article">文章</param>
        public void AddArticle(Article article)
        {
            _articles.Add(article);
            Notify(article);
        }
    }

    public class Reader : IObserver<Article>
    {
        public string Name { get; set; }

        public void OnNext(Article value)
        {
            Console.WriteLine("阅读人:{0}", Name);
            Console.WriteLine("标题:{0},创建时间:{1},作者:{2}\n内容:{3}", value.Title, value.CreteDate, value.Author, value.Content);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("推送过程过线了错误，错误消息:{0}", error.Message);
        }

        public void OnCompleted()
        {
            Console.WriteLine("{0}：消息推送成功！", Name);
        }
    }


    public class ObserverPatternTest
    {
        [Test]
        public void Test()
        {
            Reader reader1 = new Reader { Name = "冒星星1" };
            Reader reader2 = new Reader { Name = "冒星星2" };
            Reader reader3 = new Reader { Name = "冒星星3" };

            SinaNews sinaNews = new SinaNews();
            sinaNews.Subscribe(reader1);
            sinaNews.Subscribe(reader2);
            sinaNews.Subscribe(reader3);
            sinaNews.UnSubscribe(reader1);
            Article article = new Article { Title = "今日头条1", Author = "Starmao", Content = "今日头条1今日头条1今日头条1今日头条1", CreteDate = DateTime.Now };

            sinaNews.AddArticle(article);
        }
    }

}
