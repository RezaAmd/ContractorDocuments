﻿namespace ContractorDocuments.Domain.Entities.Accounting
{
    public class ReceiptEntity : BaseEntity
    {
        public required decimal Amount { get; set; }
        public required Guid EntityId { get; set; } // Foreign Key
        public required EntityType EntityTypeId { get; set; } // Relation entity
        public DateTime? PiaidOn { get; set; }
        public PaymentMethodType? PaymentMethodTypeId { get; set; }
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