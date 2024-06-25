namespace ContractorDocuments.Domain.Entities.Accounting
{
    public class CashReceiptsEntity : BaseEntity
    {
        public required decimal Amount { get; set; }
        public required DateTime PiaidOn { get; set; }
        public required PaymentMethodType PaymentMethodTypeId { get; set; }
        /// <summary>
        /// شناسه پرداخت، کد تراکنش
        /// </summary>
        public string? TransactionId { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        #region Relations



        #endregion

        #region Ctor



        #endregion
    }
}