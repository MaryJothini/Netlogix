using NTG.ShipmentManagement.Applicaiton.Contracts.JsonValidators;
using FluentValidation;
using NTG.ShipmentManagement.Applicaiton.Contracts.Persistence;

namespace NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest
{
    internal class ShipmentOderValidator : AbstractValidator<ShipmentOrderCreateDto>
    {
        public ShipmentOderValidator(IShipmentOrderRepository shipmentOrderRepository)
        {
            RuleFor(p => p.OrdetId)
              .NotEmpty()
              .NotNull()
              .WithMessage("{PropertyName} must not be empty.");

            RuleFor(p => p.ShipmentOrderItems)
             .Custom((items, ctx) => {
             
                if(items== null || items.Count==0)
                 {
                     ctx.AddFailure(new FluentValidation.Results.ValidationFailure("Items", "Order has no items", 0));
                 }
             });

            RuleFor(p => p.PickupAddress)
           .Custom((pickup, ctx) => {

               if (pickup == null)
               {
                   ctx.AddFailure(new FluentValidation.Results.ValidationFailure("Items", "Order has no pickup address", pickup));
               }
           });

            RuleFor(p => p.DeliveryAddress)
           .Custom((del, ctx) => {
               if (del == null)
               {
                   ctx.AddFailure(new FluentValidation.Results.ValidationFailure("Items", "Order has no delivery address", del));
               }
           });

            RuleFor(p => p.OrdetId)
              .NotEmpty()
              .MustAsync(async (orderId, token) => {
                  var orderExists = await shipmentOrderRepository.OrderIdExists(orderId);
                  return !orderExists;
              })
              .WithMessage("{PropertyName} already exist.");
        }

    }
}
