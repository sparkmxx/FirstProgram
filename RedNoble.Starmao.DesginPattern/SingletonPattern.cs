//单例模式

namespace RedNoble.Starmao.DesginPattern
{
    public class SingletonClass
    {
        private SingletonClass() { }

        private static SingletonClass _uniqueInstance;

        private readonly static object LockObject = new object();

        public static SingletonClass GetInstance()
        {
            if (_uniqueInstance == null)
            {
                lock (LockObject)
                {
                    if (_uniqueInstance == null)
                    {
                        _uniqueInstance = new SingletonClass();
                    }
                }
            }
            return _uniqueInstance;
        }
    }
}
