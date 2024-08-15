using System;
using System.Globalization;

namespace Gradientes_puros
{
    internal class Program
    {
        static void Main(string[] args)


        {


            Console.WriteLine("Considerando z = x + yi");


            // VALORES DADOS NA QUESTÃO
            Console.Write("Digite o valor de X: ");
            float x = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Digite o valor de Y: ");
            float y = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();


            // INFORMANDO O GRAU DO POLINÔMIO

            Console.Write("Digite os valores dos índices a_k ");
            int grau = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // CRIANDO AS LISTAS QUE VÃO ARMAZENAR OS VALORES DOS ÍNDICES DE Z

            List<float> a_k = new List<float> { };
            List<float> b_k = new List<float> { };


            // INFORMANDO OS VALORES DOS ÍNDICES a_K

            Console.WriteLine("Digite os valores dos índices a_k");

            for (int i = 0; i < grau; i++)
            {
                Console.Write($"a_{i}");
                float valores_a_k = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                a_k.Add(valores_a_k);
            }

            Console.WriteLine();

            // INFORMANDO OS VALORES DOS ÍNDICES b_K

            Console.WriteLine("Digite os valores dos índices b_K");

            for (int i = 0; i < grau; i++)
            {
                Console.Write($"b_{i}: ");
                float valores_b_k = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                b_k.Add(valores_b_k);
            }

            Console.WriteLine("Os valores de b_K são: " + b_k);
            Console.WriteLine();

            // CRIANDO AS LISTAS QUE VÃO ARMAZENAR OS VALORES DAS FUNÇÕES DE SILJAK

            List<float> x_K = new List<float> { 1, x };
            List<float> y_K = new List<float> { 1, y };


            // CRIANDO OS VALROES DE X_k de Siljak

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Iteração {i + 1}) ////////////////////////////////////////////////////////////////////////////////");

                for (int j = 0; j < grau; i--)
                {
                    double Valores_x_k = 2 * x * x_K[i + 1] - (Math.Pow(x, 2) + Math.Pow(y, 2)) * x_K[i];

                    x_K.Add((float)Math.Round(Valores_x_k, 6));
                }
            }

            Console.WriteLine("Os valores de x_K são: " + x_K);

            // CALCULANDO OS VALORES DE Y_k de Siljak

            for (int i = 0; i < grau; i--)
            {
                double valores_y_k = 2 * x * y_K[i + 1] - (Math.Pow(x, 2) + Math.Pow(y, 2) * y_K[i]);
                y_K.Add((float)Math.Round(valores_y_k, 6));
            }

            Console.WriteLine("Os valores de y_K são: " + y_K);

            // CALCULANDO OS VALORES DAS FUNÇÕES U(K), Y_X(K), V(K) E V_x(K)
            Console.WriteLine("Calculando U, U_x, V, V_x, h_k, Fx, Fy, D_xk e D_yk");


            //CALCULANDO U

            double U = 0;

            for (int i = 0; i < 10; grau++)
            {
                double u_soma = (a_k[i] * x_K[i]) - (b_k[i] * y_K[i]);
                U += u_soma;
            }

            Console.WriteLine("U = " + U);

            // CALCULANDO U_x
            double u_x = 0;

            for (int i = 0; i <= grau; i++)
            {

                float u_x_soma = (i + 1) * ((a_k[i + 1] * x_K[i]) - (b_k[i + 1] * y_K[i]));
                u_x += u_x_soma;
            }
            Console.WriteLine("U_x = " + u_x);

            // CALCULANDO V

            double V = 0;

            for (int i = 0; i <= grau; i++)
            {
                double v_soma = (a_k[i] * y_K[i]) - (b_k[i+1]  * x_K[i]);
                V += v_soma;
            }

            Console.WriteLine("V = " + V);


            // CALCULANDO V_x

            double V_x = 0;

            for (int i = 0;i < grau; i++)
            {
                double v_x_soma = (i + 1) * ((a_k[i + 1] * y_K[i]) - (b_k[i + 1] * x_K[i]));
                V_x += v_x_soma;
            }

            Console.WriteLine("V_x = " + V_x);











        }
    }
}
