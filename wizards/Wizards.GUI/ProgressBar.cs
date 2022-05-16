using System.Threading;
using System.Threading.Tasks;

public class ProgressBar
{
    public static void DisplayProgressBar() 
    {
        ManualResetEventSlim finishEvent = new ManualResetEventSlim();
        finishEvent.Reset();

        DustInTheWind.ConsoleTools.Controls.Spinners.ProgressBar progressBar = new DustInTheWind.ConsoleTools.Controls.Spinners.ProgressBar();

        Task.Run<Task>(async () =>
        {
            progressBar.Display();

            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(100);
                progressBar.Value++;
            }

            finishEvent.Set();
        });

        finishEvent.Wait();

        progressBar.Close();


    }

}