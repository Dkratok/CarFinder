using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFinder
{
    class OnlinerCarFinder : GeneralCarFinder
    {
        private const string BasicUrl = "https://ab.onliner.by/sdapi/ab.api/search/vehicles?";
        CarSearchParams searchParams = InputDataValidator.JsonDeserialize(@"reqparams.json");



        private string GetUrlForRequest<CarSearchParams>()
        {
           string url = BasicUrl;
            InputDataValidator.ValidateInputData(searchParams.Make, searchParams.Model, searchParams.YearStart, searchParams.YearEnd);

            if (!(searchParams.Make is null))
            {
                var make = searchParams.Make.Trim();
                var make = Enums.OnlinerBrands.;
                url = url + "/" + searchParams.Make;
                if (!(searchParams.Model is null))
                {
                    url = url + "/" + searchParams.Model;
                }
            }
            if (!(searchParams.YearStart == 0))
            {
                url = AddParameterToUrl(url, "year%5Bfrom%5D=", searchParams.YearStart);
            }
            if (!(searchParams.YearEnd == 0))
            {
                url = AddParameterToUrl(url, "year%5Bto%5D=", searchParams.YearEnd);
            }
            if (!(searchParams.EngineType is null))
            {
                url = AddParameterToUrl(url, "engine_type%5B0%5D=", searchParams.EngineType);
            }
            return url;
        }
        public string GetHtmlFromResponse()
        {
            string url = GetUrlForRequest<CarSearchParams>();
            return GetHtml("https://avto.abw.by/api/legkovye/prodazha?location=belarus&marka_id=nissan&model_id=leaf&year_from=2015&year_to=2019&engine_type_id=elektro&page=1");
        }
    }
}
