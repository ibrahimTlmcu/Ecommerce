﻿namespace Ecommerce.Catalog.Dtos.FeatureSliderDtos
{
    public class GetByIdSliderDto
    {
        public string FeatureSliderId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool Status { get; set; }
    }
}
