using Xamarin.Forms;
using TypedActionSheet;
using System.Collections.Generic;

namespace SampleApp
{
    public partial class MainPage : ContentPage
    {
        List<SampleModel> models;

        public MainPage()
        {
            InitializeComponent();
            models = new List<SampleModel>
            {
                new SampleModel
                {
                     SomeSampleId = 1,
                     SomeSampleString = "A sample string"
                },

                new SampleModel
                {
                    SomeSampleId = 2,
                    SomeSampleString = "Another sample string"
                },

                new SampleModel
                {
                     SomeSampleId = 3,
                     SomeSampleString = "Yet another sample string"
                }
            };
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var selection = await this.DisplayedTypedActionSheet<SampleModel>("test", "cancel", null
            , models, nameof(SampleModel.SomeSampleString));
        }
    }
}
