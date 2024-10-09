using FluentValidation;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;

namespace MultiShop.Cargo.BusinessLayer.ValidationRules
{
    public class CreateCargoCustomerDtoValidator : AbstractValidator<CreateCargoCustomerDto>
    {
        public CreateCargoCustomerDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş olamaz");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Geçerli bir email adresi giriniz");
            RuleFor(x => x.Phone).NotEmpty().Matches(@"^[0-9]{10}$").WithMessage("Geçerli bir telefon numarası giriniz");
            RuleFor(x => x.District).NotEmpty().WithMessage("İlçe boş olamaz");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir boş olamaz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş olamaz");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı ID boş olamaz");
        }
    }
}
