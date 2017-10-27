function TemperatureSearch()
{
    this.GetCountries = function (region)
    {
        if (region == null) alert("Region is empty, please fill the region");
        $.ajax(
            {
                url: "/Home/GetCountries",
                dataType: "json",
                data: { regionKey: region },
                success: function (data) {
                    $("#CountryList").empty();
                    $.each(data, function (index, optiondata) {
                        $("#CountryList").append("<option value='" + optiondata.ID + "'>" + optiondata.EnglishName + "</option>");
                    });
                },
                fail: function (xhr, textStatus, errorThrown)
                {
                    alert(errorThrown);
                },
                complete: function () {
                    var country = $("#CountryList option:selected").val();
                    if (country != null)
                    {                       
                        GetCitiesPrivate(country);
                    }
                }
            });
    }

    this.GetCities = function (country) {
        GetCitiesPrivate(country);
    }

    function GetCitiesPrivate(country)
    {
        if (country == null) {
            alert("Country is empty, please fill the region");
            return;
        }
        $.ajax(
            {
                url: "/Home/GetCities",
                dataType: "json",
                data: { countryCode: country },
                success: function (data) {
                    $("#CityList").empty();
                    $.each(data, function (index, optiondata) {
                        $("#CityList").append("<option value='" + optiondata.ID + "'>" + optiondata.Name + "</option>");
                    });
                },
                fail: function (xhr, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    }

    this.Search = function() {
        //$('#Crd option:selected').text();
        var city = $("#CityList option:selected").text();
        if (city == null || city == "" ) {

            alert("City is required!");
            return;
        }

        $.ajax(
            {
                url: "/Home/GetSearchResult",
                dataType: "json",
                crossDomain: true,
                data: { city: city },
                success: function (data) {
                    $("#SearchResult").show();
                    PopulateHeading(data.Headline);
                    PopulateDailyForeCast(data.DailyForecasts);
                },
                fail: function (jqXHR, textStatus, errorThrown) {
                    alert("error");
                }
            });
    }

    function PopulateHeading(headline, dailyforecast) {
        var datestr = new Date(parseInt(headline.EffectiveDate.substr(6)));
        
        $("#EffectiveDateResult").text(datestr);
        $("#SummaryResult").text(headline.Text);

        var severityStr = "";

        if (headline.Severity < 10)
        {
            severityStr = "0" + headline.Severity;
        }
        else
        {
            severityStr = headline.Severity;
            
        }        
        var imgurl = "https://developer.accuweather.com/sites/default/files/" + severityStr+"-s.png";
                
        $("#SeverityImage").attr("src", imgurl);

      
    }

    function PopulateDailyForeCast(dailyforecast)
    {
        var minimum = dailyforecast.Temperature.Minimum.Value + " " + dailyforecast.Temperature.Minimum.Unit;
        var maximum = dailyforecast.Temperature.Maximum.Value + " " + dailyforecast.Temperature.Maximum.Unit

        $("#DailyForecastTemperatureMin").text(minimum.toString());
        $("#DailyForecastTemperatureMax").text(maximum.toString());        
    }
}