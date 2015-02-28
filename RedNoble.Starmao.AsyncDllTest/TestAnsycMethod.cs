using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RedNoble.Starmao.AsyncDllTest
{
    public class TestAnsycMethod
    {
        #region 同步方法测试
        [Test]
        public void TestSync()
        {
            Console.WriteLine("开始测试同步方法");
            SyncMethod(0);
            Console.WriteLine("结束测试同步方法");
        }

        private void SyncMethod(int input)
        {
            Console.WriteLine("进入同步操作！");
            var result = SyancWork(input);
            Console.WriteLine("最终结果{0}", result);
            Console.WriteLine("退出同步操作！");
        }

        private int SyancWork(int input)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("耗时操作{0}", i + 1);
                Thread.Sleep(1000);
                input++;
            }
            return input;
        }
        #endregion


        #region 异步方法测试
        [Test]
        public void TestAsyn()
        {
            Console.WriteLine("开始测试同步方法");
            AsynMethod(0);
            Console.WriteLine("结束测试同步方法");
        }

        private async void AsynMethod(int input)
        {
            Console.WriteLine("进入同步操作！");
            Func<object, int> asynwork = AsynWork;
            var result = await Task.Factory.StartNew(asynwork,input);
            Console.WriteLine("最终结果{0}", result);
            Console.WriteLine("退出同步操作！");
        }

      

        private int AsynWork(object input)
        {
            int result = (int) input;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("耗时操作{0}", i + 1);
                result++;
            }
            return result;
        }
        #endregion
    }
}
