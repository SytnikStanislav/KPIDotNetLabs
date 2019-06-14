using System.ServiceModel;

namespace WcfMsmqService.Interfaces
{
    [ServiceContract]
    public interface IAcademicService
    {
        #region Train
        [OperationContract(IsOneWay = true)]
        void CreateTrain(string Subject);

        [OperationContract(IsOneWay = true)]
        void UpdateTrain(string updatedSubject);

        [OperationContract(IsOneWay = true)]
        void RemoveTrain(string SubjectId);
        #endregion

        #region Cart
        [OperationContract(IsOneWay = true)]
        void CreateCart(string Group);

        [OperationContract(IsOneWay = true)]
        void UpdateCart(string updatedGroup);

        [OperationContract(IsOneWay = true)]
        void RemoveCart(string GroupId);
        #endregion

        #region Ticket
        [OperationContract(IsOneWay = true)]
        void CreateTicket(string SiG);

        [OperationContract(IsOneWay = true)]
        void UpdateTicket(string updatedSiG);

        [OperationContract(IsOneWay = true)]
        void RemoveTicket(string SiGId);
        #endregion
    }
}
