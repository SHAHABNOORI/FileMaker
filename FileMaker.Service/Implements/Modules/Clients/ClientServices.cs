using System;
using System.Threading.Tasks;
using FileMaker.Commands.Modules.Clients;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Domain.Models;
using FileMaker.Infrastructure;
using FileMaker.Infrastructure.ViewModels.Clients;
using FileMaker.Infrastructure.ViewModels.Origins;
using FileMaker.Service.Bases;
using FileMaker.Service.Interfaces.Modules.Clients;

namespace FileMaker.Service.Implements.Modules.Clients
{
    public class ClientServices : ApplicationService, IClientServices
    {
        public ClientServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Result> CreateClientBaseInfoAsyn(CreateClientBaseInfoCommand command)
        {
            try
            {
                var origin = await UnitOfWork.OriginsRepository.FirstOrDefaultAsync(o => o.Id == command.OriginId);
                await UnitOfWork.ClientRepository.AddAsync(new Client()
                {
                    ClientCategory = command.ClientCategory,
                    Dob = command.Dob,
                    Gender = command.Gender,
                    Origin = origin,
                    Name = command.Name,
                    NickName = command.NickName,
                    Photo = command.Photo,
                    Salesman = command.Salesman,
                    Relation = command.Relation,
                    Surname = command.Surname,
                    Title = command.Title,
                    Status = command.Status,
                    SexualOrientation = command.SexualOrientation
                });
                var result = await UnitOfWork.CompleteAsync();
                return result == 0 ? GenerateSuccessResult("ثبت", null) :
                    GenerateFaidResult("ثبت");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Result> GetClientBaseInfoByClientCode(int id)
        {
            var result = await UnitOfWork.ClientRepository.GetClientBaseInfoByClientCode(id);
            if (result == null)
                return GenerateFaidResult("کلاینت مورد نظر یافت نشد");
            var viewModel = new ClientBaseInfoViewModel()
            {
                Origin = new OriginViewModel()
                {
                    Id = result.Origin.Id,
                    OriginName = result.Origin.OriginName
                },
                ClientCategory = result.ClientCategory,
                ClientCode = result.ClientCode,
                Dob = result.Dob,
                Gender = result.Gender,
                Name = result.Name,
                NickName = result.NickName,
                Photo = result.Photo,
                Relation = result.Relation,
                Status = result.Status,
                Salesman = result.Salesman,
                Surname = result.Surname,
                SexualOrientation = result.SexualOrientation,
                Title = result.Title
            };
            return GenerateSuccessResult("دریافت", viewModel);
        }

        public async Task<Result> UpdateClientBaseInfoAsyn(UpdateClientBaseInfoCommand command)
        {
            var selectedClient = await UnitOfWork.ClientRepository.GetClientInfoByClientCode(command.ClientCode);
            if (selectedClient == null)
                return GenerateFaidResult("کلاینت مورد نظر یافت نشد");
            var origin =
                await UnitOfWork.OriginsRepository.FirstOrDefaultAsync(o => o.Id == command.OriginId);

            selectedClient.Origin = origin;
            selectedClient.ClientCategory = command.ClientCategory;
            selectedClient.Dob = command.Dob;
            selectedClient.Gender = command.Gender;
            selectedClient.Name = command.Name;
            selectedClient.NickName = command.NickName;
            selectedClient.Photo = command.Photo;
            selectedClient.Relation = command.Relation;
            selectedClient.Status = command.Status;
            selectedClient.Salesman = command.Salesman;
            selectedClient.Surname = command.Surname;
            selectedClient.SexualOrientation = command.SexualOrientation;
            selectedClient.Title = command.Title;

            UnitOfWork.Update(selectedClient);
            var result = await UnitOfWork.CompleteAsync();
            return result == 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }

        public async Task<Result> CreateClientContactInfoAsyn(CreateClientContactInfoCommand command)
        {

            var selectedClient = await UnitOfWork.ClientRepository.GetClientBaseInfoByClientCode(command.ClientCode);
            if (selectedClient == null)
                return GenerateFaidResult("کلاینت مورد نظر یافت نشد");
            selectedClient.ClientAddress = new ClientAddress()
            {
                Address = command.ClientAddress.Address,
                BussinesAddress = command.ClientAddress.BussinesAddress,
                City = command.ClientAddress.City,
                PostalCode = command.ClientAddress.PostalCode,
                Town = command.ClientAddress.Town
            };
            selectedClient.ClientDeliveryAddress = new ClientDeliveryAddress()
            {
                PostalCode = command.ClientDeliveryAddress.PostalCode,
                Town = command.ClientDeliveryAddress.Town,
                Address = command.ClientDeliveryAddress.Address,
                City = command.ClientDeliveryAddress.City,
                Name = command.ClientDeliveryAddress.Name,
                PhoneNumber = command.ClientDeliveryAddress.PhoneNumber
            };
            selectedClient.ClientContact = new ClientContact()
            {
                PhoneNumber = command.ClientContact.PhoneNumber,
                ContactType = command.ClientContact.ContactType,
                EmailAddress = command.ClientContact.EmailAddress,
                HomeNumber = command.ClientContact.HomeNumber,
                MobileNumber = command.ClientContact.MobileNumber,
                OkToContact = command.ClientContact.OkToContact,
                Website = command.ClientContact.Website
            };

            UnitOfWork.Update(selectedClient);
            var result = await UnitOfWork.CompleteAsync();
            return result == 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }

        public async Task<Result> GetClientInfoByClientCode(int id)
        {
            var selectedClient = await UnitOfWork.ClientRepository.GetClientInfoByClientCode(id);
            if (selectedClient == null)
                return GenerateFaidResult("کلاینت مورد نظر یافت نشد");
            var viewModel = new ClientInfoViewModel()
            {
                Origin = new OriginViewModel()
                {
                    Id = selectedClient.Origin.Id,
                    OriginName = selectedClient.Origin.OriginName
                },
                ClientCategory = selectedClient.ClientCategory,
                ClientCode = selectedClient.ClientCode,
                Dob = selectedClient.Dob,
                Gender = selectedClient.Gender,
                Name = selectedClient.Name,
                NickName = selectedClient.NickName,
                Photo = selectedClient.Photo,
                Relation = selectedClient.Relation,
                Status = selectedClient.Status,
                Salesman = selectedClient.Salesman,
                Surname = selectedClient.Surname,
                SexualOrientation = selectedClient.SexualOrientation,
                Title = selectedClient.Title
            };
            if (selectedClient.ClientAddress != null)
            {
                viewModel.ClientAddress = new ClientAddressViewModel()
                {
                    City = selectedClient.ClientAddress.City,
                    Town = selectedClient.ClientAddress.Town,
                    Address = selectedClient.ClientAddress.Address,
                    PostalCode = selectedClient.ClientAddress.PostalCode,
                    BussinesAddress = selectedClient.ClientAddress.BussinesAddress
                };
            }

            if (selectedClient.ClientContact != null)
            {
                viewModel.ClientContact = new ClientContactViewModel()
                {
                    ContactType = selectedClient.ClientContact.ContactType,
                    PhoneNumber = selectedClient.ClientContact.PhoneNumber,
                    EmailAddress = selectedClient.ClientContact.EmailAddress,
                    HomeNumber = selectedClient.ClientContact.HomeNumber,
                    MobileNumber = selectedClient.ClientContact.MobileNumber,
                    Website = selectedClient.ClientContact.Website,
                    OkToContact = selectedClient.ClientContact.OkToContact
                };
            }

            if (selectedClient.ClientDeliveryAddress != null)
            {
                viewModel.ClientDeliveryAddress = new ClientDeliveryAddressViewModel()
                {
                    Town = selectedClient.ClientDeliveryAddress.Town,
                    City = selectedClient.ClientDeliveryAddress.City,
                    Address = selectedClient.ClientDeliveryAddress.Address,
                    PostalCode = selectedClient.ClientDeliveryAddress.PostalCode,
                    PhoneNumber = selectedClient.ClientDeliveryAddress.PhoneNumber,
                    Name = selectedClient.ClientDeliveryAddress.Name
                };
            }

            return GenerateSuccessResult("دریافت", viewModel);
        }

        public async Task<Result> CreateClientPurchaceInfoAsyn(CreateClientPurchaceInformationCommand command)
        {
            var selectedClient = await UnitOfWork.ClientRepository.GetClientBaseInfoByClientCode(command.ClientCode);
            if (selectedClient == null)
                return GenerateFaidResult("کلاینت مورد نظر یافت نشد");

            selectedClient.ClientPurchase = new ClientPurchase()
            {
                Balance = command.ClientPurchaceInformation.Balance,
                Credit = command.ClientPurchaceInformation.Credit,
                Discount = command.ClientPurchaceInformation.Discount,
                PaymentMethod = command.ClientPurchaceInformation.PaymentMethod,
                PaymentTerms = command.ClientPurchaceInformation.PaymentTerms,
                Pricing = command.ClientPurchaceInformation.Pricing,
                Vat = command.ClientPurchaceInformation.Vat
            };

            selectedClient.ClientExtraInformation = new ClientExtraInformation()
            {
                ContactNumber = command.ClientExtraInformation.ContactNumber,
                Name = command.ClientExtraInformation.Name,
                Ntk = command.ClientExtraInformation.Ntk,
                RelationShip = command.ClientExtraInformation.RelationShip
            };

            selectedClient.ClientPayment = new ClientPayment()
            {
                Name = command.ClientPayment.Name,
                DateOfReferral = command.ClientPayment.DateOfReferral,
                GpsAddress = command.ClientPayment.GpsAddress,
                GpsName = command.ClientPayment.GpsName,
                GpsNumber = command.ClientPayment.GpsNumber,
                OtherReqirments = command.ClientPayment.OtherReqirments,
                ReasonForRefrral = command.ClientPayment.ReasonForRefrral,
                ReferralBy = command.ClientPayment.ReferralBy,
                ReferralFor = command.ClientPayment.ReferralFor,
                ReferralTel = command.ClientPayment.ReferralTel,
                Therapist = command.ClientPayment.Therapist
            };

            UnitOfWork.Update(selectedClient);
            var result = await UnitOfWork.CompleteAsync();
            return result == 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }
    }
}