using AutoMapper;
using PlatformService.DataTransferObjects;
using PlatformService.Models;

namespace PlatformService.AutoMapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<User, UserReadDto>();  
            CreateMap<UserCreateDto, User>();

            CreateMap<Account, AccountReadDto>();
            CreateMap<AccountCreateDto, Account>();

            CreateMap<Transaction, TransactionReadDto>();
            CreateMap<TransactionCreateDto, Transaction>(); 

        }
    }
}
