//策略模式2015-01-23 10:57:12
using System;
using NUnit.Framework;

namespace RedNoble.Starmao.DesginPattern
{
    /// <summary>
    /// 收费算法接口
    /// </summary>
    public interface IChargeBehavior
    {
        string CustomerCharge(decimal money);
       
    }

    /// <summary>
    /// 正常收费算法
    /// </summary>
    public class NormalChargeBehavior : IChargeBehavior
    {
        public string CustomerCharge(decimal money)
        {
            return string.Format("原价：{0},实际收费：{1}", money, money);
        }
    }
    /// <summary>
    /// VIP收费算法
    /// </summary>
    public class VipChargeBehavior : IChargeBehavior
    {
        public string CustomerCharge(decimal money)
        {
            return string.Format("原价：{0},实际收费：{1}", money, money*0.8m);
        }
    }

    public abstract class Customer
    {
        public decimal Money { get; set; }

        protected IChargeBehavior ChargeBehavior;

        public void CustomerPay(decimal money)
        {
            Console.WriteLine(ChargeBehavior.CustomerCharge(money));
        }

        /// <summary>
        /// 设置对应的收费算法
        /// </summary>
        /// <param name="chargeBehavior"></param>
        public void SetChargeBehavior(IChargeBehavior chargeBehavior)
        {
            ChargeBehavior = chargeBehavior;
        }
    }

    public class NormalCustomer : Customer
    {
        //public NormalCustomer()
        //{
        //    ChargeBehavior = new NormalChargeBehavior();
        //}
    }

    public class VipCustomer : Customer
    {
        //public VipCustomer()
        //{
        //    ChargeBehavior = new VipChargeBehavior();
        //}
    }


    public class StrategyPattern
    {
        [Test]
        public void TestMethod()
        {
            //普通客户
            Customer normalCustomer = new NormalCustomer();
            normalCustomer.Money = 100m;
            normalCustomer.SetChargeBehavior(new NormalChargeBehavior());
            normalCustomer.CustomerPay(normalCustomer.Money);

            //Vip客户
            Customer vipCustomer = new VipCustomer();
            normalCustomer.Money = 100m;
            vipCustomer.SetChargeBehavior(new VipChargeBehavior());
            vipCustomer.CustomerPay(normalCustomer.Money);
        }
    }
}