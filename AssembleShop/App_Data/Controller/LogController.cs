using System.Web.UI.WebControls;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AgendaTarefas
{
    public class LogController
    {

        public static void InserirLog(Exception exception)
        {
            SDBC.Instance.Database.ExecuteSqlCommand("LOG_INSERIR {0}, {1}", new object[] { exception.StackTrace, exception.Message });
        }

    }
}
