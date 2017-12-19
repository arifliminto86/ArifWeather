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
                        getCitiesPrivate(country);
                    }
                }
            });
    }

    this.GetCities = function (country) {
        getCitiesPrivate(country);
    }

    function getCitiesPrivate(country)
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
        var city = $("#CityList option:selected").text();

        $.ajax(
            {
                url: "/Home/GetSearchResult",
                dataType: "json",
                crossDomain: true,
                data: { city: city },
                success: function (data) {
                    $("#SearchResult").show();
                    populateWeather(data);
                },             
                fail: function (jqXHR, textStatus, errorThrown) {
                    alert("error");
                },
                error: function(error) {
                    alert(error);
                }
            });
    }

    function populateWeather(data) {
        
        $("#LocalObservationDateTime").text(data.LocalObservationDateTime);
        $("#WeatherText").text(data.WeatherText);


        if (data.IsDayTime === "true") {
            $("#IsDayTime").text("Day");    
        }
        else
            $("#IsDayTime").text("Night");    
        
        var weatherIcon = data.WeatherIcon <10 ? "0"+data.WeatherIcon : data.WeatherIcon;
        var imgurl = "https://developer.accuweather.com/sites/default/files/" + weatherIcon+"-s.png";
                
        $("#WeatherIcon").attr("src", imgurl);
        
        $("#Temperature").text(data.Temperature.Metric.Value + " Celcius");
    }    
}