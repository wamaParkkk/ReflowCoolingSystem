namespace ReflowCoolingSystem
{
    public enum MODULE
    {
        _PM1 = 0,    
        _PM2 = 1
    }

    public enum Page
    {
        LogInPage = 0,        
        MaintnancePage = 1,        
        ConfigurePage = 2,        
        EventLogPage = 3,
        UserRegist = 4
    }

    public enum DigitalOffOn
    {
        Off = 0,
        On = 1
    }

    // CONFIGURE LIST //////////////////////////////////////
    public class Configure_List
    {        
        public static int Stabilization_Time = 0;        
    }
    ////////////////////////////////////////////////////////
    
    class Define
    {
        public const int BUFSIZ = 512;
        public const int MODULE_MAX = 2;
        public const int OUT_CH_MAX = 4;        

        // Login 여부
        public static bool bLogin = false;

        // User info
        public static string UserId = "";
        public static string UserName = "";
        public static string UserLevel = "";


        public static bool bMainActivate = false;
        public static byte currentPage = 0;

        // Eventlog 발생 여부
        public static bool bPM1Event;        

        // Sequence에서 사용 할 변수
        // PM1, PM2 Process seq//////////////////////////
        public static byte[] seqMode = { 0, 0 };
        public static byte[] seqCtrl = { 0, 0 };
        public static byte[] seqSts = { 0, 0 };

        public const byte MODE_IDLE = 0;
        public const byte MODE_PROCESS = 1;
        public const byte MODE_INIT = 2;

        public const byte CTRL_IDLE = 0;
        public const byte CTRL_RUN = 1;
        public const byte CTRL_RUNNING = 2;
        public const byte CTRL_ALARM = 3;
        public const byte CTRL_RETRY = 4;
        public const byte CTRL_HOLD = 5;
        public const byte CTRL_ABORT = 6;

        public const byte STS_IDLE = 0;
        public const byte STS_PROCESS_ING = 1;
        public const byte STS_PROCESS_END = 2;
        public const byte STS_INIT_ING = 3;
        public const byte STS_INIT_END = 4;
        public const byte STS_ABORTOK = 5;
        /////////////////////////////////////////////////       

        // 장비 MNBR
        public static string EQ_MNBR_1 = "36798";   // SBA
    }
}
