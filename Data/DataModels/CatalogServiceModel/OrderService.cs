using DataEntities;

using System;

namespace MvcDataApp.DataEntities.DataServices
{
    public class OrderService<TSaleItem> where TSaleItem: SaleItem
    {

        public virtual SaleOrder<TSaleItem> GetOrder()
        {
            throw new NotImplementedException($"{GetType().GetTypeName()}");
        }

        /// <summary>
        /// Вычисление общей суммы заказа
        /// </summary>            
        public float GetOrderPrice()
        {
            float price = 0;
            foreach (var item in GetOrder().OrderItems)
            {
                price += item.ProductCount * item.ProductCount;
            }
            return price;
        }


        /// <summary>
        /// Выставляем статус при регистрации изделия
        /// </summary>
        public void OnOrderCreated(  )
        {
            GetOrder().OrderStatus = 1;
            GetOrder().OrderUpdated = DateTime.Now;
            GetOrder().UpdateCounter++;
        }

        /// <summary>
        /// Выставляем статус при поступлении на склад
        /// </summary>
        public void OnOrderStored()
        {
            GetOrder().OrderStatus = 2;
            GetOrder().OrderUpdated = DateTime.Now;
            GetOrder().UpdateCounter++;

        }

        /// <summary>
        /// Выставляем статус при передачи курьеру
        /// </summary>
        public void OnOrderIsDelivering()
        {
            GetOrder().OrderStatus = 3;
            GetOrder().OrderUpdated = DateTime.Now;
            GetOrder().UpdateCounter++;
        }

        /// <summary>
        /// Выставляем статус при передачи курьеру
        /// </summary>
        public void OnOrderDelivered()
        {
            GetOrder().OrderStatus = 4;
            GetOrder().OrderUpdated = DateTime.Now;
            GetOrder().UpdateCounter++;
        }


        /// <summary>
        /// Выставляем статус при передачи курьеру
        /// </summary>
        public void OnOrderReceived()
        {
            GetOrder().OrderStatus = 5;
            GetOrder().OrderUpdated = DateTime.Now;
            GetOrder().UpdateCounter++;
        }


        /// <summary>
        /// Выставляем статус при передачи курьеру
        /// </summary>
        public void OnOrderCanceled()
        {
            GetOrder().OrderStatus = 6;
            GetOrder().OrderUpdated = DateTime.Now;
            GetOrder().UpdateCounter++;
        }
    }
}
