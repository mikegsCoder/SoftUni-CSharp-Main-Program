namespace PetClinic.App
{
    using AutoMapper;
    using PetClinic.DataProcessor.ImportDto;
    using PetClinic.Models;
    using System;
    using System.Globalization;

    public class PetClinicProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public PetClinicProfile()
        {
            CreateMap<ImportAnimalDto, Animal>()
                .ForMember(a =>
                    a.PassportSerialNumber, id =>
                        id.MapFrom(dto => dto.Passport.SerialNumber));
            CreateMap<ImportPassportDto, Passport>()
                .ForMember(p =>
                    p.RegistrationDate, rd =>
                        rd.MapFrom(dto =>
                            DateTime.ParseExact(dto.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
