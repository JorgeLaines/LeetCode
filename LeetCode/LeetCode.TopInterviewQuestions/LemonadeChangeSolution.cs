using LeetCode.Common;

namespace LeetCode.TopInterviewQuestions
{
    public class LemonadeChangeSolution : BaseSolution, IBaseSolution
    {
        public LemonadeChangeSolution() : base("https://leetcode.com/problems/lemonade-change")
        {
                
        }

        int[] bills;

        public void Execute()
        {
            var result = LemonadeChange(bills);
            Console.WriteLine(result);
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void SetDefaultExample(int testCase = 0)
        {
            var testCases = new int[][] {
                new int[5] { 5, 5, 5, 10, 20 },
                new int[5] { 5, 5, 10, 10, 20 },
                new int[400] { 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20, 5, 10, 5, 20 }
            };

            if (testCase < 0 || testCase >= testCases.Length) throw new Exception($"Test case {testCase} doesn't exists!");

            bills = testCases[testCase];
        }

        public bool LemonadeChangeArray(int[] bills)
        {
            bool canGiveChangeToAll = true;
            int[] cashRegister = new int[3] { 0, 0, 0 };
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] == 5)
                {
                    cashRegister[0] = cashRegister[0] + 1;
                }
                else if (bills[i] == 10)
                {
                    if (cashRegister[0] > 0)
                    {
                        cashRegister[0] = cashRegister[0] - 1;
                        cashRegister[1] = cashRegister[1] + 1;
                    }
                    else
                    {
                        canGiveChangeToAll = false;
                    }
                }
                else if (bills[i] == 20)
                {
                    if (cashRegister[0] * 5 + cashRegister[1] * 10 >= 15)
                    {
                        if (cashRegister[1] >= 1 && cashRegister[0] >= 1)
                        {
                            cashRegister[0] = cashRegister[0] - 1;
                            cashRegister[1] = cashRegister[1] - 1;
                            cashRegister[2] = cashRegister[2] + 1;
                        }
                        else if (cashRegister[0] >= 3)
                        {
                            cashRegister[0] = cashRegister[0] - 3;
                            cashRegister[2] = cashRegister[2] + 1;
                        }
                        else
                        {
                            canGiveChangeToAll = false;
                        }
                    }
                    else
                    {
                        canGiveChangeToAll = false;
                    }
                }
                if (!canGiveChangeToAll) break;
            }
            return canGiveChangeToAll;
        }

        public bool LemonadeChange(int[] bills)
        {
            bool canGiveChangeToAll = true;
            var cashRegister = new CashRegister();
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] == 5)
                {
                    cashRegister.FiveDollarBill++;
                }
                else if (bills[i] == 10)
                {
                    if (cashRegister.FiveDollarBill > 0)
                    {
                        cashRegister.FiveDollarBill--;
                        cashRegister.TenDollarBill++;
                    }
                    else
                    {
                        canGiveChangeToAll = false;
                    }
                }
                else if (bills[i] == 20)
                {
                    if (cashRegister.FiveDollarBill * 5 + cashRegister.TenDollarBill * 10 >= 15)
                    {
                        if (cashRegister.TenDollarBill >= 1 && cashRegister.FiveDollarBill >= 1)
                        {
                            cashRegister.FiveDollarBill--;
                            cashRegister.TenDollarBill--;
                            cashRegister.TwentyDollarBill++;
                        }
                        else if (cashRegister.FiveDollarBill >= 3)
                        {
                            cashRegister.FiveDollarBill = cashRegister.FiveDollarBill - 3;
                            cashRegister.TwentyDollarBill++;
                        }
                        else
                        {
                            canGiveChangeToAll = false;
                        }
                    }
                    else
                    {
                        canGiveChangeToAll = false;
                    }
                }
                if (!canGiveChangeToAll) break;
            }
            return canGiveChangeToAll;
        }
    }

    public class CashRegister
    {
        public CashRegister()
        {
        }

        public int FiveDollarBill { get; set; }
        public int TenDollarBill { get; set; }
        public int TwentyDollarBill { get; set; }
    }
}