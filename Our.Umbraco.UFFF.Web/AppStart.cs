using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our.Umbraco.UFFF.Web
{
    class AppStart
    {
        public CreateSchema()
        {
            using (var scope = _scopeProvider.CreateScope())
            {
                var result = CreateSchemaAndData(scope);
                scope.Complete();

                if (result.Success == false)
                {
                    throw new Exception("The database failed to install. ERROR: " + result.Message);
                }
            }
        }
    }
}
