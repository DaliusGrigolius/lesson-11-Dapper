using Dapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DarbuotojasController : ControllerBase
    {
        [HttpGet("/Gauti visus darbuotojus")]
        public List<string> GetAllData()
        {
            var connectionString = $"Server=localhost;Database=AdventureWorksDW2019;Trusted_Connection=True;";
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var procedure = "[GautiDarbuotojus]";
            var data = connection.Query<Darbuotojas>(procedure, commandType: System.Data.CommandType.StoredProcedure);
            connection.Close();
            List<string> listas = new List<string>();
            foreach (var row in data)
            {
                listas.Add($"Asmens kodas: {row.ASMENSKODAS} " +
                                  $"Vardas: {row.VARDAS} " +
                                  $"Pavarde: {row.PAVARDE} " +
                                  $"Dirba nuo: {row.DIRBANUO} " +
                                  $"Gimimo metai: {row.GIMIMOMETAI} " +
                                  $"Skyriaus pavadinimas: {row.SKYRIUS_PAVADINIMAS} " +
                                  $"Projekto ID: {row.PROJEKTAS_ID}");
            }

            return listas;
        }

        [HttpPost("/Prideti nauja darbuotoja")]
        public void AddDarbuotojas(string asmensKodas, string vardas, 
                                      string pavarde, DateTime dirbaNuo, DateTime gimimoMetai,
                                      string pareigos, string skyriusPavadinimas, int projektasId)
        {
            var connectionString = $"Server=localhost;Database=AdventureWorksDW2019;Trusted_Connection=True;";
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var procedure = "[IterptiNaujaDarbuotoja]";
            var values = new { asmens_kodas = asmensKodas, vardas = vardas, 
                               pavarde = pavarde, dirba_nuo = dirbaNuo,
                               gimimo_data = gimimoMetai, pareigos = pareigos,
                               skyriaus_pavadinimas = skyriusPavadinimas, projekto_numeris = projektasId};
            var data = connection.Query<Darbuotojas>(procedure, values, commandType: System.Data.CommandType.StoredProcedure);
            connection.Close();
        }
    }
}
