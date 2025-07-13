using AspnetCoreMvcFull2.Models;
using AspnetCoreMvcFull2.Models.Context;
using AspnetCoreMvcFull2.Models.Dto;

namespace AspnetCoreMvcFull2
{
    public interface IFinancialService
    {
        Task SaveFinancialInformation(FinancialInformationViewModel model);
    }

    public class FinancialService : IFinancialService
    {
        private readonly AspnetCoreMvcFull2Context _context;

        public FinancialService(AspnetCoreMvcFull2Context context)
        {
            _context = context;
        }

        public async Task SaveFinancialInformation(FinancialInformationViewModel model)
        {
            // Burada model verilerini veritabanına kaydetme işlemleri yapılır
            // Örnek:
            var financialInfo = new FinancialInformation
            {
                PaymentMethod = model.NewFinancialInformation.PaymentMethod,
                Iban = model.NewFinancialInformation.PaymentMethod == "iban" || model.NewFinancialInformation.PaymentMethod == "eft" ? model.NewFinancialInformation.Iban : null,
                EFTIban = model.NewFinancialInformation.PaymentMethod == "eft" ? model.NewFinancialInformation.EFTIban : null,
                BankaAdi = model.NewFinancialInformation.PaymentMethod == "eft" ? model.NewFinancialInformation.BankaAdi : null,
                PayfixTel = model.NewFinancialInformation.PayfixTel,
                PaparaTel = model.NewFinancialInformation.PaymentMethod == "papara" ? model.NewFinancialInformation.PaparaTel : model.NewFinancialInformation.PayfixTel,
                PaparaNo = model.NewFinancialInformation.PaparaNo,
                PayfixNo = model.NewFinancialInformation.PayfixNo,
                CryptoWallet = model.NewFinancialInformation.CryptoWallet,
                CoinCesidi = model.NewFinancialInformation.CoinCesidi,
                ParaBirimi = model.NewFinancialInformation.ParaBirimi,
                AdSoyad = model.NewFinancialInformation.AdSoyad,
                Aciklama = model.NewFinancialInformation.Aciklama,
                CreateDate = DateTime.Now
            };

            _context.FinancialInformations.Add(financialInfo);
            await _context.SaveChangesAsync();
        }
    }
}
