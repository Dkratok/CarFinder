using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFinder
{
    class AvCarFinder : GeneralCarFinder
    {
        private const string BasicUrl = "";
        CarSearchParams searchParams = InputDataValidator.JsonDeserialize(@"reqparams.json");

        private string GetUrlForRequest<CarSearchParams>()
        {
            string url = BasicUrl;

            InputDataValidator.ValidateInputData(searchParams.Make, searchParams.Model, searchParams.YearStart, searchParams.YearEnd);

            if (!(searchParams.Make is null))
            {
                url = AddParameterToUrl(url, "marka_id=", searchParams.Make);
                if (!(searchParams.Model is null))
                {
                    url = AddParameterToUrl(url, "model_id=", searchParams.Model);
                }
            }
            if (!(searchParams.YearStart == 0))
            {
                url = AddParameterToUrl(url, "year_from=", searchParams.YearStart);
            }
            if (!(searchParams.YearEnd == 0))
            {
                url = AddParameterToUrl(url, "year_to=", searchParams.YearEnd);
            }
            if (!(searchParams.EngineType is null))
            {
                url = AddParameterToUrl(url, "engine_type_id=", searchParams.EngineType);
            }
            return url;
        }
        public string GetHtmlFromResponse()
        {
            string url = GetUrlForRequest<CarSearchParams>();
            return GetHtml(url);
        }
    }
}
