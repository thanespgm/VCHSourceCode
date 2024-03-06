using System.Collections;

namespace ConHIS
{
    internal static class Variable
    {
        //Variables related to all databases.
        public static string DBlocal = null;       //The Variable stores the connection string set to connect to the local database.

        public static string DBhost = null;        //The Variable stores the connection string set to connect to the host interface database.

        //Variable related to all text file.
        public static string PathLocal;            //Path Folder Text

        public static string PathHost;             //Path Folder Text
        public static string PathLogs;             //Path Folder Text for System Log

        public static Queue SysQueue = new Queue();  //The Variable stores the display System logs.
        public static string TextFileName;           //The Variable stores the file name.
        public static bool ClearBackup = false;              //The Variable stores the after transaction data.
                                                             // public static string ToMachineNo;               //The Variable status for Thanes Medical Device.

        //Variable related to Settings Program.
        public static bool OnStartTextFile = false;

        public static string errorStrLog = "";
        public static char SeparatorPattren;
        public static int TmtoRetrieve;
        public static int ReadFileWait;
        public static int Encode_Separator;
        public static string pathfileErrorAccess;
        public static string InterfaceMode = "";
        public static string ServerHosXP;
        public static string ServerDBType;

        //for hosxp
        public static string referrenceCode;
    }
}