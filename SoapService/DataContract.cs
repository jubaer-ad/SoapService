using SoapService.Models;
using System.Runtime.Serialization;
using System.ServiceModel;
using static SoapService.Models.BlackServiceContract;

namespace SoapService.Models
{
    [DataContract]
    public class BlackDataContract
    {
        public BlackDataContract()
        { 
            Id = Guid.NewGuid();
        }
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string FirstName { get; set; } = string.Empty;
        [DataMember]
        public string LastName { get; set; } = string.Empty;
    }

    [DataContract]
    public class HiStr
    {
        [DataMember]
        public string Hi { get; set; } = string.Empty;
    }

    public class BlackServiceContract
    {
        [ServiceContract]
        public interface IBlackService
        {
            [OperationContract]
            public List<BlackDataContract> GetPersons();
            [OperationContract]
            public BlackDataContract GetPerson();

            [OperationContract]
            public HiStr GetHi();

            [OperationContract]
            string Hello();

        }
    }
}

namespace SoapService.Services
{
    public class BlackService : IBlackService
    {
        public HiStr GetHi()
        {
            return new()
            {
                Hi = "Howdy Partner!!!"
            };
        }

        public BlackDataContract GetPerson()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Arthur",
                LastName = "Morgan"
            };
        }

        public List<BlackDataContract> GetPersons()
        {
            return new ()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Arthur",
                    LastName = "Morgan"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jubaer",
                    LastName = "AD"
                },
                
            };
        }

        public string Hello()
        {
            return "Hello Mister.";
        }
    }
}
