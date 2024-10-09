using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.UserId = command.UserId;
            values.Name = command.Name;
            values.Surname = command.Surname;
            values.Email = command.Email;
            values.Phone = command.Phone;
            values.Country = command.Country;
            values.District = command.District;
            values.City = command.City;
            values.Detail1 = command.Detail1;
            values.Detail2 = command.Detail2;
            values.Description = command.Description;
            values.ZipCode = command.ZipCode;

            await _repository.UpdateAsync(values);
        }
    }
}
