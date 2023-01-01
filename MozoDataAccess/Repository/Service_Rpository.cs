using Microsoft.EntityFrameworkCore;
using MozoDataAccess.Data;
using MozoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MozoDataAccess.Repository
{
	public class Service_Rpository<T> : IServiceRepository<T> where T : BaseEntity_Service
	{
		private readonly Mozo_Data_Context context;
		private DbSet<T> entities;
		string errorMessage = string.Empty;

		public Service_Rpository(Mozo_Data_Context context)
		{
			this.context = context;
			entities = context.Set<T>();
		}

		public IEnumerable<T> GetAll()
		{
			return entities.AsEnumerable();
		}

		public IEnumerable<T> GetAllDDL(long id)
		{
			return (IEnumerable<T>)entities.AsEnumerable().SingleOrDefault(s=>s.Id==id);
		}

		public T Get(long id)
		{
			return entities.SingleOrDefault(s => s.Id == id);
		}

		
		public void Insert(T entity)
		{
			if(entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			entities.Add(entity);
			context.SaveChanges();
		}

		public void Update(T entity)
		{
			if(entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			context.SaveChanges();

		}

		public void Delete(T entity)
		{
			if(entity==null)
			{
				throw new ArgumentNullException("entity");
			}
			entities.Remove(entity);
			context.SaveChanges();
		}
		public bool  GetByName(string Name)
		{
			Country_Master country = context.Set<Country_Master>().SingleOrDefault(c => c.Country_Name == Name);
			if (country != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
	}
}
