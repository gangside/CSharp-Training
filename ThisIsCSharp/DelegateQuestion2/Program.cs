using System;

namespace DelegateQuestion2
{
    delegate void MyDelegate(int a);
    
    class Market
    {
        public event MyDelegate CustomerEvent;

        public void BuySomething (int CustomerNum)
        {
            if(CustomerNum == 30)
            {
                CustomerEvent(CustomerNum);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market();
            market.CustomerEvent += new MyDelegate(GetPrize);

            for (int customerNum = 0; customerNum < 100; customerNum+= 10)
            {
                market.BuySomething(customerNum);
            }
        }

        static public void GetPrize(int customerNum)
        {
            Console.WriteLine($"축하합니다! {customerNum}번째 고객 이벤트에 당첨되셨습니다.");
        }
    }
}
