using DataAccess.Models;
using DataAccess.SqlDbConnection;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.ServiceModel;
using WcfMsmqService.Interfaces;

namespace WcfMsmqService.Services
{
    public class AcademicService:IAcademicService
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olexi\TestDb.mdf;Integrated Security=True;Connect Timeout=30";
        public static Lazy<SqlDbConnectionUnitOfWork> UnitOfWork = new Lazy<SqlDbConnectionUnitOfWork>(() => new SqlDbConnectionUnitOfWork(connectionString));

        #region Train

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void CreateTrain(string driver)
        {
            try
            {
                Console.WriteLine("Recieved train: " + driver);

                _ = UnitOfWork.Value.TrainRepostitory.CreateAsync(JsonConvert.DeserializeObject<Train>(driver)).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void UpdateTrain(string driver)
        {
            try
            {
                Console.WriteLine("Recieved updated train: " + driver);
                var driverObj = JsonConvert.DeserializeObject<Train>(driver);

                var guid = driverObj.Id;
                var item = UnitOfWork.Value.TrainRepostitory.GetAllEntitiesAsync().Result.FirstOrDefault(x => x.Id == guid);

                item.Name = driverObj.Name;
                item.AmountOfCarts = driverObj.AmountOfCarts;

                _ = UnitOfWork.Value.TrainRepostitory.UpdateAsync(item).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void RemoveTrain(string driverId)
        {
            try
            {
                Console.WriteLine("Remove train with id: " + driverId);
                var guid = Guid.Parse(driverId);
                UnitOfWork.Value.TrainRepostitory.DeleteAsync(guid);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        #endregion

        #region Cart

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void CreateCart(string shift)
        {
            try
            {
                Console.WriteLine("Recieved cart: " + shift);

                _ = UnitOfWork.Value.CartRepository.CreateAsync(JsonConvert.DeserializeObject<Cart>(shift)).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void UpdateCart(string shift)
        {
            try
            {
                Console.WriteLine("Recieved updated cart: " + shift);
                var shiftObj = JsonConvert.DeserializeObject<Cart>(shift);

                var guid = shiftObj.Id;
                var item = UnitOfWork.Value.CartRepository.GetAllEntitiesAsync().Result.FirstOrDefault(x => x.Id == guid);

                item.MaxCapacity = shiftObj.MaxCapacity;
                item.Name = shiftObj.Name;
                item.TrainId = shiftObj.TrainId;

                _ = UnitOfWork.Value.CartRepository.UpdateAsync(item).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void RemoveCart(string shiftId)
        {
            try
            {
                Console.WriteLine("Remove cart with id: " + shiftId);
                var guid = Guid.Parse(shiftId);
                _ = UnitOfWork.Value.CartRepository.DeleteAsync(guid).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        #endregion

        #region Ticket

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void CreateTicket(string route)
        {
            try
            {
                Console.WriteLine("Recieved ticket: " + route);

                var routeObj = JsonConvert.DeserializeObject<Ticket>(route);


                _ = UnitOfWork.Value.TicketRepository.CreateAsync(routeObj).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void UpdateTicket(string route)
        {
            try
            {
                Console.WriteLine("Recieved updated ticket: " + route);
                var routeObj = JsonConvert.DeserializeObject<Ticket>(route);

                var guid = routeObj.Id;

                var item = UnitOfWork.Value.TicketRepository.GetAllEntitiesAsync().Result.FirstOrDefault(x => x.Id == guid);

                item.DepartureTime = routeObj.DepartureTime;
                item.DepartureStation = routeObj.DepartureStation;
                item.ArrivalStation = routeObj.ArrivalStation;
                item.ArrivalDate = routeObj.ArrivalDate;
                item.CartId = routeObj.CartId;
                item.PassangerId = routeObj.PassangerId;


                _ = UnitOfWork.Value.TicketRepository.UpdateAsync(item).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void RemoveTicket(string routeId)
        {
            try
            {
                Console.WriteLine("Remove ticket with id: " + routeId);
                var guid = Guid.Parse(routeId);
                _ = UnitOfWork.Value.TicketRepository.DeleteAsync(guid).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        #endregion
    }
}
