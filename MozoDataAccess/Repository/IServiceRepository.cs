using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MozoModels.Models;

namespace MozoDataAccess.Repository
{
	public interface IServiceRepository <T> where T: BaseEntity_Service
	{
		IEnumerable<T> GetAll();
		T Get(long id);
		
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
		IEnumerable<T> GetAllDDL(long id);




	}
	
}
