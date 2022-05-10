﻿using LiepaLimitedTest.Infrastructure.Dapper.Data;

namespace LiepaLimitedTest.Infrastructure.Dapper
{
    public class DapperConfiguration
    {
        private readonly string _table;
        private readonly CommonHelper _helper;
        public DapperConfiguration(string table, CommonHelper helper)
        {
            _table = table;
            _helper = helper;
        }
        public string GetSelectQuery()
        {
            return $"SELECT * FROM {_table}";
        }

        public string GetSelectByIdQuery()
        {
            return $"SELECT * FROM {_table} WHERE Id = @id";
        }
              
        public string GetCreateQuery()
        {
            string insertQuery = _helper.GenerateCreateValuesQuery();
            return $"INSERT INTO {_table} {insertQuery}";
        }

        public string GetUpdateQuery()
        {
            string updateQuery = _helper.GenerateUpdateValuesQuery();
            return $"UPDATE {_table} SET {updateQuery} WHERE Id = @Id";
        }

        public string GetDeleteQuery()
        {
            return $"DELETE FROM {_table} WHERE Id = @id";
        }
    }
}
