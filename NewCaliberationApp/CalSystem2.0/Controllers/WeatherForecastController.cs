using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly string _connStr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.81.20.16)(PORT=1523)))(CONNECT_DATA=(SERVICE_NAME=ESYS5A1Q)));User Id=newsku;Password=newsku;Pooling=true;Min Pool Size=5;Max Pool Size=512;";

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<string>>> TestConnection()
        {
            var emails = new List<string>();
            try
            {
                using (var conn = new OracleConnection(_connStr))
                {
                    await conn.OpenAsync();

                    var query = "SELECT plant FROM users";
                    using (var cmd = new OracleCommand(query, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                emails.Add(reader.GetString(0)); // Assuming Email is the first column
                            }
                        }
                    }
                }
                return Ok(emails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection or query failed: {ex.Message}");
            }
        }
    }
}
