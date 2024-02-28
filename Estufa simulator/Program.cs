using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estufa_simulator
{
    internal static class Program
    {
        private static SHA512 hashAlgorithm = SHA512Managed.Create();
        private static byte[] buffer = new byte[int.MaxValue / 2];

        private static void Main(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(IterateUntilFalse(() => true), new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, async ignored =>
                {
                    while (true) hashAlgorithm.ComputeHash(buffer);
                });
            });

            MessageBox.Show(":D | Estufa simulator iniciada, presione ok para apagar la estufa", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static IEnumerable<bool> IterateUntilFalse(Func<bool> condition)
        {
            while (condition()) yield return true;
        }
    }
}