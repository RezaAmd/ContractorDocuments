namespace ContractorDocuments.Domain.Enums
{
    public enum PaymentMethodType
    {
        [Display(Name = "کارت به کارت")]
        CardToCard = 0,
        [Display(Name = "واریز به حساب بانکی")]
        DepositToBankAccount = 5,
        [Display(Name = "چک")]
        Cheque = 10,
        [Display(Name = "نقدی یا کارتخوان")]
        CashOrPos = 15,
        //[Display(Name = "درگاه پرداخت بانک")]
        //BankOnlineGateway = 20,
        //[Display(Name = "ارز دیجیتال")]
        //CryptoCurrency = 25
    }
}