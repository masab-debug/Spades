using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spades
{
    class Class1
    {
        private static string session;
        private static int session_id;
        private static string session_dept;
        private static int staff_session_id;
        private static string department_session;
        private static string staff_username;


        public static string Session
        {
            get { return session; }
            set { session = value; }
        }

        public static int Session_id
        {
            get { return session_id; }
            set { session_id = value; }
        }

        public static string Session_dept
        {
            get { return session_dept; }
            set { session_dept = value; }
        }

        public static int staff_session
        {
            get { return staff_session_id; }
            set { staff_session_id = value; }
        }

        public static string staff_dept_session
        {
            get { return department_session; }
            set { department_session = value; }
        }

        public static string staff_username_session
        {
            get { return staff_username; }
            set { staff_username = value; }
        }
    }
}
