using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Domain.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace eForms.Domain.Context
{
    public class eFormsContextSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedSampleDataCommon(modelBuilder);
            SeedSampleDataAuthorization(modelBuilder);


        }

        #region SeedFakeDataCommon
        public static void SeedSampleDataCommon(ModelBuilder modelBuilder)
        {
            #region annex
            modelBuilder.Entity<BuildingAnnexes>().HasData(
              new BuildingAnnexes() { Id = 1, BuildingAnnex = "Annex Building (EOB)", Disabled = false },
              new BuildingAnnexes() { Id = 2, BuildingAnnex = "Chancery (NOB)", Disabled = false },
              new BuildingAnnexes() { Id = 3, BuildingAnnex = "RAJDAMRI (RAJ)", Disabled = false },
              new BuildingAnnexes() { Id = 4, BuildingAnnex = "CMR", Disabled = false },
              new BuildingAnnexes() { Id = 5, BuildingAnnex = "Plaza Athenee", Disabled = false },
              new BuildingAnnexes() { Id = 6, BuildingAnnex = "GPF", Disabled = false },
              new BuildingAnnexes() { Id = 7, BuildingAnnex = "SINDHORN", Disabled = false },
              new BuildingAnnexes() { Id = 8, BuildingAnnex = "JUSMAG", Disabled = false },
              new BuildingAnnexes() { Id = 9, BuildingAnnex = "MILLENIA", Disabled = false },
              new BuildingAnnexes() { Id = 10, BuildingAnnex = "ILEA", Disabled = false },
              new BuildingAnnexes() { Id = 11, BuildingAnnex = "CDC", Disabled = false },
              new BuildingAnnexes() { Id = 12, BuildingAnnex = "AFRIMS", Disabled = false },
              new BuildingAnnexes() { Id = 13, BuildingAnnex = "CHIANG MAI", Disabled = false },
              new BuildingAnnexes() { Id = 14, BuildingAnnex = "PC (for Peace Corps)", Disabled = false },
              new BuildingAnnexes() { Id = 15, BuildingAnnex = "Don Mueng", Disabled = false },
              new BuildingAnnexes() { Id = 16, BuildingAnnex = "Korat", Disabled = false },
              new BuildingAnnexes() { Id = 17, BuildingAnnex = "Laem Chabang", Disabled = false },
              new BuildingAnnexes() { Id = 18, BuildingAnnex = "Khon Kaen", Disabled = false },
              new BuildingAnnexes() { Id = 19, BuildingAnnex = "Udorn Thani", Disabled = false }
            );
            #endregion

            #region country
            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 2159, CountryName = "Mexico" },
                new Country() { Id = 2043, CountryName = "Canada" },
                new Country() { Id = 2083, CountryName = "France" },
                new Country() { Id = 2122, CountryName = "Japan" },
                new Country() { Id = 2049, CountryName = "China" },
                new Country() { Id = 2091, CountryName = "Germany" },
                new Country() { Id = 2235, CountryName = "Taiwan" },
                new Country() { Id = 2034, CountryName = "Brazil" },
                new Country() { Id = 2115, CountryName = "Iraq" },
                new Country() { Id = 2112, CountryName = "India" },
                new Country() { Id = 2119, CountryName = "Italy" },
                new Country() { Id = 2129, CountryName = "Kenya" },
                new Country() { Id = 2223, CountryName = "South Africa" },
                new Country() { Id = 2185, CountryName = "Pakistan" },
                new Country() { Id = 2025, CountryName = "Belgium" },
                new Country() { Id = 2246, CountryName = "Turkey" },
                new Country() { Id = 2113, CountryName = "Indonesia" },
                new Country() { Id = 2015, CountryName = "Australia" },
                new Country() { Id = 2213, CountryName = "Saudi Arabia" },
                new Country() { Id = 2031, CountryName = "Bosnia and Herzegovina" },
                new Country() { Id = 2016, CountryName = "Austria" },
                new Country() { Id = 2001, CountryName = "Afghanistan" },
                new Country() { Id = 2201, CountryName = "Russia" },
                new Country() { Id = 2118, CountryName = "Israel" },
                new Country() { Id = 2128, CountryName = "Kazakhstan" },
                new Country() { Id = 2253, CountryName = "United Kingdom" },
                new Country() { Id = 2195, CountryName = "Poland" },
                new Country() { Id = 2222, CountryName = "Somalia" },
                new Country() { Id = 2042, CountryName = "Cameroon" },
                new Country() { Id = 2062, CountryName = "Cuba" },
                new Country() { Id = 2076, CountryName = "Ethiopia" },
                new Country() { Id = 2225, CountryName = "Spain" },
                new Country() { Id = 2196, CountryName = "Portugal" },
                new Country() { Id = 2070, CountryName = "Ecuador" },
                new Country() { Id = 2039, CountryName = "Burma" },
                new Country() { Id = 2260, CountryName = "Vietnam" },
                new Country() { Id = 2071, CountryName = "Egypt" },
                new Country() { Id = 2095, CountryName = "Greece" },
                new Country() { Id = 2228, CountryName = "Sudan" },
                new Country() { Id = 2254, CountryName = "United States" },
                new Country() { Id = 2238, CountryName = "Thailand" },
                new Country() { Id = 2173, CountryName = "Netherlands" },
                new Country() { Id = 2252, CountryName = "United Arab Emirates" },
                new Country() { Id = 2176, CountryName = "New Zealand" },
                new Country() { Id = 2179, CountryName = "Nigeria" },
                new Country() { Id = 2053, CountryName = "Colombia" },
                new Country() { Id = 2167, CountryName = "Morocco" },
                new Country() { Id = 2133, CountryName = "Korea " },
                new Country() { Id = 2165, CountryName = "Montenegro" },
                new Country() { Id = 2220, CountryName = "Slovenia" },
                new Country() { Id = 2191, CountryName = "Paraguay" },
                new Country() { Id = 2021, CountryName = "Bangladesh" },
                new Country() { Id = 2240, CountryName = "Togo" },
                new Country() { Id = 2022, CountryName = "Barbados" },
                new Country() { Id = 2178, CountryName = "Niger" },
                new Country() { Id = 2072, CountryName = "El Salvador" },
                new Country() { Id = 2202, CountryName = "Rwanda" },
                new Country() { Id = 2073, CountryName = "Equatorial Guinea" },
                new Country() { Id = 2232, CountryName = "Sweden" },
                new Country() { Id = 2074, CountryName = "Eritrea" },
                new Country() { Id = 2064, CountryName = "Czechia" },
                new Country() { Id = 2075, CountryName = "Estonia" },
                new Country() { Id = 2172, CountryName = "Nepal" },
                new Country() { Id = 2024, CountryName = "Belarus" },
                new Country() { Id = 2044, CountryName = "Cabo Verde" },
                new Country() { Id = 2081, CountryName = "Fiji" },
                new Country() { Id = 2047, CountryName = "Chad" },
                new Country() { Id = 2082, CountryName = "Finland" },
                new Country() { Id = 2215, CountryName = "Serbia" },
                new Country() { Id = 2004, CountryName = "Algeria" },
                new Country() { Id = 2227, CountryName = "Sri Lanka" },
                new Country() { Id = 2087, CountryName = "Gabon" },
                new Country() { Id = 2236, CountryName = "Tajikistan" },
                new Country() { Id = 2088, CountryName = "Gambia" },
                new Country() { Id = 2247, CountryName = "Turkmenistan" },
                new Country() { Id = 2090, CountryName = "Georgia" },
                new Country() { Id = 2258, CountryName = "Vatican City" },
                new Country() { Id = 2026, CountryName = "Belize" },
                new Country() { Id = 2168, CountryName = "Mozambique" },
                new Country() { Id = 2092, CountryName = "Ghana" },
                new Country() { Id = 12233, CountryName = "Switzerland" },
                new Country() { Id = 2027, CountryName = "Benin" },
                new Country() { Id = 2183, CountryName = "Norway" },
                new Country() { Id = 2097, CountryName = "Grenada" },
                new Country() { Id = 2188, CountryName = "Panama" },
                new Country() { Id = 2100, CountryName = "Guatemala" },
                new Country() { Id = 2193, CountryName = "Philippines" },
                new Country() { Id = 2102, CountryName = "Guinea" },
                new Country() { Id = 2200, CountryName = "Romania" },
                new Country() { Id = 2104, CountryName = "Guyana" },
                new Country() { Id = 2017, CountryName = "Azerbaijan" },
                new Country() { Id = 2105, CountryName = "Haiti" },
                new Country() { Id = 2218, CountryName = "Singapore" },
                new Country() { Id = 2107, CountryName = "Honduras" },
                new Country() { Id = 2055, CountryName = "Congo (Brazzaville)" },
                new Country() { Id = 2108, CountryName = "Hong Kong" },
                new Country() { Id = 2229, CountryName = "Suriname" },
                new Country() { Id = 2110, CountryName = "Hungary" },
                new Country() { Id = 2234, CountryName = "Syria" },
                new Country() { Id = 2111, CountryName = "Iceland" },
                new Country() { Id = 2061, CountryName = "Croatia" },
                new Country() { Id = 2028, CountryName = "Bermuda" },
                new Country() { Id = 2245, CountryName = "Tunisia" },
                new Country() { Id = 2030, CountryName = "Bolivia" },
                new Country() { Id = 2251, CountryName = "Ukraine" },
                new Country() { Id = 2114, CountryName = "Iran" },
                new Country() { Id = 2255, CountryName = "Uruguay" },
                new Country() { Id = 2007, CountryName = "Angola" },
                new Country() { Id = 2067, CountryName = "Djibouti" },
                new Country() { Id = 2116, CountryName = "Ireland" },
                new Country() { Id = 2040, CountryName = "Burundi" },
                new Country() { Id = 2032, CountryName = "Botswana" },
                new Country() { Id = 2169, CountryName = "Namibia" },
                new Country() { Id = 2011, CountryName = "Argentina" },
                new Country() { Id = 2041, CountryName = "Cambodia" },
                new Country() { Id = 2120, CountryName = "Jamaica" },
                new Country() { Id = 2177, CountryName = "Nicaragua" },
                new Country() { Id = 2036, CountryName = "Brunei" },
                new Country() { Id = 2003, CountryName = "Albania" },
                new Country() { Id = 2126, CountryName = "Jordan" },
                new Country() { Id = 2184, CountryName = "Oman" },
                new Country() { Id = 2037, CountryName = "Bulgaria" },
                new Country() { Id = 2186, CountryName = "Palau" },
                new Country() { Id = 2038, CountryName = "Burkina Faso" },
                new Country() { Id = 2189, CountryName = "Papua New Guinea" },
                new Country() { Id = 2267, CountryName = "Yemen" },
                new Country() { Id = 2192, CountryName = "Peru" },
                new Country() { Id = 2268, CountryName = "Zambia" },
                new Country() { Id = 2046, CountryName = "Central African Republic" },
                new Country() { Id = 2270, CountryName = "Jerusalem" },
                new Country() { Id = 2198, CountryName = "Qatar" },
                new Country() { Id = 2273, CountryName = "South Sudan" },
                new Country() { Id = 2048, CountryName = "Chile" },
                new Country() { Id = 2137, CountryName = "Laos" },
                new Country() { Id = 2210, CountryName = "Samoa" },
                new Country() { Id = 2138, CountryName = "Latvia" },
                new Country() { Id = 2214, CountryName = "Senegal" },
                new Country() { Id = 2139, CountryName = "Lebanon" },
                new Country() { Id = 2217, CountryName = "Sierra Leone" },
                new Country() { Id = 2140, CountryName = "Lesotho" },
                new Country() { Id = 2219, CountryName = "Slovakia" },
                new Country() { Id = 2141, CountryName = "Liberia" },
                new Country() { Id = 2018, CountryName = "Bahamas" },
                new Country() { Id = 2142, CountryName = "Libya" },
                new Country() { Id = 2056, CountryName = "Congo (Kinshasa)" },
                new Country() { Id = 2144, CountryName = "Lithuania" },
                new Country() { Id = 2059, CountryName = "Costa Rica" },
                new Country() { Id = 2145, CountryName = "Luxembourg" },
                new Country() { Id = 2231, CountryName = "Eswatini" },
                new Country() { Id = 2147, CountryName = "North Macedonia" },
                new Country() { Id = 2233, CountryName = "Switzerland" },
                new Country() { Id = 2148, CountryName = "Madagascar" },
                new Country() { Id = 2060, CountryName = "Cote dLvoire" },
                new Country() { Id = 2149, CountryName = "Malawi" },
                new Country() { Id = 2237, CountryName = "Tanzania" },
                new Country() { Id = 2150, CountryName = "Malaysia" },
                new Country() { Id = 2239, CountryName = "Timor-Leste" },
                new Country() { Id = 2152, CountryName = "Mali" },
                new Country() { Id = 2243, CountryName = "Trinidad and Tobago" },
                new Country() { Id = 2153, CountryName = "Malta" },
                new Country() { Id = 2019, CountryName = "Bahrain" },
                new Country() { Id = 2154, CountryName = "Marshall Islands" },
                new Country() { Id = 2250, CountryName = "Uganda" },
                new Country() { Id = 2156, CountryName = "Mauritania" },
                new Country() { Id = 2063, CountryName = "Cyprus" },
                new Country() { Id = 2157, CountryName = "Mauritius" },
                new Country() { Id = 2065, CountryName = "Denmark" },
                new Country() { Id = 2012, CountryName = "Armenia" },
                new Country() { Id = 2256, CountryName = "Uzbekistan" },
                new Country() { Id = 2160, CountryName = "Micronesia" },
                new Country() { Id = 2259, CountryName = "Venezuela" },
                new Country() { Id = 2162, CountryName = "Moldova" },
                new Country() { Id = 2069, CountryName = "Dominican Republic" },
                new Country() { Id = 2164, CountryName = "Mongolia" },
                new Country() { Id = 2269, CountryName = "Zimbabwe" },
                new Country() { Id = 2134, CountryName = "Kosovo" },
                new Country() { Id = 2272, CountryName = "Curacao" },
                new Country() { Id = 2135, CountryName = "Kuwait" },
                new Country() { Id = 100110, CountryName = "Russia" },
                new Country() { Id = 2136, CountryName = "Kyrgyzstan" }
            );
            #endregion

            #region form
            modelBuilder.Entity<Forms>().HasData(
              new Forms() { Id = 1, formtitle = "OpenNet Account", formname = "OpenNetAccount.pdf", formurl = "OpenNetAccount", formediturl = "OpenNetAccount", efm = false, formefm = "OpenNetAccount", formpath = "OpenNetAccount", Disabled = false },
              new Forms() { Id = 2, formtitle = "ClassNet Account", formname = "ClassNetAccount.pdf", formurl = "OpenNetAccount", formediturl = "OpenNetAccount", efm = false, formefm = "OpenNetAccount", formpath = "OpenNetAccount", Disabled = false },
              new Forms() { Id = 3, formtitle = "New Arrival", formname = "New Arrival.pdf", formurl = "New Arrival", formediturl = "New Arrival", efm = false, formefm = "New Arrival", formpath = "New Arrival", Disabled = false }
            );
            #endregion

            #region ipc
            modelBuilder.Entity<IPC>().HasData(
              new IPC() { Id = 1, Name = "Max, Yosvaris", Email = "Max@state.gov", Position = "ISO", Phone = "4357", Disabled = false },
              new IPC() { Id = 2, Name = "Administrator", Email = "IPCBangkok@state.gov", Position = "IPC", Phone = "4000", Disabled = false }
            );
            #endregion

            #region iso
            modelBuilder.Entity<ISO>().HasData(
              new ISO() { Id = 1, Name = "Max, Yosvaris", Email = "Max@state.gov", Position = "ISO", Phone = "4357", Disabled = false }
            );
            #endregion

            #region isso
            modelBuilder.Entity<ISSO>().HasData(
              new ISSO() { Id = 1, Name = "Max, Yosvaris", Email = "Max@state.gov", Position = "ISO", Phone = "4357", Disabled = false }
            );
            #endregion

            #region posts
            modelBuilder.Entity<Posts>().HasData(
              new Posts() { Id = 1, PostCity = "Athens", PostCountry = "Greece", PostType = "E", PostBureau = "EUR", Disabled = false },
              new Posts() { Id = 2, PostCity = "Bangkok", PostCountry = "Thailand", PostType = "E", PostBureau = "EAP", Disabled = false },
              new Posts() { Id = 3, PostCity = "Chiang Mai", PostCountry = "Thailand", PostType = "CG", PostBureau = "EAP", Disabled = false }
            );
            #endregion

            #region prefixes
            modelBuilder.Entity<Prefixes>().HasData(
              new Prefixes() { Id = 1, PrefixTitle = "N/A", Disabled = false },
              new Prefixes() { Id = 2, PrefixTitle = "Ms.", Disabled = false },
              new Prefixes() { Id = 3, PrefixTitle = "Miss", Disabled = false },
              new Prefixes() { Id = 4, PrefixTitle = "Mrs.", Disabled = false },
              new Prefixes() { Id = 5, PrefixTitle = "Mr.", Disabled = false },
              new Prefixes() { Id = 6, PrefixTitle = "Dr.", Disabled = false },
              new Prefixes() { Id = 7, PrefixTitle = "Rep.", Disabled = false },
              new Prefixes() { Id = 8, PrefixTitle = "Sen.", Disabled = false },
              new Prefixes() { Id = 9, PrefixTitle = "Amb.", Disabled = false },
              new Prefixes() { Id = 10, PrefixTitle = "Pvt.", Disabled = false }
            );
            #endregion

            #region relationships
            modelBuilder.Entity<Relationships>().HasData(
              new Relationships() { Id = 1, Relationship = "N/A", Disabled = false },
              new Relationships() { Id = 2, Relationship = "BROTHER", Disabled = false },
              new Relationships() { Id = 3, Relationship = "SISTER", Disabled = false },
              new Relationships() { Id = 4, Relationship = "DAUGHTER", Disabled = false },
              new Relationships() { Id = 5, Relationship = "SON", Disabled = false },
              new Relationships() { Id = 6, Relationship = "MOTHER", Disabled = false },
              new Relationships() { Id = 7, Relationship = "FATHER", Disabled = false },
              new Relationships() { Id = 8, Relationship = "WIFE", Disabled = false },
              new Relationships() { Id = 9, Relationship = "HUSBAND", Disabled = false },
              new Relationships() { Id = 10, Relationship = "NIECE/NEPHEW", Disabled = false },
              new Relationships() { Id = 11, Relationship = "PARENTS", Disabled = false },
              new Relationships() { Id = 12, Relationship = "IN-LAW", Disabled = false },
              new Relationships() { Id = 13, Relationship = "OTHER", Disabled = false }
            );
            #endregion

            #region sections
            modelBuilder.Entity<Sections>().HasData(
              new Sections() { Id = 1, sectionname = "Information System Center", sectionabbr = "ISC", icasscode = "1900", Disabled = false },
              new Sections() { Id = 2, sectionname = "Human Resources", sectionabbr = "RHRO", icasscode = "1900", Disabled = false }
            );
            #endregion

            #region smtp
            modelBuilder.Entity<SMTP>().HasData(
              new SMTP() { Id = 1, Name = "nccsmtprelay.irm.state.gov", Disabled = false }
            );
            #endregion

            #region state
            modelBuilder.Entity<State>().HasData(
              new State() { Id = 1, StateCode = "AL", StateName = "Alabama", StateCapital = "Montgomery", Disabled = false },
              new State() { Id = 2, StateCode = "AK", StateName = "Alaska", StateCapital = "Juneau", Disabled = false }
            );
            #endregion

        }
        #endregion

        public static void SeedSampleDataAuthorization(ModelBuilder modelBuilder)
        {
            #region user
            modelBuilder.Entity<User>().HasData(
              new User() { Id = 1, Username = "Max", EmailAddress = "Max@state.gov", DisplayName = "Pisansawanya, Yosvaris \"Max\" (Bangkok)", OfficePhone = "4357", Disabled = false },
              new User() { Id = 2, Username = "Administrator", EmailAddress = "Max@state.gov", DisplayName = "Pisansawanya, Yosvaris \"Max\" (Bangkok)", OfficePhone = "4357", Disabled = false },
              new User() { Id = 3, Username = "RHRO", EmailAddress = "RHRO@state.gov", DisplayName = "RHRO Staff", OfficePhone = "4000", Disabled = false }
            );
            #endregion

            #region userrole
            modelBuilder.Entity<UserRole>().HasData(
              new UserRole() { Id = 1, UserId = 1, Role = ExtensionsEnum.GetDisplay(Roles.Admin), FormId = 1, Disabled = false },
              new UserRole() { Id = 2, UserId = 2, Role = ExtensionsEnum.GetDisplay(Roles.Manager), FormId = 2, Disabled = false },
              new UserRole() { Id = 3, UserId = 3, Role = ExtensionsEnum.GetDisplay(Roles.Manager), FormId = 3, Disabled = false },
              new UserRole() { Id = 4, UserId = 3, Role = ExtensionsEnum.GetDisplay(Roles.User), FormId = 2, Disabled = false }
            );
            #endregion
        }


    }
}
