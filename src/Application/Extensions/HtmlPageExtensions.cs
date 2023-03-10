using DreamWeddsManager.Domain.Entities.DreamWedds;
using DreamWeddsManager.Application.Utilities;
using DreamWeddsManager.Application.Features.Common.Queries;

namespace DreamWeddsManager.Application.Extensions
{
    public static class HtmlPageExtensions
    {
        public static string GetMetadataString(List<GetAllMetaTagsResponse> list, string title = "")
        {
            string metadata = "";
            if (!string.IsNullOrWhiteSpace(title))
            {
                metadata +=
                    $"<meta name=\"twitter:title\" content=\" {title}\">{Environment.NewLine}";
                metadata +=
                    $"<meta property=\"og:title\" content=\" {title}\">{Environment.NewLine}";
                metadata += $"<title>{title}</title>{Environment.NewLine}";
            }
            foreach (var item in list)
            {
                if (
                    item.TagPrefix == KnownValues.KnownTagPrefix.Title
                    && string.IsNullOrWhiteSpace(title)
                )
                {
                    metadata +=
                        $"<meta name=\"twitter:title\" content=\" {item.Content}\">{Environment.NewLine}";
                    metadata +=
                        $"<meta property=\"og:title\" content=\" {item.Content}\">{Environment.NewLine}";
                    metadata += $"<title>{item.Content}</title>{Environment.NewLine}";
                }

                if (item.TagPrefix == KnownValues.KnownTagPrefix.Image)
                {
                    metadata +=
                        $"<meta name=\"{item.Name}\" content=\"{item.Content}\">{Environment.NewLine}";
                    metadata +=
                        $"<meta name=\"twitter:card\" content=\"summary_large_image\">{Environment.NewLine}";

                    metadata +=
                        $"<meta property=\"{item.Property}\" content=\"{item.Content}\">{Environment.NewLine}";
                    metadata +=
                        $"<meta property=\"og:image:width\" content=\"1000\">{Environment.NewLine}";
                    metadata +=
                        $"<meta property=\"og:image:height\" content=\"500\">{Environment.NewLine}";
                }

                if (item.TagPrefix == KnownValues.KnownTagPrefix.Description)
                {
                    metadata +=
                        $"<meta name=\"twitter:description\" content=\" {item.Content}\">{Environment.NewLine}";
                    metadata +=
                        $"<meta property=\"og:description\" content=\" {item.Content}\"{Environment.NewLine}>";
                    metadata +=
                        $"<meta name=\"description\" content=\"{item.Content}\">{Environment.NewLine}";
                }

                if (item.TagPrefix == KnownValues.KnownTagPrefix.Keywords)
                {
                    metadata +=
                        $"<meta name=\"keywords\" content=\"{item.Content}\">{Environment.NewLine}";
                }

                if (item.TagPrefix == KnownValues.KnownTagPrefix.SiteName)
                {
                    metadata +=
                        $"<meta property=\"{item.Property}\" content=\"{item.Content}\">{Environment.NewLine}";
                    metadata +=
                        $"<meta name=\"{item.Name}\" content=\"{item.Content}\">{Environment.NewLine}";
                }
            }

            if (!metadata.Contains("twitter:site"))
            {
                metadata +=
                    $"<meta property=\"twitter:site\" content=\"@thedreamwedds\">{Environment.NewLine}";
                metadata +=
                    $"<meta name=\"og:site_name\" content=\"Dream Wedds | Your personal wedding website\">{Environment.NewLine}";
            }

            metadata += $"<link rel=\"canonical\" href=\"https:dreamwedds.com\">{Environment.NewLine}";
            metadata += $"<meta name=\"twitter:card\" content=\"summary_large_image\">{Environment.NewLine}";
            metadata += $"<meta property=\"og:type\" content=\"article\">{Environment.NewLine}";
            metadata += $"<meta name=\"robots\" content=\"max-image-preview:large\">{Environment.NewLine}";
            metadata += $"<meta name=\"og:locale\" content=\"en-US\">{Environment.NewLine}";
            metadata += $"<meta name=\"og:type\" content=\"website\">{Environment.NewLine}";
            metadata += $"<meta property=\"article:tag\" content=\"Elegance, Beautiful Woman, Bridal Lehanga, Dream Wedding, Culture, Wedding Website, Beautiful Wedding Images, India, Ornamented, Square Format Image, Tradition, Wedding, Wedding Dress, Online Wedding, Personal Wedding Website\">";
            metadata += $"<meta name=\"og:url\" content=\"https:dreamwedds.com\">{Environment.NewLine}";
            return metadata;
        }
    }
}
