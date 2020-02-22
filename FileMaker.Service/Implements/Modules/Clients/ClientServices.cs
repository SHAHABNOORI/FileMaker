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

        /// <summary>
        /// سرویس ثبت اطلاعات اولیه کلاینت
        /// Client Base Info Create Service
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<Result> CreateClientBaseInfoAsyn(CreateClientBaseInfoCommand command)
        {
            try
            {
                var origin = await UnitOfWork.OriginsRepository.FirstOrDefaultAsync(o => o.Id == command.OriginId);
                var newClient = new Client()
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
                };
                await UnitOfWork.ClientRepository.AddAsync(newClient);
                var result = await UnitOfWork.CompleteAsync();
                return result != 0 ? GenerateSuccessResult("ثبت", newClient.ClientCode) :
                    GenerateFaidResult("ثبت");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// سرویس دریافت اطلاعات اولیه کلاینت
        /// Client Base Info Get Service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// سرویس به روز رسانی اطلاعات اولیه کلاینت
        /// Client Base Info Update Service
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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
            return result != 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }

        /// <summary>
        /// سرویس ثبت اطلاعات تماس کلاینت
        /// Client Contact Info Create Service
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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
            return result != 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }

        /// <summary>
        /// سرویس دریافت تمامی اطلاعات کلاینت
        /// Client All Info Get Service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> GetClientInfoByClientCode(int id)
        {
            var selectedClient = await UnitOfWork.ClientRepository.GetClientInfoByClientCode(id);
            if (selectedClient == null)
                return GenerateFaidResult("کلاینت مورد نظر یافت نشد");

            var viewModel = GenerateClientBaseInfoViewModel(selectedClient);

            if (selectedClient.ClientAddress != null)
            {
                GenerateClientAddressViewModel(viewModel, selectedClient);
            }

            if (selectedClient.ClientContact != null)
            {
                GenerateClientContactViewModel(viewModel, selectedClient);
            }

            if (selectedClient.ClientDeliveryAddress != null)
            {
                GenerateClientDeliveryAddressViewModel(viewModel, selectedClient);
            }

            if (selectedClient.ClientExtraInformation != null)
            {
                GenerateClientExtraInformationViewModel(viewModel, selectedClient);
            }

            if (selectedClient.ClientPayment != null)
            {
                GenerateClientPaymentViewModel(viewModel, selectedClient);
            }

            if (selectedClient.ClientPurchase != null)
            {
                GenerateClientPurchaseViewModel(viewModel, selectedClient);
            }

            return GenerateSuccessResult("دریافت", viewModel);
        }

        private void GenerateClientPurchaseViewModel(ClientInfoViewModel viewModel, Client selectedClient)
        {
            viewModel.ClientPurchase = new ClientPurchaseViewModel()
            {
                Vat = selectedClient.ClientPurchase.Vat,
                PaymentMethod = selectedClient.ClientPurchase.PaymentMethod,
                PaymentTerms = selectedClient.ClientPurchase.PaymentTerms,
                Balance = selectedClient.ClientPurchase.Balance,
                Discount = selectedClient.ClientPurchase.Discount,
                Pricing = selectedClient.ClientPurchase.Pricing,
                Credit = selectedClient.ClientPurchase.Credit
            };
        }

        private void GenerateClientPaymentViewModel(ClientInfoViewModel viewModel, Client selectedClient)
        {
            viewModel.ClientPayment = new ClientPaymentViewModel()
            {
                Name = selectedClient.ClientPayment.Name,
                GpsAddress = selectedClient.ClientPayment.GpsAddress,
                DateOfReferral = selectedClient.ClientPayment.DateOfReferral,
                OtherReqirments = selectedClient.ClientPayment.OtherReqirments,
                GpsName = selectedClient.ClientPayment.GpsName,
                ReasonForRefrral = selectedClient.ClientPayment.ReasonForRefrral,
                ReferralFor = selectedClient.ClientPayment.ReferralFor,
                ReferralTel = selectedClient.ClientPayment.ReferralTel,
                Therapist = selectedClient.ClientPayment.Therapist,
                ReferralBy = selectedClient.ClientPayment.ReferralBy,
                GpsNumber = selectedClient.ClientPayment.GpsNumber
            };
        }

        private void GenerateClientExtraInformationViewModel(ClientInfoViewModel viewModel, Client selectedClient)
        {
            viewModel.ClientExtraInformation = new ClientExtraInformationViewModel()
            {
                Name = selectedClient.ClientExtraInformation.Name,
                ContactNumber = selectedClient.ClientExtraInformation.ContactNumber,
                RelationShip = selectedClient.ClientExtraInformation.RelationShip,
                Ntk = selectedClient.ClientExtraInformation.Ntk
            };
        }

        private ClientInfoViewModel GenerateClientBaseInfoViewModel(Client selectedClient)
        {
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
            return viewModel;
        }

        private void GenerateClientDeliveryAddressViewModel(ClientInfoViewModel viewModel, Client selectedClient)
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

        private void GenerateClientContactViewModel(ClientInfoViewModel viewModel, Client selectedClient)
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

        private void GenerateClientAddressViewModel(ClientInfoViewModel viewModel, Client selectedClient)
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

        public async Task<Result> CreateClientPurchaceInfoAsyn(CreateClientPurchaceInfoCommand command)
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
            return result != 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }

        public async Task<Result> UpdateClientPurchaceInfoAsyn(UpdateClientPurchaceInfoCommand command)
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
            return result != 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }

        public async Task<Result> UpdateClientContactInfoAsyn(UpdateClientContactInfoCommand command)
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
            return result != 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }
    }
}