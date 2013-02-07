using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
    public class Order
    {
        
        public int OrderId { get;private set; }
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { set; get; }
        public string City { set; get; }
        public string State { set; get; }
        public string PostalCode { get; set; }
        public string Country { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public decimal Total 
        {
            get
            {
                return OrderDetails.Sum(x=>x.Price*x.Quatity);
            }
        }
        public List<OrderDetail> OrderDetails { get; private set; }

        public static List<Order> GetOrders()
        {
            List<OrderDetail> detailList = new List<OrderDetail>();
            detailList.Add(new OrderDetail()
            {
                SKU=1138,
                ProductName="手电筒",
                Quatity=2,
                Price=5.20M
            });

            detailList.Add(new OrderDetail()
            {
                SKU = 92135420,
                ProductName = "电纸书阅读器",
                Quatity = 4,
                Price = 2.30M
            });


            List<Order> orderList = new List<Order>();
            orderList.Add(new Order()
            {
                OrderId=20130207,
                OrderDate=DateTime.Parse("2013-02-06"),
                UserName="kabaskimy",
                FirstName="许",
                LastName="星星",
                Address="深圳市南山区",
                City="湖北黄冈",
                State="中国",
                PostalCode="430000",
                Country="蕲春",
                Phone="13620000000",
                Email="test@gmail.com",
                OrderDetails=detailList
            });


            List<OrderDetail> detailList2 = new List<OrderDetail>();
            detailList.Add(new OrderDetail()
            {
                SKU = 7468,
                ProductName = "贴纸",
                Quatity = 200,
                Price = 0.01M
            });

            detailList.Add(new OrderDetail()
            {
                SKU = 92135420,
                ProductName = "电纸书阅读器",
                Quatity = 2,
                Price = 2.30M
            });



            orderList.Add(new Order()
            {
                OrderId=20130206,
                OrderDate=DateTime.Parse("2013-02-05"),
                UserName="kabaskimy",
                FirstName="许",
                LastName="星星",
                Address="深圳市南山区",
                City="湖北黄冈",
                State="中国",
                PostalCode="430000",
                Country="蕲春",
                Phone="13620000000",
                Email="test@gmail.com",
                OrderDetails=detailList
            });
            return orderList;
        }

        public static Order GetOrderById(int Id)
        {
            List<Order> orderList = GetOrders();
            var orderResult = orderList.First(t=>t.OrderId==Id);
            return orderResult;
        }

        public static Order GetDefaultOrder()
        {
            List<Order> orderList = GetOrders();
            var orderResult = orderList.First(t => true);
            return orderResult;
        }

    }

}