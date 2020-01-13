using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
	public class ProductRepository
	{

		ObjectCache cache = MemoryCache.Default;
		List<Product> products = new List<Product>();

		public ProductRepository()
		{
			products = cache["products"] as List<Product>;
			if (products == null)
			{
				products = new List<Product>();
			}

		}
		public void Comit()
		{
			cache["products"] = products;

		}

		public void insert(Product p)
		{
			products.Add(p);
		}

		public void Update(Product product)
		{
			Product productToUpdate = products.Find(p => p.Id == product.Id);



			if (productToUpdate != null)
			{

				productToUpdate = product;
			}
			else
			{
				throw new Exception("Product Not found");
			}
		}

		public Product Find(string ID)
		{
			Product product = products.Find(p => p.Id == ID);



			if (product != null)
			{

				return product;
			}
			else
			{
				throw new Exception("Product Not found");
			}
		}

		public IQueryable<Product> collection()
		{
			return products.AsQueryable();
		}
	
		public void Delete(string Id)
		{
			Product productTDelete = products.Find(p => p.Id == Id);



			if (productTDelete != null)
			{

				products.Remove(productTDelete);
			}
			else
			{
				throw new Exception("Product Not found");
			}
		}
	}
}

