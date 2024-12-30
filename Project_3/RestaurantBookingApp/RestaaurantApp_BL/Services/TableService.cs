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

        Task<TableModal> CreateTable(TableModal tableModal);
       
    }
    public class TableService(ITableRespository tableRepository) : ITableService
    {

        public Task<List<TableModal>> GetTables()
        {
            return tableRepository.GetTables();
        }
        public Task<TableModal> CreateTable(TableModal tableModal)
        {
           return tableRepository.CreateTable(tableModal);
        }

        

      

        
    }
}
