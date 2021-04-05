using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using Blazor.Charts.ChartJs.Entities;
using System.Text.Json;

namespace Blazor.Charts.ChartJs.Components
{
    /// <summary>
    /// Represents a Blazor Chart component that calls JavaScript 
    /// from C# by injecting the IJSRuntime service.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
    public class LineChartBase : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public ChartTypes Types { get; set; }

        [Parameter]
        public string[] Data { get; set; }

        [Parameter]
        public string[] BackgroundColor { get; set; }

        [Parameter]
        public string[] BorderColor { get; set; } = new[] { "rgb(255, 99, 132)" };

        [Parameter]
        public int BorderWidthNum { get; set; } = 0;

        [Parameter]
        public string[] Labels { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string DatasetTitle { get; set; } = "dataset";

        readonly DataItem[] myData = new DataItem[] {
            new DataItem
            {
                X = 2.75,
                Y = 50
            },
            new DataItem
            {
                X = 5.5,
                Y = 60
            },
            new DataItem
            {
                X = 7,
                Y = 70
            },
            new DataItem
            {
                X = 9,
                Y = 80
            },
            new DataItem
            {
                X = 11,
                Y = 90
            },
            new DataItem
            {
                X = 12.5,
                Y = 100
            },
            new DataItem
            {
                X = 15,
                Y = 110
            }
        };

        readonly DataItem[] myScatterData = new DataItem[] {
            new DataItem
            {
                Y = 2.75,
                X = 50
            },
            new DataItem
            {
                Y = 5.5,
                X = 60
            },
            new DataItem
            {
                Y = 7,
                X = 70
            },
            new DataItem
            {
                Y = 9,
                X = 80
            },
            new DataItem
            {
                Y = 11,
                X = 90
            },
            new DataItem
            {
                Y = 12.5,
                X = 100
            },
            new DataItem
            {
                Y = 15,
                X = 110
            }
        };

        readonly DataItem[] myScatterPlotData = new DataItem[] {
            new DataItem
            {
                Y = 9.5,
                X = 80
            }
        };

        readonly WflDataItem[] myLineData = new WflDataItem[] {
            new WflDataItem
            {
                //Sex = 1,
                LengthInCm = 73.0,
                Score = 9,
                //L = -0.3521,
                //M = 9.0865,
                //S = 0.08269,
                //Sd3neg = 7.200,
                //Sd2neg = 7.700,
                //Sd1neg = 8.400,
                //Sd0 = 9.100,
                //Sd1 = 9.900,
                //Sd2 = 10.800,
                //Sd3 = 11.800,
                P3 = 7.800,
                P15 = 8.400,
                P50 = 9.100,
                P85 = 9.900,
                P97 = 10.700
            }
        };

        /// <summary>
        /// Instantiates the Chart class with all configurable options.
        /// Method invoked after each time the component has been rendered. Note that the component does
        /// not automatically re-render after the completion of any returned <see cref="T:System.Threading.Tasks.Task" />, because
        /// that would cause an infinite render loop.
        /// </summary>
        /// <param name="firstRender">Set to <c>true</c> if this is the first time <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> has been invoked
        /// on this component instance; otherwise <c>false</c>.</param>
        /// <remarks>
        /// The <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> and <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)" /> lifecycle methods
        /// are useful for performing interop, or interacting with values received from <c>@ref</c>.
        /// Use the <paramref name="firstRender" /> parameter to ensure that initialization work is only performed
        /// once.
        /// https://www.chartjs.org/docs/latest/axes/cartesian/linear.html#linear-cartesian-axis
        /// </remarks>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var config = new
            {
                Type = Types.ToString().ToLower(),
                Options = new
                {
                    Responsive = true,
                    Title = new
                    {
                        Display = true,
                        Text = "Birth to 5 Years (Percentile)"
                    },
                    Scales = new
                    {
                        YAxes = new[]
                        {
                            new {
                                ScaleLabel = new { Display = true, labelString = "Weight (kg)" },
                                Ticks = new { BeginAtZero = true, StepSize = 2, SuggestedMax = 26, SuggestMin = 0 }
                            }
                        },
                        XAxes = new[]
                        {
                            new {
                                ScaleLabel = new { Display = true, labelString = "Length (cm)" }
                            }
                        }
                    },
                    Legend = new
                    {
                        Display = true,
                        Position = "right",
                        Labels = new
                        {
                            fontColor = "rgb(255, 99, 132)"
                        }
                    },
                    Series = new[]
                    {
                        new {Color = "#e10808" }
                    }
                },
                Data = new
                {
                    Datasets = new[]
                    {
                    new {
                            Data = myData, //Data
                            //BackgroundColor = BackgroundColor,
                            BorderColor = BorderColor,
                            BorderWidth = BorderWidthNum,
                            Label = DatasetTitle,
                            fill = false
                    }
                },
                    Labels = Labels
                }
            };

            // Inject the IJSRuntime abstraction into a class (.cs)
            await JSRuntime.InvokeVoidAsync("setup", Id, config);
        }

        public string LoadChartData()
        {
            var myLabels = new object[]
            {
                new { label = "lengthincm", type = "number"},
                new { label = "Score", type = "number"},
                new { label = "97th", type = "number"},
                new { label = "85th", type = "number"},
                new { label = "50th", type = "number"},
                new { label = "15th", type = "number"},
                new { label = "3rd", type = "number"}
            };

            var myData = new object[]
            {
                new {
                    LengthInCm = 73.0,
                    Score = 9,
                    P3 = 7.800,
                    P15 = 8.400,
                    P50 = 9.100,
                    P85 = 9.900,
                    P97 = 10.700
                }
            };

            string result = string.Concat(myLabels, myData);

            return result;
        }

        public string GetChartData()
        {
            var chart = new ChartDataTable
            {
                cols = new object[]
                {
                    new { id = "year", label = "Year", type = "string" },
                    new { id = "sales", label = "Sales", type = "number" },
                    new { id = "expenses", label = "Expenses", type = "number" }
                },
                rows = new object[]
                {
                    new { c = new object[] { new { v = "2014" }, new { v = 1000 }, new { v = 400 } } },
                    new { c = new object[] { new { v = "2015" }, new { v = 1170 }, new { v = 460 } } },
                    new { c = new object[] { new { v = "2016" }, new { v = 660 }, new { v = 1120 } } },
                    new { c = new object[] { new { v = "2017" }, new { v = 1030 }, new { v = 540 } } }
                }
            };

            string jsonString = JsonSerializer.Serialize(chart);

            return jsonString;
        }

    }

    class DataItem
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class WflDataItem
    {
        public int Sex { get; set; }
        public double LengthInCm { get; set; }
        public double L { get; set; }
        public double M { get; set; }
        public double S { get; set; }
        public double Sd3neg { get; set; }
        public double Sd2neg { get; set; }
        public double Sd1neg { get; set; }
        public double Sd0 { get; set; }
        public double Sd1 { get; set; }
        public double Sd2 { get; set; }
        public double Sd3 { get; set; }
        public double P3 { get; set; }
        public double P15 { get; set; }
        public double P50 { get; set; }
        public double P85 { get; set; }
        public double P97 { get; set; }
        public double Score { get; set; }
    }

    public class DataLabels
    {
        public string Label { get; set; }
        public string Type { get; set; }
    }

    public class ChartDataTable
    {
        public object[] cols { get; set; }
        public object[] rows { get; set; }
    }
}
