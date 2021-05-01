using System;
using System.Linq;

namespace Version_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter numder of rows: ");
            int row = Convert.ToInt32 (Console.ReadLine());
            Console.Write("Enter numder of column: ");
            int column = Convert.ToInt32(Console.ReadLine());
            double[,] payoff_table = new double[row,column];
            for (int i = 0; i<row ;i++)
            {
                for (int x=0; x< column;x++)
                {
                    Console.Write("Enter value of [{0},{1}]:" ,i,x);

                    payoff_table[i,x]= Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine();
            }

            double max = 0;
            double min = 0;
            double[] Min = new double[row];
            double[] Max = new double[row];
            double[,] Regret_table = new double[row, column];
            double element = 0;

            for (int i = 0; i < row; i++)
            {
                for (int x = 0; x < column; x++)
                {
                    Console.Write("\t" + payoff_table[i, x]+ "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Enter the condition of the decision Uncertainty (Without Probability) or Risk (With Probability): ");
            string condition = Console.ReadLine();

            switch (condition)
            {
                case "Uncertainty":case "uncertainty":
                case "Without Probability": case "without probability":


                    Console.WriteLine("Profit or Cost case ?");
                    string state = Console.ReadLine();
                    if (state == "Profit")
                    {
                        Console.WriteLine();

                        //Optimistic approach
                        Console.WriteLine("Optimistic approach (Max of Max)");
                        //gettin the Max
                        for (int i = 0; i < row; i++)
                        {
                            min = payoff_table[i, 0];
                            for (int n = 0; n < column; n++)
                            {

                                if (max< payoff_table[i, n])
                                    max = payoff_table[i, n];
                            }
                            for (int x = i; x < row; x++)
                            {
                                Max[x] = max;
                            }
                        }
                        //gettin the Max
                        for (int i = 0; i < 1; i++)
                        {
                            Console.WriteLine("The answer is: " + Max.Max() + "\n");

                        }

                        //Pessimistic approach
                        Console.WriteLine("Pessimistic approach (Max of Min)");
                        //gettin the Min
                        for (int i = 0; i < row; i++)
                        {
                            min = payoff_table[i, 0];
                            for (int n = 0; n < column; n++)
                            {

                                if (min > payoff_table[i, n])
                                    min = payoff_table[i, n];
                            }
                            for (int x = i; x < row; x++)
                            {
                                Min[x] = min;
                            }
                        }
                        //gettin the Max
                        for (int i = 0; i < 1; i++)
                        {
                            Console.WriteLine("The answer is: " + Min.Max() + "\n");

                        }
                        //Regret approach
                        Console.WriteLine("Regret approach (Min of Max )");
                        //getting max of each cloumn and creat the Regrat table 
                        for (int z = 0; z < column; z++)
                        {
                                max = payoff_table[0, z];

                                for (int i = 0; i < row; i++)
                                {

                                    if (max < payoff_table[i, z])
                                        max = payoff_table[i, z];
                                    
                                }

                                for (int x = 0; x < row; x++)
                                {
                                    Max[z] = max;
                                    element = Max[z] - payoff_table[x, z];
                                    Regret_table[x, z] = element;
                                    
                                }
                            
                        }
                        
                        //print Regret table
                        for (int i = 0; i < row; i++)
                        {
                            for (int x = 0; x < column; x++)
                            {
                                Console.Write("\t" + Regret_table[i, x]+ "\t");
                            }
                            Console.WriteLine();
                        }

                        //gettin the Max
                        for (int i = 0; i < row; i++)
                        {
                            max = Regret_table[i, 0];
                            for (int n = 0; n < column; n++)
                            {

                                if (max < Regret_table[i, n])
                                    max = Regret_table[i, n];
                            }
                            for (int x = i; x < row; x++)
                            {
                                Max[x] = max;
                            }
                        }
                        //gettin the Min 
                        for (int i = 0; i < 1; i++)
                        {
                            Console.WriteLine("The answer is: " + Max.Min() + "\n");

                        }
                    }
                    else
                    {
                        //Optimistic approach
                        Console.WriteLine("Optimistic approach (Min of Min)");
                        //gettin the Min
                        for (int i = 0; i < row; i++)
                        {
                            min = payoff_table[i, 0];
                            for (int n = 0; n < column; n++)
                            {

                                if (min > payoff_table[i, n])
                                    min = payoff_table[i, n];
                            }
                            for (int x = i; x < row; x++)
                            {
                                Min[x] = min;
                            }
                        }
                        //gettin the Min
                        for (int i = 0; i < 1; i++)
                        {
                            Console.WriteLine("The answer is: " + Min.Min() + "\n");

                        }
                        //Pessimistic approach
                        Console.WriteLine("Pessimistic approach (Min of Max)");
                        //gettin the Max
                        for (int i = 0; i < row; i++)
                        {
                            max = payoff_table[i, 0];
                            for (int n = 0; n < column; n++)
                            {

                                if (max < payoff_table[i, n])
                                    max = payoff_table[i, n];
                            }
                            for (int x = i; x < row; x++)
                            {
                                Max[x] = max;
                            }
                        }
                        //gettin the Min
                        for (int i = 0; i < 1; i++)
                        {
                            Console.WriteLine("The answer is: " + Max.Min() + "\n");

                        }
                        //Regret approach
                        Console.WriteLine("Regret approach (Min of Max )");
                        //getting min of each cloumn and creat the Regrat table 
                        for (int z = 0; z < column; z++)
                        {
                            min = payoff_table[0, z];

                            for (int i = 0; i < row; i++)
                            {

                                if (min > payoff_table[i, z])
                                    min = payoff_table[i, z];

                            }

                            for (int x = 0; x < row; x++)
                            {
                                Min[z] = min;
                                element = Min[z] - payoff_table[x, z];
                                Regret_table[x, z] = Math.Abs(element);

                            }

                        }

                        //print Regret table
                        for (int i = 0; i < row; i++)
                        {
                            for (int x = 0; x < column; x++)
                            {
                                Console.Write("\t" + Regret_table[i, x]+ "\t");
                            }
                            Console.WriteLine();
                        }

                        //gettin the Max
                        for (int i = 0; i < row; i++)
                        {
                            max = Regret_table[i, 0];
                            for (int n = 0; n < column; n++)
                            {

                                if (max < Regret_table[i, n])
                                    max = Regret_table[i, n];
                            }
                            for (int x = i; x < row; x++)
                            {
                                Max[x] = max;
                            }
                        }
                        //gettin the Min 
                        for (int i = 0; i < 1; i++)
                        {
                            Console.WriteLine("The answer is: " + Max.Min() + "\n");

                        }
                    }

                    break;


                case "Risk": case "With Probability":
                case "risk": case "with probability":
                    double[] Pro = new double[column];
                    double[] EMV = new double[row];
                    double[] Sum = new double[row];
                    double sum = 0;
                    for (int i = 0; i < column; i++)
                    {
                        Console.WriteLine("Enter Probability");
                        double pro = Convert.ToDouble(Console.ReadLine());
                        Pro[i] = pro;
                    }
                    Console.WriteLine();
                    for (int i = 0; i < column; i++)
                    {
                        for (int x = 0; x < column; x++)
                        {
                            double d = payoff_table[i, x] * Pro[x];
                            sum += d;
                            EMV[i] = sum;
                        }
                        sum = 0;
                    }
                    Console.Write("EMV : ");

                    for (int x = 0; x < column; x++)
                    {

                        Console.Write(EMV[x] + "\t");

                    }
                    Console.WriteLine(); 
                   Console.WriteLine("EMV Max is : " + EMV.Max());


                    for (int z = 0; z < column; z++)
                    {
                        max = payoff_table[0, z];

                        for (int i = 0; i < row; i++)
                        {

                            if (max < payoff_table[i, z])
                                max = payoff_table[i, z];

                        }

                        for (int x = 0; x < 1; x++)
                        {
                            Max[z] = max;
                            element = Max[z] * Pro[z];
                            Sum[z] = element;

                        }
                    }
                    Console.WriteLine("EVPI = " +( Sum.Sum()- EMV.Max()));

                    break;

            }

        }
    }
}
