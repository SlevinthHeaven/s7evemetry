using S7evemetry.F1_2019.Listeners;
using System.Threading;

namespace S7evemetry.Console._2019
{
    public class F1_2019_DataVisualizer
    {
        private static readonly object SyncRoot = new object();

        private readonly F1_2019Listener _f1_2019Listener;
        private readonly F1_2019_Event _f1_2019_Event;
        private readonly F1_2019_Motion _f1_2019_Motion;
        private readonly F1_2019_Telemetry _f1_2019_Telemetry;

        public F1_2019_DataVisualizer(
            F1_2019Listener f1_2019Listener,
            F1_2019_Event f1_2019_Event,
            F1_2019_Motion f1_2019_Motion,
            F1_2019_Telemetry f1_2019_Telemetry
            )
        {
            _f1_2019Listener = f1_2019Listener;
            _f1_2019_Event = f1_2019_Event;
            _f1_2019_Motion = f1_2019_Motion;
            _f1_2019_Telemetry = f1_2019_Telemetry;
        }

        public void Start()
        {
            InitializeUI();
            _f1_2019_Event.Subscribe(_f1_2019Listener);
            _f1_2019_Motion.Subscribe(_f1_2019Listener);
            _f1_2019_Telemetry.Subscribe(_f1_2019Listener);
            _f1_2019Listener.Listen(new CancellationTokenSource().Token);
        }

        public void Stop()
        {
            _f1_2019_Event.Unsubscribe();
            _f1_2019_Motion.Unsubscribe();
            _f1_2019_Telemetry.Unsubscribe();
        }

        protected virtual void InitializeUI()
        {
            lock (SyncRoot)
            {
                System.Console.Clear();
                System.Console.CursorTop = 0;
                System.Console.CursorLeft = 0;
                System.Console.CursorVisible = false;

                System.Console.WriteLine("Race XXX Car XXXXXXXXXXX Class X Index XXX Drivetrain XXX Cylinders XX");
                System.Console.WriteLine("Lap XXX Position XX Fuel XXXXX % Distance XXXXX KM Race X.XX:XX:XX.XXX");
                System.Console.WriteLine();
                System.Console.WriteLine("Current XXXXX RPM   Speed  XXXXX.X KPH   Cur. lap X.XX:XX:XX.XXX");
                System.Console.WriteLine("Idle    XXXXX RPM   Speed  XXXXX.X KPH   Last lap X.XX:XX:XX.XXX");
                System.Console.WriteLine("Maximum XXXXX RPM   Speed  XXXXX.X MPH   Best lap X.XX:XX:XX.XXX");
                System.Console.WriteLine();
                System.Console.WriteLine("                X(right)       Y(up)  Z(forward)   Accelerator XXX %");
                System.Console.WriteLine("Acceleration XXXXXXXXXXX XXXXXXXXXXX XXXXXXXXXXX   Brake       XXX %");
                System.Console.WriteLine("Velocity     XXXXXXXXXXX XXXXXXXXXXX XXXXXXXXXXX   Clutch      XXX %");
                System.Console.WriteLine("                                                   Handbrake   XXX %");
                System.Console.WriteLine("                     Yaw       Pitch        Roll   Gear        XXX");
                System.Console.WriteLine("Position     XXXXXXXXXXX XXXXXXXXXXX XXXXXXXXXXX   Steer       XXX %");
                System.Console.WriteLine("Ang.Velocity XXXXXXXXXXX XXXXXXXXXXX XXXXXXXXXXX");
            }
        }
    }
}
