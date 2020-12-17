# BlazorCharts
This Blazor demonstration project was created using Visual Studio 2019 16.8.3, .NET 5, & Chart.js 2.9.4.  The objective is to invoke Chart.js from a Blazor Server app.

## Demo
The animated gif below demonstrates application execution.
![Blazor Chart GIF](https://github.com/rdw100/BlazorCharts/blob/master/Blazor.Charts.ChartJs/wwwroot/img/L3F8L1RUbc.gif?raw=true)

## Steps (Summary)
1. Add Chart.js to the project.  
	* Create JS folder in wwwroot.	
	* Download Chart.bundle.min.js from [Chart.js Github](https://github.com/chartjs/Chart.js) to JS.

2. Add Chart.razor to the project.
	* Create Components folder in root.
	* Create Razor Component file type named Chart.razor.
	* Call [OnAfterRenderAsync](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-5.0#after-component-render)

3. Add ChartSetup.js to the project.
	* Create ChartSetup.js in JS.

4. Add JS script references to the project.
	* Add Chart.bundle.min.js and Chart.js to _Host.cshtml.

5. Add Chart razor component to razor page.
	* Add <Chart></Chart> to Index.Razor.