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
        OperationPage = 1,
        MaintnancePage = 2,
        RecipePage = 3,
        ConfigurePage = 4,
        IOPage = 5,
        AlarmPage = 6,
        EventLogPage = 7,
        UserRegist = 8
    }

    public enum Switch
    {
        Off = 0,
        On = 1,
        Buzzer = 3
    }

    // CONFIGURE LIST //////////////////////////////////////
    public class Configure_List
    {        
        public static double iAirBlowTolerance = 0.0;
        public static int iAirFlowTimeOut = 0;
    }
    ////////////////////////////////////////////////////////
    
    class Define
    {
        public const int BUFSIZ = 512;
        public const int MODULE_MAX = 2;
        public const int OUT_CH_MAX = 4;
        public const int RECIPE_MAX_STEP = 5;

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

        public static string sInterlockMsg = "";
        public static string sInterlockChecklist = "";
        public static bool bAlarm1;
        public static bool bAlarm2;
        public static bool bAlarm3;

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

        public static string strDeviceName = string.Empty;        

        // Device 등록 시 선택된 Recipe
        public static string sSelectRecipeName;

        // Run 중인 Recipe
        public static string sRunRecipeName;

        // Volt(Psi) 셋팅 값 공유 (UI, SEQ)
        public static double dCH1PsiSetValue;
        public static double dCH2PsiSetValue;
        public static double dCH3PsiSetValue;

        public static double[] dPsiActValue = { 0.0, 0.0, 0.0 };        

        // 장비(SBA) MNBR, ASSET#
        public static string SBA_MNBR;
        public static string SBA_ASSET;

        // 장비(REFLOW) MNBR, ASSET#
        public static string REFLOW_MNBR;

        // 장비(Reflow) Process state
        public static byte ReflowState;
        public const byte REFLOW_IDLE = 0;
        public const byte REFLOW_RUN = 1;        
    }
}
