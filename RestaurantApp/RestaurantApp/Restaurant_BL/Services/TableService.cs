using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant_BL.Repositories;
using Restaurant_Models.Entities;

namespace Restaurant_BL.Services
{
    public interface ITableServices
    {
        Task<List<TableModel>> GetTables();
        Task<TableModel> CreateTable(TableModel tableModel);

        Task<TableModel> GetTables(int Id);
     

        Task UpdateTable(TableModel tableModel);
        Task DeleteProduct(int Id);
        
        //Task<List<TableModel>> GetAvailableTablesAsync();
        Task<bool> TableModelExistAsync(int Id);

    }
    public class TableService(ITableRepository tablerepository) : ITableServices
    {
        public Task<TableModel> CreateTable(TableModel tableModel)
        {
            return tablerepository.CreateTable(tableModel);
        }

        public Task DeleteProduct(int Id)
        {
            return tablerepository.DeleteProduct(Id);
        }

        public Task<List<TableModel>> GetTables()
        {
           return tablerepository.GetTables();
        }

        public Task<TableModel> GetTables(int Id)
        {
            return tablerepository.GetTables(Id);
        }

        //public Task<List<TableModel>> GetAvailableTablesAsync()
        //{
        //    return tablerepository.GetTablesAsync();
        //}
        public Task<bool> TableModelExistAsync(int Id)
        {
            return tablerepository.TableModelExist(Id);
        }


        public Task UpdateTable(TableModel tableModel)
        {
            return tablerepository.UpdateTable(tableModel);
        }
    }
}
