using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaaurantApp_BL.Repository;
using RestaurantApp_Model.Entities;

namespace RestaaurantApp_BL.Services
{
    public interface ITableService
    {
         Task<List<TableModal>> GetTables();
        Task<TableModal> AddTable(TableModal table);

        Task<TableModal> UpdateTable(TableModal table);

        Task<bool> DeleteTable(int id);
    }
    public class TableService(ITableRespository tableRepository) : ITableService
    {
        public Task<List<TableModal>> GetTables()
        {
            return tableRepository.GetTables();
        }
        //psot for table
        public Task<TableModal> AddTable(TableModal table)
        {
            return tableRepository.AddTable(table);
        }

        //update
        public Task<TableModal> UpdateTable(TableModal table)
        {
            return tableRepository.UpdateTable(table);
        }

        //delete
        public Task<bool> DeleteTable(int id)
        {
            return tableRepository.DeleteTable(id);
        }

    }
}
